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


public class LifePopup : MonoBehaviour 
{
    public Text lifeRemain;
    public Text recoveryCost;
    public GameObject recoveryButton;

    int cost;

	// Use this for initialization
	void Start () 
    {
        if (Configuration.instance.life < Configuration.instance.maxLife)
        {
            lifeRemain.text = "Life: " + Configuration.instance.life.ToString() + "/" + Configuration.instance.maxLife.ToString();

            cost = Configuration.instance.recoveryCostPerLife * (Configuration.instance.maxLife - Configuration.instance.life);

            recoveryCost.text = cost.ToString();;
        }
        else
        {
            lifeRemain.text = "Life: " + Configuration.instance.maxLife.ToString() + "/" + Configuration.instance.maxLife.ToString();
            recoveryButton.SetActive(false);
            recoveryCost.gameObject.transform.parent.gameObject.SetActive(false);
        }
	}
	
    public void ButtonClickAudio()
    {
        SFXManager.instance.ButtonClickAudio();
    }

    public void RecoveryButtonClick()
    {
		//
        //TODO ads
		//GameObject.Find("Video Ads").GetComponent<chartboostVideoAds>().showCBRewardedVid();
      
    }
}
