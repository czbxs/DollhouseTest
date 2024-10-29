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

public class UI_Booster : MonoBehaviour 
{
    public BOOSTER_TYPE booster;
    public Text cost1;
    public Text cost2;

    public bool clicking;

    public PopupOpener shopPopup;

	void Start () 
    {
	    switch (booster)
        {
            case BOOSTER_TYPE.BEGIN_FIVE_MOVES:
                cost1.text = Configuration.instance.beginFiveMovesCost1.ToString();
                cost2.text = Configuration.instance.beginFiveMovesCost2.ToString();
                break;
            case BOOSTER_TYPE.BEGIN_RAINBOW_BREAKER:
                cost1.text = Configuration.instance.beginRainbowCost1.ToString();
                cost2.text = Configuration.instance.beginRainbowCost2.ToString();
                break;
            case BOOSTER_TYPE.BEGIN_BOMB_BREAKER:
                cost1.text = Configuration.instance.beginBombBreakerCost1.ToString();
                cost2.text = Configuration.instance.beginBombBreakerCost2.ToString();
                break;

            case BOOSTER_TYPE.SINGLE_BREAKER:
                cost1.text = Configuration.instance.singleBreakerCost1.ToString();
                cost2.text = Configuration.instance.singleBreakerCost2.ToString();
                break;
            case BOOSTER_TYPE.ROW_BREAKER:
                cost1.text = Configuration.instance.rowBreakerCost1.ToString();
                cost2.text = Configuration.instance.rowBreakerCost2.ToString();
                break;
            case BOOSTER_TYPE.COLUMN_BREAKER:
                cost1.text = Configuration.instance.columnBreakerCost1.ToString();
                cost2.text = Configuration.instance.columnBreakerCost2.ToString();
                break;
            case BOOSTER_TYPE.RAINBOW_BREAKER:
                cost1.text = Configuration.instance.rainbowBreakerCost1.ToString();
                cost2.text = Configuration.instance.rainbowBreakerCost2.ToString();
                break;
            case BOOSTER_TYPE.OVEN_BREAKER:
                cost1.text = Configuration.instance.ovenBreakerCost1.ToString();
                cost2.text = Configuration.instance.ovenBreakerCost2.ToString();
                break;
        }
	}

