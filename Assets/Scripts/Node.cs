
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node : MonoBehaviour 
{
    [Header("Variables")]
	public itemGrid grid;
    public Tile tile;
    public Waffle waffle;
    public Item item;
    public Cage cage;
    public GameObject ovenActive;
    [Header("Row & Columns")]
    public int i; // row of node
    public int j; // column of node

    #region Neighbor

    public Node LeftNeighbor()
    {
		return grid.GetNode(i, j - 1);
    }

    public Node RightNeighbor()
    {
		return grid.GetNode(i, j + 1);
    }

    public Node TopNeighbor()
    {
		return grid.GetNode(i - 1, j);
    }

    public Node BottomNeighbor()
    {
		return grid.GetNode(i + 1, j);
    }

    public Node TopLeftNeighbor()
    {
		return grid.GetNode(i - 1, j - 1);
    }

    public Node TopRightNeighbor()
    {
		return grid.GetNode(i - 1, j + 1);
    }

    public Node BottomLeftNeighbor()
    {
		return grid.GetNode(i + 1, j - 1);
    }

    public Node BottomRightNeighbor()
    {
		return grid.GetNode(i + 1, j + 1);
    }

    #endregion

    #region Item

    // Some how the function does not return a object. 
    // It always return a null pointer.
    public Item GenerateItem(ITEM_TYPE type)
    {
        Item item = null;

        switch (type)
        {
		case ITEM_TYPE.ITEM_RAMDOM:
                GenerateRandomCookie();
                break;

            case ITEM_TYPE.ITEM_COLORCONE:
			

		case ITEM_TYPE.BlueBox:
		case ITEM_TYPE.BlueBox_COLUMN:
		case ITEM_TYPE.BlueBox_ROW:
		case ITEM_TYPE.BlueBox_BOMB:

		case ITEM_TYPE.GreenBox:
		case ITEM_TYPE.GreenBox_COLUMN:
		case ITEM_TYPE.GreenBox_ROW:
		case ITEM_TYPE.GreenBox_BOMB:

		case ITEM_TYPE.ORANGEBOX:
		case ITEM_TYPE.ORANGEBOX_COLUMN:
		case ITEM_TYPE.ORANGEBOX_ROW:
		case ITEM_TYPE.ORANGEBOX_BOMB:

		case ITEM_TYPE.PURPLEBOX:
		case ITEM_TYPE.PURPLEBOX_COLUMN:
		case ITEM_TYPE.PURPLEBOX_ROW:
		case ITEM_TYPE.PURPLEBOX_BOMB:

		case ITEM_TYPE.REDBOX:
		case ITEM_TYPE.REDBOX_COLUMN:
		case ITEM_TYPE.REDBOX_ROW:
		case ITEM_TYPE.REDBOX_BOMB:

		case ITEM_TYPE.YELLOWBOX:
		case ITEM_TYPE.YELLOWBOX_COLUMN:
		case ITEM_TYPE.YELLOWBOX_ROW:
		case ITEM_TYPE.YELLOWBOX_BOMB:

		case ITEM_TYPE.BREAKABLE:

                InstantiateItem(type);
                break;

		case ITEM_TYPE.ROCKET_RANDOM:
                GenerateRandomGingerbread();
                break;

		case ITEM_TYPE.ROCKET_1:
		case ITEM_TYPE.ROCKET_2:
		case ITEM_TYPE.ROCKET_3:
		case ITEM_TYPE.ROCKET_4:
		case ITEM_TYPE.ROCKET_5:
		case ITEM_TYPE.ROCKET_6:

            case ITEM_TYPE.MINE_1_LAYER:
            case ITEM_TYPE.MINE_2_LAYER:
            case ITEM_TYPE.MINE_3_LAYER:
            case ITEM_TYPE.MINE_4_LAYER:
            case ITEM_TYPE.MINE_5_LAYER:
            case ITEM_TYPE.MINE_6_LAYER:
                InstantiateItem(type);
                break;

            case ITEM_TYPE.ROCK_CANDY_RANDOM:
                GenerateRandomRockCandy();
                break;

            case ITEM_TYPE.ROCK_CANDY_1:
            case ITEM_TYPE.ROCK_CANDY_2:
            case ITEM_TYPE.ROCK_CANDY_3:
            case ITEM_TYPE.ROCK_CANDY_4:
            case ITEM_TYPE.ROCK_CANDY_5:
            case ITEM_TYPE.ROCK_CANDY_6:

		case ITEM_TYPE.BlueBox_Cross:
		case ITEM_TYPE.GreenBox_Cross:
		case ITEM_TYPE.ORANGEBOX_Cross:
		case ITEM_TYPE.PURPLEBOX_Cross:
		case ITEM_TYPE.REDBOX_Cross:
		case ITEM_TYPE.YELLOWBOX_Cross:

            case ITEM_TYPE.COLLECTIBLE_1:
            case ITEM_TYPE.COLLECTIBLE_2:
            case ITEM_TYPE.COLLECTIBLE_3:
            case ITEM_TYPE.COLLECTIBLE_4:
            case ITEM_TYPE.COLLECTIBLE_5:
            case ITEM_TYPE.COLLECTIBLE_6:
            case ITEM_TYPE.COLLECTIBLE_7:
            case ITEM_TYPE.COLLECTIBLE_8:
            case ITEM_TYPE.COLLECTIBLE_9:
            case ITEM_TYPE.COLLECTIBLE_10:
            case ITEM_TYPE.COLLECTIBLE_11:
            case ITEM_TYPE.COLLECTIBLE_12:
            case ITEM_TYPE.COLLECTIBLE_13:
            case ITEM_TYPE.COLLECTIBLE_14:
            case ITEM_TYPE.COLLECTIBLE_15:
            case ITEM_TYPE.COLLECTIBLE_16:
            case ITEM_TYPE.COLLECTIBLE_17:
            case ITEM_TYPE.COLLECTIBLE_18:
            case ITEM_TYPE.COLLECTIBLE_19:
            case ITEM_TYPE.COLLECTIBLE_20:

                InstantiateItem(type);
                break;

        }

        return item;
    }

    Item GenerateRandomCookie()
    {
		var type = StageLoader.instance.RandomItems();

        return InstantiateItem(type);
    }

    Item GenerateRandomGingerbread()
    {
		var type = StageLoader.instance.RandomItems();

        switch (type)
        {
		case ITEM_TYPE.BlueBox:
			InstantiateItem(ITEM_TYPE.ROCKET_1);
                break;

		case ITEM_TYPE.GreenBox:
			InstantiateItem(ITEM_TYPE.ROCKET_2);
                break;

		case ITEM_TYPE.ORANGEBOX:
			InstantiateItem(ITEM_TYPE.ROCKET_3);
                break;

		case ITEM_TYPE.PURPLEBOX:
			InstantiateItem(ITEM_TYPE.ROCKET_4);
                break;

		case ITEM_TYPE.REDBOX:
			InstantiateItem(ITEM_TYPE.ROCKET_5);
                break;

		case ITEM_TYPE.YELLOWBOX:
			InstantiateItem(ITEM_TYPE.ROCKET_6);
                break;
        }

        return null;
    }

    Item GenerateRandomRockCandy()
    {
		var type = StageLoader.instance.RandomItems();

        switch (type)
        {
		case ITEM_TYPE.BlueBox:
                InstantiateItem(ITEM_TYPE.ROCK_CANDY_1);
                break;

		case ITEM_TYPE.GreenBox:
                InstantiateItem(ITEM_TYPE.ROCK_CANDY_2);
                break;

		case ITEM_TYPE.ORANGEBOX:
                InstantiateItem(ITEM_TYPE.ROCK_CANDY_3);
                break;

		case ITEM_TYPE.PURPLEBOX:
                InstantiateItem(ITEM_TYPE.ROCK_CANDY_4);
                break;

		case ITEM_TYPE.REDBOX:
                InstantiateItem(ITEM_TYPE.ROCK_CANDY_5);
                break;

		case ITEM_TYPE.YELLOWBOX:
                InstantiateItem(ITEM_TYPE.ROCK_CANDY_6);
                break;
        }

        return null;
    }

    Item InstantiateItem(ITEM_TYPE type)
    {
        GameObject piece = null;
        var color = 0;

        switch (type)
        {
            case ITEM_TYPE.ITEM_COLORCONE:
			piece = Instantiate(Resources.Load(Configuration.ItemColorCone())) as GameObject;
                break;

		case ITEM_TYPE.BlueBox:
                color = 1;
			piece = Instantiate(Resources.Load(Configuration.Item1())) as GameObject;
                break;
		case ITEM_TYPE.BlueBox_COLUMN:
                color = 1;
			piece = Instantiate(Resources.Load(Configuration.Item1Column())) as GameObject;
                break;
		case ITEM_TYPE.BlueBox_ROW:
                color = 1;
			piece = Instantiate(Resources.Load(Configuration.Item1Row())) as GameObject;
                break;
		case ITEM_TYPE.BlueBox_BOMB:
                color = 1;
			piece = Instantiate(Resources.Load(Configuration.Item1Bomb())) as GameObject;
                break;

		case ITEM_TYPE.GreenBox:
                color = 2;
			piece = Instantiate(Resources.Load(Configuration.Item2())) as GameObject;
                break;
		case ITEM_TYPE.GreenBox_COLUMN:
                color = 2;
			piece = Instantiate(Resources.Load(Configuration.Item2Column())) as GameObject;
                break;
		case ITEM_TYPE.GreenBox_ROW:
                color = 2;
			piece = Instantiate(Resources.Load(Configuration.Item2Row())) as GameObject;
                break;
		case ITEM_TYPE.GreenBox_BOMB:
                color = 2;
			piece = Instantiate(Resources.Load(Configuration.Item2Bomb())) as GameObject;
                break;

		case ITEM_TYPE.ORANGEBOX:
                color = 3;
			piece = Instantiate(Resources.Load(Configuration.Item3())) as GameObject;
                break;
		case ITEM_TYPE.ORANGEBOX_COLUMN:
                color = 3;
			piece = Instantiate(Resources.Load(Configuration.Item3Column())) as GameObject;
                break;
		case ITEM_TYPE.ORANGEBOX_ROW:
                color = 3;
			piece = Instantiate(Resources.Load(Configuration.Item3Row())) as GameObject;
                break;
		case ITEM_TYPE.ORANGEBOX_BOMB:
                color = 3;
			piece = Instantiate(Resources.Load(Configuration.Item3Bomb())) as GameObject;
                break;

		case ITEM_TYPE.PURPLEBOX:
                color = 4;
			piece = Instantiate(Resources.Load(Configuration.Item4())) as GameObject;
                break;
		case ITEM_TYPE.PURPLEBOX_COLUMN:
                color = 4;
			piece = Instantiate(Resources.Load(Configuration.Item4Column())) as GameObject;
                break;
		case ITEM_TYPE.PURPLEBOX_ROW:
                color = 4;
			piece = Instantiate(Resources.Load(Configuration.Item4Row())) as GameObject;
                break;
		case ITEM_TYPE.PURPLEBOX_BOMB:
                color = 4;
			piece = Instantiate(Resources.Load(Configuration.Item4Bomb())) as GameObject;
                break;

		case ITEM_TYPE.REDBOX:
                color = 5;
			piece = Instantiate(Resources.Load(Configuration.Item5())) as GameObject;
                break;
		case ITEM_TYPE.REDBOX_COLUMN:
                color = 5;
			piece = Instantiate(Resources.Load(Configuration.Item5Column())) as GameObject;
                break;
		case ITEM_TYPE.REDBOX_ROW:
                color = 5;
			piece = Instantiate(Resources.Load(Configuration.Item5Row())) as GameObject;
                break;
		case ITEM_TYPE.REDBOX_BOMB:
                color = 5;
			piece = Instantiate(Resources.Load(Configuration.Item5Bomb())) as GameObject;
                break;

		case ITEM_TYPE.YELLOWBOX:
                color = 6;
			piece = Instantiate(Resources.Load(Configuration.Item6())) as GameObject;
                break;
		case ITEM_TYPE.YELLOWBOX_COLUMN:
                color = 6;
			piece = Instantiate(Resources.Load(Configuration.Item6Column())) as GameObject;
                break;
		case ITEM_TYPE.YELLOWBOX_ROW:
                color = 6;
			piece = Instantiate(Resources.Load(Configuration.Item6Row())) as GameObject;
                break;
		case ITEM_TYPE.YELLOWBOX_BOMB:
                color = 6;
			piece = Instantiate(Resources.Load(Configuration.Item6Bomb())) as GameObject;
                break;

		case ITEM_TYPE.BREAKABLE:
			piece = Instantiate(Resources.Load(Configuration.Breakable())) as GameObject;
                break;

		case ITEM_TYPE.ROCKET_1:
                color = 1;
			piece = Instantiate(Resources.Load(Configuration.Rocket1())) as GameObject;
                break;
		case ITEM_TYPE.ROCKET_2:
                color = 2;
			piece = Instantiate(Resources.Load(Configuration.Rocket2())) as GameObject;
                break;
		case ITEM_TYPE.ROCKET_3:
                color = 3;
			piece = Instantiate(Resources.Load(Configuration.Rocket3())) as GameObject;
                break;
		case ITEM_TYPE.ROCKET_4:
                color = 4;
			piece = Instantiate(Resources.Load(Configuration.Rocket4())) as GameObject;
                break;
		case ITEM_TYPE.ROCKET_5:
                color = 5;
			piece = Instantiate(Resources.Load(Configuration.Rocket5())) as GameObject;
                break;
		case ITEM_TYPE.ROCKET_6:
                color = 6;
			piece = Instantiate(Resources.Load(Configuration.Rocket6())) as GameObject;
                break;

            case ITEM_TYPE.MINE_1_LAYER:
			piece = Instantiate(Resources.Load(Configuration.ToyMine1())) as GameObject;
                break;
            case ITEM_TYPE.MINE_2_LAYER:
			piece = Instantiate(Resources.Load(Configuration.ToyMine2())) as GameObject;
                break;
            case ITEM_TYPE.MINE_3_LAYER:
			piece = Instantiate(Resources.Load(Configuration.ToyMine3())) as GameObject;
                break;
            case ITEM_TYPE.MINE_4_LAYER:
			piece = Instantiate(Resources.Load(Configuration.ToyMine4())) as GameObject;
                break;
            case ITEM_TYPE.MINE_5_LAYER:
			piece = Instantiate(Resources.Load(Configuration.ToyMine5())) as GameObject;
                break;
            case ITEM_TYPE.MINE_6_LAYER:
			piece = Instantiate(Resources.Load(Configuration.ToyMine6())) as GameObject;
                break;

            case ITEM_TYPE.ROCK_CANDY_1:
                color = 1;
			piece = Instantiate(Resources.Load(Configuration.LegoBox1())) as GameObject;
                break;

            case ITEM_TYPE.ROCK_CANDY_2:
                color = 2;
			piece = Instantiate(Resources.Load(Configuration.LegoBox2())) as GameObject;
                break;

            case ITEM_TYPE.ROCK_CANDY_3:
                color = 3;
			piece = Instantiate(Resources.Load(Configuration.LegoBox3())) as GameObject;
                break;

            case ITEM_TYPE.ROCK_CANDY_4:
                color = 4;
			piece = Instantiate(Resources.Load(Configuration.LegoBox4())) as GameObject;
                break;

            case ITEM_TYPE.ROCK_CANDY_5:
                color = 5;
			piece = Instantiate(Resources.Load(Configuration.LegoBox5())) as GameObject;
                break;

            case ITEM_TYPE.ROCK_CANDY_6:
                color = 6;
			piece = Instantiate(Resources.Load(Configuration.LegoBox6())) as GameObject;
                break;

		case ITEM_TYPE.BlueBox_Cross:
			piece = Instantiate(Resources.Load(Configuration.Item1Cross())) as GameObject;
                color = 1;
                break;

		case ITEM_TYPE.GreenBox_Cross:
			piece = Instantiate(Resources.Load(Configuration.Item2Cross())) as GameObject;
                color = 2;
                break;

		case ITEM_TYPE.ORANGEBOX_Cross:
			piece = Instantiate(Resources.Load(Configuration.Item3Cross())) as GameObject;
                color = 3;
                break;

		case ITEM_TYPE.PURPLEBOX_Cross:
			piece = Instantiate(Resources.Load(Configuration.Item4Cross())) as GameObject;
                color = 4;
                break;

		case ITEM_TYPE.REDBOX_Cross:
			piece = Instantiate(Resources.Load(Configuration.Item5Cross())) as GameObject;
                color = 5;
                break;

		case ITEM_TYPE.YELLOWBOX_Cross:
			piece = Instantiate(Resources.Load(Configuration.Item6Cross())) as GameObject;
                color = 6;
                break;

            case ITEM_TYPE.COLLECTIBLE_1:
                piece = Instantiate(Resources.Load(Configuration.Collectible1())) as GameObject;
                color = 1;
                break;

            case ITEM_TYPE.COLLECTIBLE_2:
                piece = Instantiate(Resources.Load(Configuration.Collectible2())) as GameObject;
                color = 2;
                break;

            case ITEM_TYPE.COLLECTIBLE_3:
                piece = Instantiate(Resources.Load(Configuration.Collectible3())) as GameObject;
                color = 3;
                break;

            case ITEM_TYPE.COLLECTIBLE_4:
                piece = Instantiate(Resources.Load(Configuration.Collectible4())) as GameObject;
                color = 4;
                break;

            case ITEM_TYPE.COLLECTIBLE_5:
                piece = Instantiate(Resources.Load(Configuration.Collectible5())) as GameObject;
                color = 5;
                break;

            case ITEM_TYPE.COLLECTIBLE_6:
                piece = Instantiate(Resources.Load(Configuration.Collectible6())) as GameObject;
                color = 6;
                break;

            case ITEM_TYPE.COLLECTIBLE_7:
                piece = Instantiate(Resources.Load(Configuration.Collectible7())) as GameObject;
                color = 7;
                break;

            case ITEM_TYPE.COLLECTIBLE_8:
                piece = Instantiate(Resources.Load(Configuration.Collectible8())) as GameObject;
                color = 8;
                break;

            case ITEM_TYPE.COLLECTIBLE_9:
                piece = Instantiate(Resources.Load(Configuration.Collectible9())) as GameObject;
                color = 9;
                break;

            case ITEM_TYPE.COLLECTIBLE_10:
                piece = Instantiate(Resources.Load(Configuration.Collectible10())) as GameObject;
                color = 10;
                break;

            case ITEM_TYPE.COLLECTIBLE_11:
                piece = Instantiate(Resources.Load(Configuration.Collectible11())) as GameObject;
                color = 11;
                break;

            case ITEM_TYPE.COLLECTIBLE_12:
                piece = Instantiate(Resources.Load(Configuration.Collectible12())) as GameObject;
                color = 12;
                break;

            case ITEM_TYPE.COLLECTIBLE_13:
                piece = Instantiate(Resources.Load(Configuration.Collectible13())) as GameObject;
                color = 13;
                break;

            case ITEM_TYPE.COLLECTIBLE_14:
                piece = Instantiate(Resources.Load(Configuration.Collectible14())) as GameObject;
                color = 14;
                break;

            case ITEM_TYPE.COLLECTIBLE_15:
                piece = Instantiate(Resources.Load(Configuration.Collectible15())) as GameObject;
                color = 15;
                break;

            case ITEM_TYPE.COLLECTIBLE_16:
                piece = Instantiate(Resources.Load(Configuration.Collectible16())) as GameObject;
                color = 16;
                break;

            case ITEM_TYPE.COLLECTIBLE_17:
                piece = Instantiate(Resources.Load(Configuration.Collectible17())) as GameObject;
                color = 17;
                break;

            case ITEM_TYPE.COLLECTIBLE_18:
                piece = Instantiate(Resources.Load(Configuration.Collectible18())) as GameObject;
                color = 18;
                break;

            case ITEM_TYPE.COLLECTIBLE_19:
                piece = Instantiate(Resources.Load(Configuration.Collectible19())) as GameObject;
                color = 19;
                break;

            case ITEM_TYPE.COLLECTIBLE_20:
                piece = Instantiate(Resources.Load(Configuration.Collectible20())) as GameObject;
                color = 20;
                break;
        }

        if (piece != null)
        {
            piece.transform.SetParent(gameObject.transform);
            piece.name = "Item";
			piece.transform.localPosition = grid.NodeLocalPosition(i, j);
            piece.GetComponent<Item>().node = this;
			piece.GetComponent<Item>().board = this.grid;
            piece.GetComponent<Item>().type = type;
            piece.GetComponent<Item>().color = color;

            this.item = piece.GetComponent<Item>();
            
            return piece.GetComponent<Item>();
        }
        else
        {
            return null;
        }
    }

    #endregion

    #region Match

    // find matches at a node
    public List<Item> FindMatches(FIND_DIRECTION direction = FIND_DIRECTION.NONE, int matches = 2)
    {
        var list = new List<Item>();
        var countedNodes = new Dictionary<int, Item>();

        if (item == null || !item.Matchable())
        {
            return null;
        }

        if (direction != FIND_DIRECTION.COLUMN)
        {
            countedNodes = FindMoreMatches(item.color, countedNodes, FIND_DIRECTION.ROW);
        }

        if (countedNodes.Count < matches)
        {
            countedNodes.Clear();
        }

        if (direction != FIND_DIRECTION.ROW)
        {
            countedNodes = FindMoreMatches(item.color, countedNodes, FIND_DIRECTION.COLUMN);
        }

        if (countedNodes.Count < matches)
        {
            countedNodes.Clear();
        }

        foreach (KeyValuePair<int, Item> entry in countedNodes)
        {
            list.Add(entry.Value);
        }

        return list;
    }

    // helper function to find matches
    Dictionary<int, Item> FindMoreMatches(int color, Dictionary<int, Item> countedNodes, FIND_DIRECTION direction)
    {
        if (item == null || item.destroying)
        {
            return countedNodes;
        }

        if (item.color == color && !countedNodes.ContainsValue(item) && item.Matchable() && item.node != null)
        {
            countedNodes.Add(item.node.OrderOnBoard(), item);

			if (direction == FIND_DIRECTION.ROW) {
				if (LeftNeighbor () != null) {
					countedNodes = LeftNeighbor ().FindMoreMatches (color, countedNodes, FIND_DIRECTION.ROW);
				}

				if (RightNeighbor () != null) {
					countedNodes = RightNeighbor ().FindMoreMatches (color, countedNodes, FIND_DIRECTION.ROW);
				}

				if (TopNeighbor () != null) {
					countedNodes = TopNeighbor ().FindMoreMatches (color, countedNodes, FIND_DIRECTION.COLUMN);
				}

				if (BottomNeighbor () != null) {
					countedNodes = BottomNeighbor ().FindMoreMatches (color, countedNodes, FIND_DIRECTION.COLUMN);
				}

			} else if (direction == FIND_DIRECTION.COLUMN) {
				//Top, Top Left and Top Right neighbor
				if (TopNeighbor () != null) {
					countedNodes = TopNeighbor ().FindMoreMatches (color, countedNodes, FIND_DIRECTION.COLUMN);
				}

				if (BottomNeighbor () != null) {
					countedNodes = BottomNeighbor ().FindMoreMatches (color, countedNodes, FIND_DIRECTION.COLUMN);
				}

				if (LeftNeighbor () != null) {
					countedNodes = LeftNeighbor ().FindMoreMatches (color, countedNodes, FIND_DIRECTION.ROW);
				}

				if (RightNeighbor () != null) {
					countedNodes = RightNeighbor ().FindMoreMatches (color, countedNodes, FIND_DIRECTION.ROW);
				}
			} 
        }

        return countedNodes;
    }

    #endregion

    #region Utility

    // return the order base on i and j
    public int OrderOnBoard()
    {
        return (i * StageLoader.instance.column + j );
    }

    #endregion

    #region Type

    public bool CanStoreItem()
    {
        if (tile != null)
        {
            if (tile.type == TILE_TYPE.DARD_TILE || tile.type == TILE_TYPE.LIGHT_TILE)
            {
                return true;
            }
        }

        return false;
    }

    public bool CanGoThrough()
    {
        if (tile == null || tile.type == TILE_TYPE.NONE)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool CanGenerateNewItem()
    {
        if (CanStoreItem() == true)
        {
            for (int row = i - 1; row >= 0; row--)
            {
				Node upNode = grid.GetNode(row, j);

                if (upNode != null)
                {
                    if (upNode.CanGoThrough() == false)
                    {
                        return false;
                    }
                    else
                    {
                        if (upNode.item != null)
                        {
                            if (upNode.item.Movable() == false)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }
        else
        {
            return false;
        }
    }

    #endregion

    #region Node

    // get source node of an empty node
    public Node GetSourceNode()
    {
        Node source = null;

        // top
		Node top = grid.GetNode(i - 1, j);
        if (top != null)
        {
            if (top.item == null && top.CanGoThrough())
            {
                if (top.GetSourceNode() != null)
                {
                    source = top.GetSourceNode();
                }
            }
        }

        if (source != null)
        {
            return source;
        }

        // left
		Node left = grid.GetNode(i - 1, j - 1);
        if (left != null)
        {
            if (left.item == null && left.CanGoThrough())
            {
                if (left.GetSourceNode() != null)
                {
                    source = left.GetSourceNode();
                }
            }
            else
            {
                if (left.item != null && left.item.Movable())
                {
                    source = left;
                }
            }
        }

        if (source != null)
        {
            return source;
        }

        // right
		Node right = grid.GetNode(i - 1, j + 1);
        if (right != null)
        {
            if (right.item == null && right.CanGoThrough())
            {
                if (right.GetSourceNode() != null)
                {
                    source = right.GetSourceNode();
                }
            }
            else
            {
                if (right.item != null && right.item.Movable())
                {
                    source = right;
                }
            }
        }

        return source;
    }

    // get move path from an empty node to source node
    public List<Vector3> GetMovePath()
    {
        List<Vector3> path = new List<Vector3>();

		path.Add(grid.NodeLocalPosition(i, j));

        // top
		Node top = grid.GetNode(i - 1, j);
        if (top != null)
        {
            if (top.item == null && top.CanGoThrough())
            {
                if (top.GetSourceNode() != null)
                {
                    path.AddRange(top.GetMovePath());
                    return path;
                }
            }
        }

        // left
		Node left = grid.GetNode(i - 1, j - 1);
        if (left != null)
        {
            if (left.item == null && left.CanGoThrough())
            {
                if (left.GetSourceNode() != null)
                {
                    path.AddRange(left.GetMovePath());
                    return path;
                }
            }
            else
            {
                if (left.item != null && left.item.Movable())
                {
                    return path;
                }
            }
        }

        // right
		Node right = grid.GetNode(i - 1, j + 1);
        if (right != null)
        {
            if (right.item == null && right.CanGoThrough())
            {
                if (right.GetSourceNode() != null)
                {
                    path.AddRange(right.GetMovePath());
                    return path;
                }
            }
            else
            {
                if (right.item != null && right.item.Movable())
                {
                    return path;
                }
            }
        }

        return path;
    }

    #endregion

    #region Waffle

    public void WaffleExplode()
    {
		if (waffle != null && item != null & (item.IsCookie() == true || item.IsBreaker(item.type) || item.type == ITEM_TYPE.ITEM_COLORCONE))
        {
            SFXManager.instance.WaffleExplodeAudio();

			grid.CollectWaffle(waffle);

            GameObject prefab = null;

            if (waffle.type == WAFFLE_TYPE.WAFFLE_3)
            {
                prefab = Resources.Load(Configuration.Waffle2()) as GameObject;

                waffle.gameObject.GetComponent<SpriteRenderer>().sprite = prefab.GetComponent<SpriteRenderer>().sprite;

                waffle.type = WAFFLE_TYPE.WAFFLE_2;
            }
            else if (waffle.type == WAFFLE_TYPE.WAFFLE_2)
            {
                prefab = Resources.Load(Configuration.Waffle1()) as GameObject;

                waffle.gameObject.GetComponent<SpriteRenderer>().sprite = prefab.GetComponent<SpriteRenderer>().sprite;

                waffle.type = WAFFLE_TYPE.WAFFLE_1;
            }
            else if (waffle.type == WAFFLE_TYPE.WAFFLE_1)
            {
                Destroy(waffle.gameObject);

                waffle = null;
            }
        }
    }

    #endregion

    #region Cage

    public void CageExplode()
    {
        if (cage == null)
        {
            return;
        }

        GameObject explosion = null;

        if (item != null)
        {
            switch (item.GetCookie(item.type))
            {
			case ITEM_TYPE.BlueBox:
				explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.BlueBoxExplosion()) as GameObject);
                    break;
			case ITEM_TYPE.GreenBox:
				explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.GreenBoxExplosion()) as GameObject);
                    break;
			case ITEM_TYPE.ORANGEBOX:
                    explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.OrangeCookieExplosion()) as GameObject);
                    break;
			case ITEM_TYPE.PURPLEBOX:
                    explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.PurpleCookieExplosion()) as GameObject);
                    break;
			case ITEM_TYPE.REDBOX:
                    explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.RedCookieExplosion()) as GameObject);
                    break;
			case ITEM_TYPE.YELLOWBOX:
                    explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.YellowCookieExplosion()) as GameObject);
                    break;
            }
        }

		grid.CollectCage(cage);

        if (explosion != null) explosion.transform.position = item.transform.position;

        SFXManager.instance.CageExplodeAudio();

        Destroy(cage.gameObject);

        cage = null;

        StartCoroutine(item.ResetDestroying());
    }

    #endregion

    #region Booster

    public void AddOvenBoosterActive()
    {
        ovenActive = Instantiate(Resources.Load(Configuration.BoosterActive())) as GameObject;

		ovenActive.transform.localPosition = grid.NodeLocalPosition(i, j);
    }

    public void RemoveOvenBoosterActive()
    {
        Destroy(ovenActive);

        ovenActive = null;
    }

    #endregion
}
