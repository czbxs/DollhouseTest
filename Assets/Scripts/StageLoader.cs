/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;
using System.Collections;
using System.IO;
using MiniJSON;
using System.Collections.Generic;
using System.Linq;
using System;

public class StageLoader : MonoBehaviour 
{
	public static StageLoader instance = null;

    [Header("Basic")]
    public int Stage;
    public int column;
    public int row;
    public int moves;

    // layers
    [Header("Layers")]
    public List<TILE_TYPE> tileLayerData;
    public List<WAFFLE_TYPE> breakableLayerData;
    public List<ITEM_TYPE> itemLayerData;
	public List<LOCK_TYPE> lockLayerData;

    Dictionary<string, string> names = new Dictionary<string, string>();

    // properties
    [Header("Items")]
    public List<ITEM_TYPE> usingItems;
    public List<int> usingColors;
    public List<int> itemWeight;

    [Header("Rocket Toys")]
    public List<ITEM_TYPE> rocketToys;    
    public List<int> rockettoysWeight;
    public List<int> rocketToysMarkers;
    public int maxRockettoys;

    [Header("Target")]
    public TARGET_TYPE target1Type = TARGET_TYPE.NONE;
    public TARGET_TYPE target2Type = TARGET_TYPE.NONE;
    public TARGET_TYPE target3Type = TARGET_TYPE.NONE;
    public TARGET_TYPE target4Type = TARGET_TYPE.NONE;
    [Header("Target Values")]
    public int target1Amount;
    public int target2Amount;
    public int target3Amount;
    public int target4Amount;
    [Header("Target Items")]
    public int target1Color;
    public int target2Color;
    public int target3Color;
    public int target4Color;
    [Header("Stars")]
    public int score_Star_1;
    public int score_Star_2;
    public int score_Star_3;
    [Header("Target Text")]
    public string targetlbl;

    [Header("Collectible")]
    public List<int> collectibleCollectColumnMarkers;
    public List<int> collectibleCollectNodeMarkers;
    public List<int> collectibleGenerateMarkers;
    public int collectibleMaxOnBoard;

    public int marshmallowMoreThanTarget;

