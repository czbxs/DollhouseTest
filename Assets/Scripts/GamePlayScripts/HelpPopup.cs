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

public class HelpPopup : MonoBehaviour 
{
    public Image arrow;

    void Start()
    {
        if (arrow != null)
        {
			if (StageLoader.instance.Stage == 1 ||
				StageLoader.instance.Stage == 2 ||
				StageLoader.instance.Stage == 3 ||
				StageLoader.instance.Stage == 4 ||
				StageLoader.instance.Stage == 5 ||
				StageLoader.instance.Stage == 6 ||
				StageLoader.instance.Stage == 7 ||
				StageLoader.instance.Stage == 10 ||
				StageLoader.instance.Stage == 12 ||
				StageLoader.instance.Stage == 15 ||
				StageLoader.instance.Stage == 18 ||
				StageLoader.instance.Stage == 20 ||
				StageLoader.instance.Stage == 23 ||
				StageLoader.instance.Stage == 25)
            {
                iTween.MoveBy(arrow.gameObject, iTween.Hash(
                    "y", -1,
                    "looptype", iTween.LoopType.loop,
                    "time", 1.5f
                ));
            }            
        }

		if (StageLoader.instance.Stage == 25 && Help.instance.step ==2)
        {
            if (arrow != null)
            {
                int index = arrow.gameObject.transform.GetSiblingIndex();
                GameObject nextArrow = arrow.gameObject.transform.parent.GetChild(index + 1).gameObject;
                if (nextArrow != null)
                {
                    iTween.MoveBy(nextArrow, iTween.Hash(
                        "y", -1,
                        "looptype", iTween.LoopType.loop,
                        "time", 1.5f
                    ));
                }
            }
            
        }
    }

    #region Next

    public void NextButtonDown()
    {
        Configuration.instance.touchIsSwallowed = true;
    }

    public void NextButtonUp()
    {
        Configuration.instance.touchIsSwallowed = false;

		if (StageLoader.instance.Stage == 1)
        {
            if (Help.instance.step == 1)
            {
                // show step 2                

                var prefab = Instantiate(Resources.Load(Configuration.Level1Step2())) as GameObject;
                prefab.name = "Level 1 Step 2";

                prefab.gameObject.transform.SetParent(gameObject.transform.parent.gameObject.transform);
                prefab.GetComponent<RectTransform>().localScale = Vector3.one;

                Help.instance.step = 2;
                Help.instance.current = prefab;

                // hide step 1
                gameObject.SetActive(false);
            }
        }
		else if (StageLoader.instance.Stage == 13)
        {
            if (Help.instance.step == 1)
            {
                // show step 2                

                var prefab = Instantiate(Resources.Load(Configuration.Level13Step2())) as GameObject;
                prefab.name = "Level 13 Step 2";

                prefab.gameObject.transform.SetParent(gameObject.transform.parent.gameObject.transform);
                prefab.GetComponent<RectTransform>().localScale = Vector3.one;

                Help.instance.step = 2;
                Help.instance.current = prefab;

                // hide step 1
                gameObject.SetActive(false);
            }
        }
    }

    #endregion Next

    #region Skip

    public void SkipButtonDown()
    {
        Configuration.instance.touchIsSwallowed = true;
    }

    public void SkipButtonUp()
    {
        Configuration.instance.touchIsSwallowed = false;
        
        Help.instance.step = 0;

        Help.instance.SelfDisactive();
    }

    #endregion Skip

    #region Mask

    public void MaskDown()
    {
        Configuration.instance.touchIsSwallowed = true;
    }

    public void MaskUp()
    {
        Configuration.instance.touchIsSwallowed = false;
    }

    #endregion
}
