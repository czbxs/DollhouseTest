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
using System.Collections.Generic;
using MiniJSON;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class CoreData : MonoBehaviour 
{
	public static CoreData instance = null;

    [Header("Player & Levels Data")]
    public int playerCoin;
    public int openedLevel;

    [Header("Breaker Values")]
    public int singleBreaker;
    public int rowBreaker;
    public int columnBreaker;
    public int rainbowBreaker;
    public int ovenBreaker;

    [Header("Power Ups Value")]
    public int beginFiveMoves;
    public int beginRainbow;
    public int beginBombBreaker;

    public List<Dictionary<string, object>> levelStatistics = new List<Dictionary<string, object>>();

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

        if (LoadGameData() == null)
        {
            SaveGameData(PrepareGameData());

            return;
        }
    }

    #region Load

    string LoadGameData()
    {

        if (File.Exists(Application.persistentDataPath + "/" + Configuration.game_data))
        {
            BinaryFormatter bf = new BinaryFormatter();

            FileStream file = File.Open(Application.persistentDataPath + "/" + Configuration.game_data, FileMode.Open);

            string jsonString = (string)bf.Deserialize(file);

            file.Close();

            Dictionary<string, object> dict = Json.Deserialize(jsonString) as Dictionary<string, object>;

//            playerCoin = int.Parse(dict[Configuration.player_coin].ToString());
			playerCoin = 10000;
            openedLevel = int.Parse(dict[Configuration.opened_level].ToString());
            openedLevel = (openedLevel > 0) ? openedLevel : 1;
            singleBreaker = int.Parse(dict[Configuration.single_breaker].ToString());
            rowBreaker = int.Parse(dict[Configuration.row_breaker].ToString());            
            columnBreaker = int.Parse(dict[Configuration.column_breaker].ToString());
            rainbowBreaker = int.Parse(dict[Configuration.rainbow_breaker].ToString());
            ovenBreaker = int.Parse(dict[Configuration.oven_breaker].ToString());
            beginFiveMoves = int.Parse(dict[Configuration.begin_five_moves].ToString());
            beginRainbow = int.Parse(dict[Configuration.begin_rainbow].ToString());
            beginBombBreaker = int.Parse(dict[Configuration.begin_bomb_breaker].ToString());

            List<object> list = (List<object>)dict[Configuration.level_statistics];
            foreach (object t in list)
            {
                Dictionary<string, object> d = (Dictionary<string, object>)t;

                levelStatistics.Add(d);
            }


            return jsonString;
        }

        return null;
    }

    #endregion

    #region Save

    void SaveGameData(string jsonString)
    {
        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = File.Create(Application.persistentDataPath + "/" + Configuration.game_data);

        bf.Serialize(file, jsonString);

        file.Close();
    }

    string PrepareGameData()
    {
        Dictionary<string, object> dict = new Dictionary<string, object>();

        if (openedLevel == 0) openedLevel = 1;
        
        // Test open all levels
        //if (openedLevel == 0) openedLevel = 84;

        // Test max coins
        if (playerCoin == 0) playerCoin = 10000;

        dict.Add(Configuration. player_coin, playerCoin);
        dict.Add(Configuration.opened_level, openedLevel);
        dict.Add(Configuration.single_breaker, singleBreaker);
        dict.Add(Configuration.row_breaker, rowBreaker);
        dict.Add(Configuration.column_breaker, columnBreaker);
        dict.Add(Configuration.rainbow_breaker, rainbowBreaker);
        dict.Add(Configuration.oven_breaker, ovenBreaker);
        dict.Add(Configuration.begin_five_moves, beginFiveMoves);
        dict.Add(Configuration.begin_rainbow, beginRainbow);
        dict.Add(Configuration.begin_bomb_breaker, beginBombBreaker);

        dict.Add(Configuration.level_statistics, levelStatistics);

        return Json.Serialize(dict);
    }

    #endregion

    #region Level

    public int GetOpendedLevel()
    {
        return openedLevel;
    }

    public void SaveOpendedLevel(int level)
    {
        openedLevel = level;

        SaveGameData(PrepareGameData());
    }

    public int GetLevelScore(int level)
    {
        foreach (Dictionary<string, object> statistics in levelStatistics)
        {
            if (int.Parse(statistics[Configuration.level_number].ToString()) == level)
            {
                return int.Parse(statistics[Configuration.level_score].ToString());
            }
        }

        return 0;
    }

    public int GetLevelStar(int level)
    {
        foreach (Dictionary<string, object> statistics in levelStatistics)
        {
            if (int.Parse(statistics[Configuration.level_number].ToString()) == level)
            {
                return int.Parse(statistics[Configuration.level_star].ToString());
            }
        }

        return 0;
    }

    public void SaveLevelStatistics(int level, int score, int star)
    {
        foreach (Dictionary<string, object> statistics in levelStatistics)
        {
            if (int.Parse(statistics[Configuration.level_number].ToString()) == level)
            {
                // only update if new score/star is greater then the old one
                if (int.Parse(statistics[Configuration.level_score].ToString()) < score)
                {
                    statistics[Configuration.level_score] = score;
                }

                if (int.Parse(statistics[Configuration.level_star].ToString()) < star)
                {
                    statistics[Configuration.level_star] = star;
                }

                SaveGameData(PrepareGameData());

                return;
            }
        }

        // if don't find a old record then create a new one
        Dictionary<string, object> stats = new Dictionary<string, object>();

        stats.Add(Configuration.level_number, level);
        stats.Add(Configuration.level_score, score);
        stats.Add(Configuration.level_star, star);

        levelStatistics.Add(stats);

        SaveGameData(PrepareGameData());
    }

    #endregion

    #region Data

    public int GetPlayerCoin()
    {
        return playerCoin;
    }

    public void SavePlayerCoin(int coin)
    {
        playerCoin = coin;

        SaveGameData(PrepareGameData());
    }

    public int GetBeginFiveMoves()
    {
        return beginFiveMoves;
    }

    public void SaveBeginFiveMoves(int number)
    {
        beginFiveMoves = number;

        SaveGameData(PrepareGameData());
    }

    public int GetBeginRainbow()
    {
        return beginRainbow;
    }

    public void SaveBeginRainbow(int number)
    {
        beginRainbow = number;

        SaveGameData(PrepareGameData());
    }

    public int GetBeginBombBreaker()
    {
        return beginBombBreaker;
    }

    public void SaveBeginBombBreaker(int number)
    {
        beginBombBreaker = number;

        SaveGameData(PrepareGameData());
    }

    public int GetSingleBreaker()
    {
        return singleBreaker;
    }

    public void SaveSingleBreaker(int number)
    {
        singleBreaker = number;

        SaveGameData(PrepareGameData());
    }

    public int GetRowBreaker()
    {
        return rowBreaker;
    }

    public void SaveRowBreaker(int number)
    {
        rowBreaker = number;

        SaveGameData(PrepareGameData());
    }

    public int GetColumnBreaker()
    {
        return columnBreaker;
    }

    public void SaveColumnBreaker(int number)
    {
        columnBreaker = number;

        SaveGameData(PrepareGameData());
    }

    public int GetRainbowBreaker()
    {
        return rainbowBreaker;
    }

    public void SaveRainbowBreaker(int number)
    {
        rainbowBreaker = number;

        SaveGameData(PrepareGameData());
    }

    public int GetOvenBreaker()
    {
        return ovenBreaker;
    }

    public void SaveOvenBreaker(int number)
    {
        ovenBreaker = number;

        SaveGameData(PrepareGameData());
    }

    #endregion
}