    [Header("Doll")]
    public int doll;    

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void LoadLevel(bool debug = false)
    {
        TextAsset jsonString;

        if (debug == true)
        {
			Stage = 999;
        }

		jsonString = Resources.Load("Levels/" + Stage, typeof(TextAsset)) as TextAsset;

        if (jsonString == null)
        {
            print("Can not load level data");
            return;
        }

        Clear();

        //print(jsonString);

        var dict = Json.Deserialize(jsonString.text) as Dictionary<string, object>;

        //var str = Json.Serialize(dict);

        //Debug.Log("serialized: " + str);

        column = int.Parse(dict["width"].ToString());
        row = int.Parse(dict["height"].ToString());

        #region tilesets

        var tilesets = (List<object>)dict["tilesets"];

        var tiles = (Dictionary<string, object>)tilesets[0];

        var images = (Dictionary<string, object>)tiles["tiles"];

        foreach (KeyValuePair<string, object> entry in images)
        {
            // do something with entry.Value or entry.Key
            var value = (Dictionary<string, object>)entry.Value;

            var image = (string)value["image"];

            string[] tokens = image.Split(new[] { "/" }, StringSplitOptions.None);

            var full = tokens[tokens.Length - 1];

            string[] parts = full.Split(new[] { "." }, StringSplitOptions.None);

            var name = parts[0];


            if (!names.ContainsKey(entry.Key))
            {
                names.Add(entry.Key, name);
            }
        }

        #endregion

        #region layers

        var layers = (List<object>)dict["layers"];
                
        foreach (object obj in layers)
        {
            var layer = (Dictionary<string, object>)obj;

            var data = (List<object>)layer["data"];
            //print(data);

            var name = (string)layer["name"];

            // tile
            if (name == "Tiles")
            {
                foreach (object datum in data)
                {
                    var type = DataToTileType(int.Parse(datum.ToString()));
                    tileLayerData.Add(type);
                }
            }

            // waffle
            else if (name == "breakable")
            {
                foreach (object datum in data)
                {
                    var type = DataToWaffleType(int.Parse(datum.ToString()));
					breakableLayerData.Add(type);
                }
            }

            // item
            else if (name == "items")
            {
                foreach (object datum in data)
                {
                    var type = DataToItemType(int.Parse(datum.ToString()));
                    itemLayerData.Add(type);
                }
            }

            // Lock
            else if (name == "Lock")
            {
                foreach (object datum in data)
                {
					var type = DataToLockType(int.Parse(datum.ToString()));
					lockLayerData.Add(type);
                }
            }
        }

        #endregion

        #region properties
        
        var properties = (Dictionary<string, object>)dict["properties"];

        // REQUIRED
		var items = ((string)properties["items"]).Split(',').ToList();
		var weights = ((string)properties["items_weight"]).Split(',').ToList();
                
        var count = 0;

		foreach (object obj in items)
        {
            var item = int.Parse(obj.ToString());
            var weight = int.Parse(weights[count].ToString());

            count++;

			if (item == 1)
            {
                switch (count)
                {
                    case 1:
					usingItems.Add(ITEM_TYPE.BlueBox);
                        usingColors.Add(1);
                        break;
                    case 2:
					usingItems.Add(ITEM_TYPE.GreenBox);
                        usingColors.Add(2);
                        break;
                    case 3:
					usingItems.Add(ITEM_TYPE.ORANGEBOX);
                        usingColors.Add(3);
                        break;
                    case 4:
					usingItems.Add(ITEM_TYPE.PURPLEBOX);
                        usingColors.Add(4);
                        break;
                    case 5:
					usingItems.Add(ITEM_TYPE.REDBOX);
                        usingColors.Add(5);
                        break;
                    case 6:
					usingItems.Add(ITEM_TYPE.YELLOWBOX);
                        usingColors.Add(6);
                        break;
                }

                itemWeight.Add(weight);
            }
        }

        if (properties.ContainsKey("rocket"))
        {
			if ((string)properties["rocket"] != "" && (string)properties["rocket_weight"] != "")
            {
				var rockets = ((string)properties["rocket"]).Split(',').ToList();
				var gWeights = ((string)properties["rocket_weight"]).Split(',').ToList();

                count = 0;

				foreach (object obj in rockets)
                {
                    var rocket = int.Parse(obj.ToString());
                    var gWeight = int.Parse(gWeights[count].ToString());

                    count++;

					if (rocket == 1)
                    {
                        switch (count)
                        {
                            case 1:
							rocketToys.Add(ITEM_TYPE.ROCKET_1);
                                break;
                            case 2:
							rocketToys.Add(ITEM_TYPE.ROCKET_2);
                                break;
                            case 3:
							rocketToys.Add(ITEM_TYPE.ROCKET_3);
                                break;
                            case 4:
							rocketToys.Add(ITEM_TYPE.ROCKET_4);
                                break;
                            case 5:
							rocketToys.Add(ITEM_TYPE.ROCKET_5);
                                break;
                            case 6:
							rocketToys.Add(ITEM_TYPE.ROCKET_6);
                                break;
                        }

						rockettoysWeight.Add(gWeight);

                    }
                }
            }
        }

        if (properties.ContainsKey("rocket_max"))
        {
			if (properties["rocket_max"].ToString() != "")
            {
				maxRockettoys = int.Parse(properties["rocket_max"].ToString());
            }
        }

        if (properties.ContainsKey("rocket_maker"))
        {
			var markers = ((string)properties["rocket_maker"]).Split(',').ToList();

            foreach (object obj in markers)
            {
                if (obj.ToString() != "")
                {
                    var marker = int.Parse(obj.ToString());

					rocketToysMarkers.Add(marker);
                }                
            }
        }
        
        // REQUIRED
        moves = int.Parse(properties["moves"].ToString());

        // REQUIRED
        var target1 = ((string)properties["target_1"]).Split(',').ToList();

        if (target1.Count >= 2)
        {
            target1Type = DataToTargetType(int.Parse(target1[0].ToString()));
            target1Amount = int.Parse(target1[1].ToString());

            if (target1.Count == 3) target1Color = int.Parse(target1[2].ToString());
        }

        var target2 = ((string)properties["target_2"]).Split(',').ToList();

        if (target2.Count >= 2)
        {
            target2Type = DataToTargetType(int.Parse(target2[0].ToString()));
            target2Amount = int.Parse(target2[1].ToString());

            if (target2.Count == 3) target2Color = int.Parse(target2[2].ToString());
        }

        var target3 = ((string)properties["target_3"]).Split(',').ToList();

        if (target3.Count >= 2)
        {
            target3Type = DataToTargetType(int.Parse(target3[0].ToString()));
            target3Amount = int.Parse(target3[1].ToString());

            if (target3.Count == 3) target3Color = int.Parse(target3[2].ToString());
        }

        var target4 = ((string)properties["target_4"]).Split(',').ToList();

        if (target4.Count >= 2)
        {
            target4Type = DataToTargetType(int.Parse(target4[0].ToString()));
            target4Amount = int.Parse(target4[1].ToString());

            if (target4.Count == 3) target4Color = int.Parse(target4[2].ToString());
        }

        // REQUIRED
		score_Star_1 = int.Parse(properties["score_star_1"].ToString());
		score_Star_2 = int.Parse(properties["score_star_2"].ToString());
		score_Star_3 = int.Parse(properties["score_star_3"].ToString());

        // REQUIRED
		doll = int.Parse(properties["doll"].ToString());

        // REQUIRED
		targetlbl = properties["target_lbl"].ToString();

        if (properties.ContainsKey("collectible_signs"))
        {
            // collectible collect marker NOT required
			var markers = ((string)properties["collectible_signs"]).Split(',').ToList();

            foreach (object obj in markers)
            {
                if (obj.ToString() != "")
                {
                    var marker = int.Parse(obj.ToString());

                    collectibleCollectColumnMarkers.Add(marker);
                }
            }
        }

        if (properties.ContainsKey("collectible_node"))
        {
            // collectible collect node marker NOT required
            var nodeMarkers = ((string)properties["collectible_node"]).Split(',').ToList();

            foreach (object obj in nodeMarkers)
            {
                if (obj.ToString() != "")
                {
                    var marker = int.Parse(obj.ToString());

                    collectibleCollectNodeMarkers.Add(marker);
                }
            }
        }

        if (properties.ContainsKey("collectible_maker"))
        {
            // collectible generate marker NOT required
			var markers = ((string)properties["collectible_maker"]).Split(',').ToList();

            foreach (object obj in markers)
            {
                if (obj.ToString() != "")
                {
                    var marker = int.Parse(obj.ToString());

                    collectibleGenerateMarkers.Add(marker);
                }
            }
        }

        if (properties.ContainsKey("collectible_max"))
        {
            // collectible max on board NOT required
			if (properties["collectible_max"].ToString() != "")
            {
				collectibleMaxOnBoard = int.Parse(properties["collectible_max"].ToString());
            }            
        }

        if (properties.ContainsKey("color_toy"))
        {
            // marshmallow more than target NOT required
            if (properties["color_toy"].ToString() != "")
            {
                marshmallowMoreThanTarget = int.Parse(properties["color_toy"].ToString());
            }
        }

        #endregion
    }

