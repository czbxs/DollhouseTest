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
using UnityEngine.UI;

public class UIScrollContent : MonoBehaviour 
{
    public List<RawImage> images = new List<RawImage>();

    /*
     * This function auto set the Viewport content size base on the number of the background
     */
	void Start () 
    {
        float height = 0;

	    foreach (var image in images)
        {
            RectTransform rt = image.rectTransform;

            height += rt.rect.height;
        }

        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector3(720f, height + 400f, 0);
	}
}
