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
using UnityEngine.UI;

public class UI_Level : MonoBehaviour 
{
    public Text levelText;
    public Image star1;
    public Image star2;
    public Image star3;

    public Image tick1;
    public Image tick2;
    public Image tick3;
    public Image add1;
    public Image add2;
    public Image add3;
    public Text number1;
    public Text number2;
    public Text number3;

    public Text targetText;

    public SceneTransition transition;
    public PopupOpener beginBooster1Popup;
    public PopupOpener beginBooster2Popup;
    public PopupOpener beginBooster3Popup;

    public bool avaialbe1;
    public bool avaialbe2;
    public bool avaialbe3;

    public Image booster1;
    public Image booster2;
    public Image booster3;

    public GameObject locked1;
    public GameObject locked2;
    public GameObject locked3;

    public Text lockedText1;
    public Text lockedText2;
    public Text lockedText3;

    // FB Leaderboard
    public GameObject FBLeaderboard;

    void Start()
    {
		levelText.text = "Level " + StageLoader.instance.Stage.ToString();

        Configuration.instance.beginFiveMoves = false;
        Configuration.instance.beginRainbow = false;
        Configuration.instance.beginBombBreaker = false;

		var star = CoreData.instance.GetLevelStar(StageLoader.instance.Stage);

        switch (star)
        {
            case 1:
                star1.gameObject.SetActive(true);
                star2.gameObject.SetActive(false);
                star3.gameObject.SetActive(false);
                break;
            case 2:
                star1.gameObject.SetActive(true);
                star2.gameObject.SetActive(true);
                star3.gameObject.SetActive(false);
                break;
            case 3:
                star1.gameObject.SetActive(true);
                star2.gameObject.SetActive(true);
                star3.gameObject.SetActive(true);
                break;
            default:
                star1.gameObject.SetActive(false);
                star2.gameObject.SetActive(false);
                star3.gameObject.SetActive(false);
                break;
        }

        string name;
		if (StageLoader.instance.doll > 0)
        {
			name = "doll_" + StageLoader.instance.doll + "_4";
        }
        else
        {
            // default/test
            name = "cake_1_4";
        }
        
		targetText.text = StageLoader.instance.targetlbl;

        // begin boosters
        for (int i = 1; i <=3; i++)
        {
            int boosterAmount = 0;
            Image tick = null;
            Image add = null;
            Text number = null;
            bool avaialbe = false;
            Image booster = null;
            GameObject locked = null;
            Text lockedText = null;

            switch (i)
            {
                case 1:
                    boosterAmount = CoreData.instance.beginFiveMoves;
                    tick = tick1;
                    add = add1;
                    number = number1;
				avaialbe1 = (StageLoader.instance.Stage < Configuration.instance.beginFiveMovesLevel) ? false : true;
                    avaialbe = avaialbe1;
                    booster = booster1;
                    locked = locked1;
                    lockedText = lockedText1;
                    break;
                case 2:
                    boosterAmount = CoreData.instance.beginRainbow;
                    tick = tick2;
                    add = add2;
                    number = number2;
				avaialbe2 = (StageLoader.instance.Stage < Configuration.instance.beginRainbowLevel) ? false : true;
                    avaialbe = avaialbe2;
                    booster = booster2;
                    locked = locked2;
                    lockedText = lockedText2;
                    break;
                case 3:
                    boosterAmount = CoreData.instance.beginBombBreaker;
                    tick = tick3;
                    add = add3;
                    number = number3;
				avaialbe3 = (StageLoader.instance.Stage < Configuration.instance.beginBombBreakerLevel) ? false : true;
                    avaialbe = avaialbe3;
                    booster = booster3;
                    locked = locked3;
                    lockedText = lockedText3;
                    break;
            }

            if (avaialbe == true)
            {
                if (boosterAmount > 0)
                {
                    number.text = boosterAmount.ToString();
                    add.gameObject.SetActive(false);
                    tick.gameObject.SetActive(false);
                }
                else
                {
                    number.text = "0";
                    add.gameObject.SetActive(true);
                    tick.gameObject.SetActive(false);
                }
            }
            else
            {
                number.text = "0";
                number.gameObject.transform.parent.gameObject.SetActive(false);
                add.gameObject.SetActive(false);
                tick.gameObject.SetActive(false);
                booster.gameObject.SetActive(false);
                locked.SetActive(true);

                switch (i)
                {
                    case 1:
                        lockedText.text = "Require\nLevel " + Configuration.instance.beginFiveMovesLevel;
                        break;
                    case 2:
                        lockedText.text = "Require\nLevel " + Configuration.instance.beginRainbowLevel;
                        break;
                    case 3:
                        lockedText.text = "Require\nLevel " + Configuration.instance.beginBombBreakerLevel;
                        break;
                }
            }
        }

    }