    void Clear()
    {
        tileLayerData.Clear();
		breakableLayerData.Clear();
        itemLayerData.Clear();
		lockLayerData.Clear();

        usingItems.Clear();
        usingColors.Clear();
        itemWeight.Clear();

		rocketToys.Clear();
		rockettoysWeight.Clear();
		rocketToysMarkers.Clear();
		maxRockettoys = 0;

        target1Type = TARGET_TYPE.NONE;
        target2Type = TARGET_TYPE.NONE;
        target3Type = TARGET_TYPE.NONE;
        target4Type = TARGET_TYPE.NONE;

        target1Amount = 0;
        target2Amount = 0;
        target3Amount = 0;
        target4Amount = 0;

        target1Color = 0;
        target2Color = 0;
        target3Color = 0;
        target4Color = 0;

        collectibleCollectColumnMarkers.Clear();
        collectibleCollectNodeMarkers.Clear();
        collectibleGenerateMarkers.Clear();
        collectibleMaxOnBoard = 0;

        marshmallowMoreThanTarget = 0;
    }

    #region Type

    TILE_TYPE DataToTileType(int key)
    {
        if (key == 0) return TILE_TYPE.NONE;

        var data = names[(key - 1).ToString()];

        switch (data)
        {
            case "none_tile":
                return TILE_TYPE.NONE;
            case "pass_through_tile":
                return TILE_TYPE.PASS_THROUGH;
            case "light_tile":
                return TILE_TYPE.LIGHT_TILE;
            case "dark_tile":
                return TILE_TYPE.DARD_TILE;
        }

        return TILE_TYPE.NONE;
    }

