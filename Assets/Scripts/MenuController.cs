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

public class MenuController : MonoBehaviour {


	public GameObject menucanvas;
	public GameObject mapCanvas;
	public GameObject AdditionalCanvas;

	void Start(){

		PlayerPrefs.GetInt ("canvas");
		Debug.Log (PlayerPrefs.GetInt ("canvas"));
		if (PlayerPrefs.GetInt ("canvas") == 1) {


			menucanvas.SetActive (false);

			mapCanvas.SetActive (true);
			AdditionalCanvas.SetActive (true);
		}
	}

	void Update(){
	

	}

	public void playButton()
	{
		menucanvas.SetActive (false);

		mapCanvas.SetActive (true);
		AdditionalCanvas.SetActive (true);

	}
}
