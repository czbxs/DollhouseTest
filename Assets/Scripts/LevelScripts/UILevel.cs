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

public class UILevel : MonoBehaviour 
{
    public int level;
    public MAP_LEVEL_STATUS status;
    public Image background;
    public Text number;
    public Image star1;
    public Image star2;
    public Image star3;
    public Sprite openedBackgroundSprite;
    public Sprite currentBackgroundSprite;
    public Sprite lockedBackgroundSprite;
    public Sprite starGoldSprite;
    public Sprite starGreySprite;
    public GameObject button;
    public PopupOpener levelPopup;

	void Start () 
    {

        level = transform.GetSiblingIndex();
        number.text = level.ToString();

        var openedLevel = CoreData.instance.GetOpendedLevel();

        if (openedLevel == level)
        {
            // current level
            status = MAP_LEVEL_STATUS.CURRENT;

            background.sprite = currentBackgroundSprite;

            if (level == Configuration.instance.maxLevel)
            {
                var star = CoreData.instance.GetLevelStar(level);

                switch (star)
                {
                    case 1:
                        star1.sprite = starGoldSprite;
                        star2.sprite = starGreySprite;
                        star3.sprite = starGreySprite;
                        break;
                    case 2:
                        star1.sprite = starGoldSprite;
                        star2.sprite = starGoldSprite;
                        star3.sprite = starGreySprite;
                        break;
                    case 3:
                        star1.sprite = starGoldSprite;
                        star2.sprite = starGoldSprite;
                        star3.sprite = starGoldSprite;
                        break;
                    default:
                        break;
                }
            }

			if (GameObject.Find("TargetPointer"))
            {
				var person = GameObject.Find("TargetPointer") as GameObject;

                person.transform.position = this.gameObject.transform.position + new Vector3(0, 1f, 0);

                person.transform.SetParent(this.gameObject.transform.parent.transform);

                iTween.MoveBy(person, iTween.Hash(
                    "y", 0.2f,
                    "looptype", iTween.LoopType.pingPong,
                    "easetype", iTween.EaseType.linear,
                    "time", 1f
                    ));
            }
        }
        else if (openedLevel > level)
//		else if (openedLevel < level)			
        {
            // opened level
            status = MAP_LEVEL_STATUS.OPENED;

            background.sprite = openedBackgroundSprite;

            var star = CoreData.instance.GetLevelStar(level);

            switch (star)
            {
                case 1:
                    star1.sprite = starGoldSprite;
                    star2.sprite = starGreySprite;
                    star3.sprite = starGreySprite;
                    break;
                case 2:
                    star1.sprite = starGoldSprite;
                    star2.sprite = starGoldSprite;
                    star3.sprite = starGreySprite;
                    break;
                case 3:
                    star1.sprite = starGoldSprite;
                    star2.sprite = starGoldSprite;
                    star3.sprite = starGoldSprite;
                    break;
                default:
                    break;
            }
        }
//        else if (openedLevel < level)
		else if (openedLevel > level)			
        {
            // locked level
            status = MAP_LEVEL_STATUS.LOCKED;

            background.sprite = lockedBackgroundSprite;

            button.GetComponent<Animator>().enabled = false;
            button.GetComponent<AnimatedButton>().enabled = false;
            
            star1.gameObject.SetActive(false);
            star2.gameObject.SetActive(false);
            star3.gameObject.SetActive(false);
        }
	}

    public void LevelClick()
    {
        SFXManager.instance.ButtonClickAudio();

        if (status != MAP_LEVEL_STATUS.LOCKED)
        {
			StageLoader.instance.Stage = level;
            StageLoader.instance.LoadLevel();
            levelPopup.OpenPopup();

//            ShowHelp(level);
        }
    }

    public void ShowHelp(int level)
    {
        StartCoroutine(StartShowHelp(level));
    }

    IEnumerator StartShowHelp(int level)
    {
        yield return new WaitForSeconds(0.5f);

        Help.instance.help = true;
        Help.instance.ShowOnMap();
    }
}