    ITEM_TYPE DataToItemType(int key)
    {
        if (key == 0) return ITEM_TYPE.NONE;
        
        var data = names[(key - 1).ToString()];

        switch (data)
        {
            case "random_item":
			return ITEM_TYPE.ITEM_RAMDOM;
		case "colorcone":
                return ITEM_TYPE.ITEM_COLORCONE;

		case "bluebox":
			return ITEM_TYPE.BlueBox;
		case "blue_bomb":
			return ITEM_TYPE.BlueBox_BOMB;
		case "blue_column":
			return ITEM_TYPE.BlueBox_COLUMN;
		case "blue_row":
			return ITEM_TYPE.BlueBox_ROW;
		case "blue_cross":
			return ITEM_TYPE.BlueBox_Cross;

		case "greenbox":
			return ITEM_TYPE.GreenBox;
		case "green_bomb":
			return ITEM_TYPE.GreenBox_BOMB;
		case "green_column":
			return ITEM_TYPE.GreenBox_COLUMN;
		case "green_row":
			return ITEM_TYPE.GreenBox_ROW;
		case "green_cross":
			return ITEM_TYPE.GreenBox_Cross;

		case "orangebox":
			return ITEM_TYPE.ORANGEBOX;
            case "orange_bomb":
			return ITEM_TYPE.ORANGEBOX_BOMB;
            case "orange_column":
			return ITEM_TYPE.ORANGEBOX_COLUMN;
            case "orange_row":
			return ITEM_TYPE.ORANGEBOX_ROW;
            case "orange_cross":
			return ITEM_TYPE.ORANGEBOX_Cross;

            case "purplebox":
			return ITEM_TYPE.PURPLEBOX;
            case "purple_bomb":
			return ITEM_TYPE.PURPLEBOX_BOMB;
            case "purple_column":
			return ITEM_TYPE.PURPLEBOX_COLUMN;
            case "purple_row":
			return ITEM_TYPE.PURPLEBOX_ROW;
            case "purple_cross":
			return ITEM_TYPE.PURPLEBOX_Cross;

            case "redbox":
			return ITEM_TYPE.REDBOX;
            case "red_bomb":
			return ITEM_TYPE.REDBOX_BOMB;
            case "red_column":
			return ITEM_TYPE.REDBOX_COLUMN;
            case "red_row":
			return ITEM_TYPE.REDBOX_ROW;
            case "red_cross":
			return ITEM_TYPE.REDBOX_Cross;

            case "yellowbox":
			return ITEM_TYPE.YELLOWBOX;
            case "yellow_bomb":
			return ITEM_TYPE.YELLOWBOX_BOMB;
            case "yellow_column":
			return ITEM_TYPE.YELLOWBOX_COLUMN;
            case "yellow_row":
			return ITEM_TYPE.YELLOWBOX_ROW;
            case "yellow_cross":
			return ITEM_TYPE.YELLOWBOX_Cross;

		case "breakable":
			return ITEM_TYPE.BREAKABLE;

		case "generic_CollectableToy":
			return ITEM_TYPE.ROCKET_RANDOM;
		case "blue_CollectableToy":
			return ITEM_TYPE.ROCKET_1;
		case "green_CollectableToy":
			return ITEM_TYPE.ROCKET_2;
		case "orange_CollectableToy":
			return ITEM_TYPE.ROCKET_3;
		case "purple_CollectableToy":
			return ITEM_TYPE.ROCKET_4;
		case "red_CollectableToy":
			return ITEM_TYPE.ROCKET_5;
		case "yellow_CollectableToy":
			return ITEM_TYPE.ROCKET_6;

		case "toymine_1":
                return ITEM_TYPE.MINE_1_LAYER;
		case "toymine_2":
                return ITEM_TYPE.MINE_2_LAYER;
		case "toymine_3":
                return ITEM_TYPE.MINE_3_LAYER;
		case "toymine_4":
                return ITEM_TYPE.MINE_4_LAYER;
		case "toymine_5":
                return ITEM_TYPE.MINE_5_LAYER;
		case "toymine_6":
                return ITEM_TYPE.MINE_6_LAYER;

		case "generic_lego_box":
                return ITEM_TYPE.ROCK_CANDY_RANDOM;
		case "blue_lego_box":
                return ITEM_TYPE.ROCK_CANDY_1;
		case "green_lego_box":
                return ITEM_TYPE.ROCK_CANDY_2;
		case "orange_lego_box":
                return ITEM_TYPE.ROCK_CANDY_3;
		case "purple_lego_box":
                return ITEM_TYPE.ROCK_CANDY_4;
		case "red_lego_box":
                return ITEM_TYPE.ROCK_CANDY_5;
		case "yellow_lego_box":
                return ITEM_TYPE.ROCK_CANDY_6;

            case "collectible_1":
                return ITEM_TYPE.COLLECTIBLE_1;
            case "collectible_2":
                return ITEM_TYPE.COLLECTIBLE_2;
            case "collectible_3":
                return ITEM_TYPE.COLLECTIBLE_3;
            case "collectible_4":
                return ITEM_TYPE.COLLECTIBLE_4;
            case "collectible_5":
                return ITEM_TYPE.COLLECTIBLE_5;
            case "collectible_6":
                return ITEM_TYPE.COLLECTIBLE_6;
            case "collectible_7":
                return ITEM_TYPE.COLLECTIBLE_7;
            case "collectible_8":
                return ITEM_TYPE.COLLECTIBLE_8;
            case "collectible_9":
                return ITEM_TYPE.COLLECTIBLE_9;
            case "collectible_10":
                return ITEM_TYPE.COLLECTIBLE_10;
            case "collectible_11":
                return ITEM_TYPE.COLLECTIBLE_11;
            case "collectible_12":
                return ITEM_TYPE.COLLECTIBLE_12;
            case "collectible_13":
                return ITEM_TYPE.COLLECTIBLE_13;
            case "collectible_14":
                return ITEM_TYPE.COLLECTIBLE_14;
            case "collectible_15":
                return ITEM_TYPE.COLLECTIBLE_15;
            case "collectible_16":
                return ITEM_TYPE.COLLECTIBLE_16;
            case "collectible_17":
                return ITEM_TYPE.COLLECTIBLE_17;
            case "collectible_18":
                return ITEM_TYPE.COLLECTIBLE_18;
            case "collectible_19":
                return ITEM_TYPE.COLLECTIBLE_19;
            case "collectible_20":
                return ITEM_TYPE.COLLECTIBLE_20;
        }

        return ITEM_TYPE.NONE;
    }

