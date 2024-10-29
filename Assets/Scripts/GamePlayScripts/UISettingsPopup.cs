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

public class UISettingsPopup : MonoBehaviour 
{
    public SceneTransition toMap;
    public void GoToMap()
    {
        SFXManager.instance.ButtonClickAudio();

        toMap.PerformTransition();
    }

    public void Replay()
    {
        SFXManager.instance.ButtonClickAudio();

		Configuration.instance.autoPopup = StageLoader.instance.Stage;

        toMap.PerformTransition();
    }
	
	public void ButtonClickAudio()
    {
        SFXManager.instance.ButtonClickAudio();
    }

    public void CloseButtonClick()
    {
        SFXManager.instance.ButtonClickAudio();
		PlayerPrefs.SetInt ("canvas", 1);
        if (GameObject.Find("Board"))
        {
			GameObject.Find("Board").GetComponent<itemGrid>().state = GAME_STATE.WAITING_USER_SWAP;
        }
    }
}