	public void PlayButtonClick()
    {
        SFXManager.instance.ButtonClickAudio();

        // if enough life
		if (Configuration.instance.life > 0) {
			// reduce life
			GameObject.Find ("LifeBar").GetComponent<Life> ().ReduceLife (1);

			// change scene
			transition.PerformTransition ();
		} else {
		
			GameObject.Find("MapScene").GetComponent<MapScene>().LifeButtonClick();

		}
    }

    public void ButtonClickAudio()
    {
        SFXManager.instance.ButtonClickAudio();
    }

    public void BeginBoosterClick(int booster)
    {
        var avaiable = false;

        switch (booster)
        {
            case 1:
                avaiable = avaialbe1;
                break;
            case 2:
                avaiable = avaialbe2;
                break;
            case 3:
                avaiable = avaialbe3;
                break;
        }

        if (avaiable == false)
        {            
            return;
        }

        // Help
		if (StageLoader.instance.Stage == 10)
        {
            if (Help.instance.step == 1)
            {
                Help.instance.SelfDisactive();
            }
        }

		if (StageLoader.instance.Stage == 20)
        {
            if (Help.instance.step == 1)
            {
                Help.instance.SelfDisactive();
            }
        }

		if (StageLoader.instance.Stage == 23)
        {
            if (Help.instance.step == 1)
            {
                Help.instance.SelfDisactive();
            }
        }

        SFXManager.instance.ButtonClickAudio();

        int number = 0;

        switch (booster)
        {
            case 1:
                number = CoreData.instance.beginFiveMoves;
                break;
            case 2:
                number = CoreData.instance.beginRainbow;
                break;
            case 3:
                number = CoreData.instance.beginBombBreaker;
                break;
        }

        if (number > 0)
        {
            switch (booster)
            {
                case 1:
                    if (Configuration.instance.beginFiveMoves == false)
                    {
                        tick1.gameObject.SetActive(true);
                        number1.gameObject.SetActive(false);
                        Configuration.instance.beginFiveMoves = true;
                    }
                    else
                    {
                        tick1.gameObject.SetActive(false);
                        number1.gameObject.SetActive(true);
                        Configuration.instance.beginFiveMoves = false;
                    }
                    break;
                case 2:
                    if (Configuration.instance.beginRainbow == false)
                    {
                        tick2.gameObject.SetActive(true);
                        number2.gameObject.SetActive(false);
                        Configuration.instance.beginRainbow = true;
                    }
                    else
                    {
                        tick2.gameObject.SetActive(false);
                        number2.gameObject.SetActive(true);
                        Configuration.instance.beginRainbow = false;
                    }                    
                    break;
                case 3:
                    if (Configuration.instance.beginBombBreaker == false)
                    {
                        tick3.gameObject.SetActive(true);
                        number3.gameObject.SetActive(false);
                        Configuration.instance.beginBombBreaker = true;
                    }
                    else
                    {
                        tick3.gameObject.SetActive(false);
                        number3.gameObject.SetActive(true);
                        Configuration.instance.beginBombBreaker = false;
                    }                    
                    break;
            }
        }
        else
        {
            switch (booster)
            {
                case 1:
                    beginBooster1Popup.OpenPopup();
                    break;
                case 2:
                    beginBooster2Popup.OpenPopup();
                    break;
                case 3:
                    beginBooster3Popup.OpenPopup();
                    break;
            }
        }
    }
}