    WAFFLE_TYPE DataToWaffleType(int key)
    {
        if (key == 0) return WAFFLE_TYPE.NONE;

        var data = names[(key - 1).ToString()];

        switch (data)
        {
            case "waffle_1":
                return WAFFLE_TYPE.WAFFLE_1;
            case "waffle_2":
                return WAFFLE_TYPE.WAFFLE_2;
            case "waffle_3":
                return WAFFLE_TYPE.WAFFLE_3;
        }

        return WAFFLE_TYPE.NONE;
    }

	LOCK_TYPE DataToLockType(int key)
    {
		if (key == 0) return LOCK_TYPE.NONE;

        var data = names[(key - 1).ToString()];

        switch (data)
        {
            case "Lock":
			return LOCK_TYPE.LOCK_1;
        }

		return LOCK_TYPE.NONE;
    }

    TARGET_TYPE DataToTargetType(int data)
    {
        switch (data)
        {
            case 1:
                return TARGET_TYPE.SCORE;
            case 2:
			return TARGET_TYPE.ITEM;
            case 3:
			return TARGET_TYPE.BREAKABLE;
            case 4:
                return TARGET_TYPE.WAFFLE;
            case 5:
                return TARGET_TYPE.COLLECTIBLE;
            case 6:
                return TARGET_TYPE.COLUMN_ROW_BREAKER;
            case 7:
                return TARGET_TYPE.BOMB_BREAKER;
            case 8:
                return TARGET_TYPE.X_BREAKER;
            case 9:
			return TARGET_TYPE.LOCK;
            case 10:
			return TARGET_TYPE.COLORCONE;
            case 11:
			return TARGET_TYPE.ROCKET;
            case 12:
			return TARGET_TYPE.TOYMINE;
            case 13:
                return TARGET_TYPE.ROCK_CANDY;
        }

        return TARGET_TYPE.NONE;
    }