    public void BuyButtonClick(int package)
    {
        // avoid multiple click
        if (clicking == true) return;
        
        clicking = true;
        StartCoroutine(ResetButtonClick());

        int cost = 0;
        int amount = 0;

        if (package == 1)
        {
            switch (booster)
            {
                case BOOSTER_TYPE.BEGIN_FIVE_MOVES:
                    cost = Configuration.instance.beginFiveMovesCost1;
                    amount = Configuration.instance.package1Amount;
                    break;
                case BOOSTER_TYPE.BEGIN_RAINBOW_BREAKER:
                    cost = Configuration.instance.beginRainbowCost1;
                    amount = Configuration.instance.package1Amount;
                    break;
                case BOOSTER_TYPE.BEGIN_BOMB_BREAKER:
                    cost = Configuration.instance.beginBombBreakerCost1;
                    amount = Configuration.instance.package1Amount;
                    break;

                case BOOSTER_TYPE.SINGLE_BREAKER:
                    cost = Configuration.instance.singleBreakerCost1;
                    amount = Configuration.instance.package1Amount;
                    break;
                case BOOSTER_TYPE.ROW_BREAKER:
                    cost = Configuration.instance.rowBreakerCost1;
                    amount = Configuration.instance.package1Amount;
                    break;
                case BOOSTER_TYPE.COLUMN_BREAKER:
                    cost = Configuration.instance.columnBreakerCost1;
                    amount = Configuration.instance.package1Amount;
                    break;
                case BOOSTER_TYPE.RAINBOW_BREAKER:
                    cost = Configuration.instance.rainbowBreakerCost1;
                    amount = Configuration.instance.package1Amount;
                    break;
                case BOOSTER_TYPE.OVEN_BREAKER:
                    cost = Configuration.instance.ovenBreakerCost1;
                    amount = Configuration.instance.package1Amount;
                    break;
            }
        }
        else if (package == 2)
        {
            switch (booster)
            {
                case BOOSTER_TYPE.BEGIN_FIVE_MOVES:
                    cost = Configuration.instance.beginFiveMovesCost2;
                    amount = Configuration.instance.package2Amount;
                    break;
                case BOOSTER_TYPE.BEGIN_RAINBOW_BREAKER:
                    cost = Configuration.instance.beginRainbowCost2;
                    amount = Configuration.instance.package2Amount;
                    break;
                case BOOSTER_TYPE.BEGIN_BOMB_BREAKER:
                    cost = Configuration.instance.beginBombBreakerCost2;
                    amount = Configuration.instance.package2Amount;
                    break;

                case BOOSTER_TYPE.SINGLE_BREAKER:
                    cost = Configuration.instance.singleBreakerCost2;
                    amount = Configuration.instance.package2Amount;
                    break;
                case BOOSTER_TYPE.ROW_BREAKER:
                    cost = Configuration.instance.rowBreakerCost2;
                    amount = Configuration.instance.package2Amount;
                    break;
                case BOOSTER_TYPE.COLUMN_BREAKER:
                    cost = Configuration.instance.columnBreakerCost2;
                    amount = Configuration.instance.package2Amount;
                    break;
                case BOOSTER_TYPE.RAINBOW_BREAKER:
                    cost = Configuration.instance.rainbowBreakerCost2;
                    amount = Configuration.instance.package2Amount;
                    break;
                case BOOSTER_TYPE.OVEN_BREAKER:
                    cost = Configuration.instance.ovenBreakerCost2;
                    amount = Configuration.instance.package2Amount;
                    break;
            }
        }
        
        // enough coin
        if (cost <= CoreData.instance.GetPlayerCoin())
        {
            // reduce coin
            CoreData.instance.SavePlayerCoin(CoreData.instance.GetPlayerCoin() - cost);

            // play sound
            SFXManager.instance.CoinPayAudio();

            // add booster amount
            switch (booster)
            {
                case BOOSTER_TYPE.BEGIN_FIVE_MOVES:
                    CoreData.instance.SaveBeginFiveMoves(amount);
                    break;
                case BOOSTER_TYPE.BEGIN_RAINBOW_BREAKER:
                    CoreData.instance.SaveBeginRainbow(amount);
                    break;
                case BOOSTER_TYPE.BEGIN_BOMB_BREAKER:
                    CoreData.instance.SaveBeginBombBreaker(amount);
                    break;

                case BOOSTER_TYPE.SINGLE_BREAKER:
                    CoreData.instance.SaveSingleBreaker(amount);
                    break;
                case BOOSTER_TYPE.ROW_BREAKER:
                    CoreData.instance.SaveRowBreaker(amount);
                    break;
                case BOOSTER_TYPE.COLUMN_BREAKER:
                    CoreData.instance.SaveColumnBreaker(amount);
                    break;
                case BOOSTER_TYPE.RAINBOW_BREAKER:
                    CoreData.instance.SaveRainbowBreaker(amount);
                    break;
                case BOOSTER_TYPE.OVEN_BREAKER:
                    CoreData.instance.SaveOvenBreaker(amount);
                    break;
            }

            // begin booster
            if (booster == BOOSTER_TYPE.BEGIN_FIVE_MOVES || booster == BOOSTER_TYPE.BEGIN_RAINBOW_BREAKER || booster == BOOSTER_TYPE.BEGIN_BOMB_BREAKER)
            {
                // update level popup
                if (GameObject.Find("LevelPopup(Clone)"))
                {
                    var levelPopup = GameObject.Find("LevelPopup(Clone)") as GameObject;

                    switch (booster)
                    {
                        case BOOSTER_TYPE.BEGIN_FIVE_MOVES:
                            levelPopup.GetComponent<UI_Level>().number1.text = amount.ToString();
                            levelPopup.GetComponent<UI_Level>().add1.gameObject.SetActive(false);
                            levelPopup.GetComponent<UI_Level>().BeginBoosterClick(1);
                            break;
                        case BOOSTER_TYPE.BEGIN_RAINBOW_BREAKER:                            
                            levelPopup.GetComponent<UI_Level>().number2.text = amount.ToString();
                            levelPopup.GetComponent<UI_Level>().add2.gameObject.SetActive(false);
                            levelPopup.GetComponent<UI_Level>().BeginBoosterClick(2);
                            break;
                        case BOOSTER_TYPE.BEGIN_BOMB_BREAKER:                            
                            levelPopup.GetComponent<UI_Level>().number3.text = amount.ToString();
                            levelPopup.GetComponent<UI_Level>().add3.gameObject.SetActive(false);
                            levelPopup.GetComponent<UI_Level>().BeginBoosterClick(3);
                            break;
                    }
                }

                // close popup
                switch (booster)
                {
                    case BOOSTER_TYPE.BEGIN_FIVE_MOVES:
                        if (GameObject.Find("BeginBooster1Popup(Clone)"))
                        {
                            GameObject.Find("BeginBooster1Popup(Clone)").GetComponent<Popup>().Close();
                        }
                        break;
                    case BOOSTER_TYPE.BEGIN_RAINBOW_BREAKER:
                        if (GameObject.Find("BeginBooster2Popup(Clone)"))
                        {
                            GameObject.Find("BeginBooster2Popup(Clone)").GetComponent<Popup>().Close();
                        }
                        break;
                    case BOOSTER_TYPE.BEGIN_BOMB_BREAKER:
                        if (GameObject.Find("BeginBooster3Popup(Clone)"))
                        {
                            GameObject.Find("BeginBooster3Popup(Clone)").GetComponent<Popup>().Close();
                        }
                        break;
                }

                // update coin label
                GameObject.Find("MapScene").GetComponent<MapScene>().UpdateCoinAmountLabel();
            }
            // in game booster
            else
            {
                // update bottom bar
                switch (booster)
                {
                    case BOOSTER_TYPE.SINGLE_BREAKER:
                        // update amount
                        Booster.instance.singleAmount.text = amount.ToString();
                        // active booster
                        Booster.instance.ActiveBooster(BOOSTER_TYPE.SINGLE_BREAKER);
                        break;
                    case BOOSTER_TYPE.ROW_BREAKER:                        
                        Booster.instance.rowAmount.text = amount.ToString();
                        Booster.instance.ActiveBooster(BOOSTER_TYPE.ROW_BREAKER);
                        break;
                    case BOOSTER_TYPE.COLUMN_BREAKER:
                        Booster.instance.columnAmount.text = amount.ToString();
                        Booster.instance.ActiveBooster(BOOSTER_TYPE.COLUMN_BREAKER);
                        break;
                    case BOOSTER_TYPE.RAINBOW_BREAKER:
                        Booster.instance.rainbowAmount.text = amount.ToString();
                        Booster.instance.ActiveBooster(BOOSTER_TYPE.RAINBOW_BREAKER);
                        break;
                    case BOOSTER_TYPE.OVEN_BREAKER:
                        Booster.instance.ovenAmount.text = amount.ToString();
                        Booster.instance.ActiveBooster(BOOSTER_TYPE.OVEN_BREAKER);
                        break;
                }

                // close popup
                switch (booster)
                {
                    case BOOSTER_TYPE.SINGLE_BREAKER:
                        if (GameObject.Find("SingleBoosterPopup(Clone)"))
                        {
                            GameObject.Find("SingleBoosterPopup(Clone)").GetComponent<Popup>().Close();

						GameObject.Find("Board").GetComponent<itemGrid>().state = GAME_STATE.WAITING_USER_SWAP;
                        }
                        break;
                    case BOOSTER_TYPE.ROW_BREAKER:
                        if (GameObject.Find("RowBoosterPopup(Clone)"))
                        {
                            GameObject.Find("RowBoosterPopup(Clone)").GetComponent<Popup>().Close();

						GameObject.Find("Board").GetComponent<itemGrid>().state = GAME_STATE.WAITING_USER_SWAP;
                        }
                        break;
                    case BOOSTER_TYPE.COLUMN_BREAKER:
                        if (GameObject.Find("ColumnBoosterPopup(Clone)"))
                        {
                            GameObject.Find("ColumnBoosterPopup(Clone)").GetComponent<Popup>().Close();

						GameObject.Find("Board").GetComponent<itemGrid>().state = GAME_STATE.WAITING_USER_SWAP;
                        }
                        break;
                    case BOOSTER_TYPE.RAINBOW_BREAKER:
                        if (GameObject.Find("RainbowBoosterPopup(Clone)"))
                        {
                            GameObject.Find("RainbowBoosterPopup(Clone)").GetComponent<Popup>().Close();

						GameObject.Find("Board").GetComponent<itemGrid>().state = GAME_STATE.WAITING_USER_SWAP;
                        }
                        break;
                    case BOOSTER_TYPE.OVEN_BREAKER:
                        if (GameObject.Find("OvenBoosterPopup(Clone)"))
                        {
                            GameObject.Find("OvenBoosterPopup(Clone)").GetComponent<Popup>().Close();

						GameObject.Find("Board").GetComponent<itemGrid>().state = GAME_STATE.WAITING_USER_SWAP;
                        }
                        break;
                }
            }
        }
        // not enough coin
        else
        {
            // show shop popup
            shopPopup.OpenPopup();
        }
    }

    IEnumerator ResetButtonClick()
    {
        yield return new WaitForSeconds(1f);

        clicking = false;
    }

    public void ButtonClickAudio()
    {
        SFXManager.instance.ButtonClickAudio();
    }

    public void CloseButtonClick()
    {
        SFXManager.instance.ButtonClickAudio();

        // if booster is in game we re-set game state
		GameObject.Find("Board").GetComponent<itemGrid>().state = GAME_STATE.WAITING_USER_SWAP;
    }
}
