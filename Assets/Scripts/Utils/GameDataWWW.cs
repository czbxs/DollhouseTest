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

public class GameDataWWW : MonoBehaviour 
{
    public static GameDataWWW instance = null;

    [Header("Data")]
    public int playerCoin;
    public int openedLevel;

    [Header("")]
    public int singleBreaker;
    public int rowBreaker;
    public int columnBreaker;
    public int rainbowBreaker;
    public int ovenBreaker;

    [Header("")]
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
    }

    void Start()
    {
        if (LoadGameDataWWW() == null)
        {
            SaveGameDataWWW(PrepareGameDataWWW());

            return;
        }
    }

    #region Load

    string LoadGameDataWWW()
    {
        return "";
    }

    #endregion

    #region Save

    void SaveGameDataWWW(string jsonString)
    {
    }

    string PrepareGameDataWWW()
    {
        return "";
    }

    #endregion
}