    #endregion

    #region Utility

    // random with weighted
    public ITEM_TYPE RandomItems()
    {
        var items = new List<ITEM_TYPE>();

        for (int i = 0; i < usingItems.Count; i++)
        {
            var type = usingItems[i];

            for (int j = 0; j < itemWeight[i]; j++)
            {
                switch (type)
                {
				case ITEM_TYPE.BlueBox:
					items.Add(ITEM_TYPE.BlueBox);
                        break;
				case ITEM_TYPE.GreenBox:
					items.Add(ITEM_TYPE.GreenBox);
                        break;
				case ITEM_TYPE.ORANGEBOX:
					items.Add(ITEM_TYPE.ORANGEBOX);
                        break;
				case ITEM_TYPE.PURPLEBOX:
					items.Add(ITEM_TYPE.PURPLEBOX);
                        break;
				case ITEM_TYPE.REDBOX:
					items.Add(ITEM_TYPE.REDBOX);
                        break;
				case ITEM_TYPE.YELLOWBOX:
					items.Add(ITEM_TYPE.YELLOWBOX);
                        break;
                }
            }
        }
			
		var index = UnityEngine.Random.Range(0, items.Count);

		return items[index];
    }

    public int RandomColor()
    {
		var type = RandomItems();

        switch (type)
        {
		case ITEM_TYPE.BlueBox:
                return 1;
		case ITEM_TYPE.GreenBox:
                return 2;
		case ITEM_TYPE.ORANGEBOX:
                return 3;
		case ITEM_TYPE.PURPLEBOX:
                return 4;
		case ITEM_TYPE.REDBOX:
                return 5;
		case ITEM_TYPE.YELLOWBOX:
                return 6;
            default:
                return 0;
        }
    }

    // with weighted
    public ITEM_TYPE RandomRockets()
    {
        var rockets = new List<ITEM_TYPE>();

		for (int i = 0; i < rocketToys.Count; i++)
        {
			var type = rocketToys[i];

			for (int j = 0; j < rockettoysWeight[i]; j++)
            {
                switch (type)
                {
				case ITEM_TYPE.ROCKET_1:
					rockets.Add(ITEM_TYPE.ROCKET_1);
                        break;
				case ITEM_TYPE.ROCKET_2:
					rockets.Add(ITEM_TYPE.ROCKET_2);
                        break;
				case ITEM_TYPE.ROCKET_3:
					rockets.Add(ITEM_TYPE.ROCKET_3);
                        break;
				case ITEM_TYPE.ROCKET_4:
					rockets.Add(ITEM_TYPE.ROCKET_4);
                        break;
				case ITEM_TYPE.ROCKET_5:
					rockets.Add(ITEM_TYPE.ROCKET_5);
                        break;
				case ITEM_TYPE.ROCKET_6:
					rockets.Add(ITEM_TYPE.ROCKET_6);
                        break;
                }
            }
        }

		var index = UnityEngine.Random.Range(0, rockets.Count);

		return rockets[index];
    }

    #endregion
}
