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

public class UILosePopup : MonoBehaviour 
{
    public SceneTransition toMap;
    public Text coinText;
    public Text skipCost;

    public PopupOpener shopPopup;

	void Start () 
    {
        coinText.text = CoreData.instance.GetPlayerCoin().ToString();
        skipCost.text = Configuration.instance.skipLevelCost.ToString();
	}

    public void ExitButtonClick()
    {
        SFXManager.instance.ButtonClickAudio();

        toMap.PerformTransition();
        //AdMobAdManager.instance.ShowInterstitialAd();

    }

    public void ReplayButtonClick()
    {
        SFXManager.instance.ButtonClickAudio();

		Configuration.instance.autoPopup = StageLoader.instance.Stage;

        toMap.PerformTransition();
        //AdMobAdManager.instance.ShowInterstitialAd();
    }

    public void SkipButtonClick()
    {
        SFXManager.instance.ButtonClickAudio();

        var cost = Configuration.instance.skipLevelCost;

        // enough coin
        if (cost <= CoreData.instance.playerCoin)
        {
            SFXManager.instance.CoinPayAudio();

            // reduce coin
            CoreData.instance.SavePlayerCoin(CoreData.instance.playerCoin - cost);
            
			var board = GameObject.Find("Board").GetComponent<itemGrid>();

            if (board)
            {
                // save info
                board.SaveLevelInfo();
            }

            // go to map with auto popup of next level
			Configuration.instance.autoPopup = StageLoader.instance.Stage + 1;

            toMap.PerformTransition();
        }
        else
        {
            shopPopup.OpenPopup();
        }
    }

    public void KeepButtonClick()
    {

        //TODO ads
        //AdMobAdManager.instance.ShowInterstitialAd();

        // close the popup
        var popup = GameObject.Find("LosePopup(Clone)");

		if (popup)
		{
			popup.GetComponent<Popup>().Close();
		}
        
    }
}
