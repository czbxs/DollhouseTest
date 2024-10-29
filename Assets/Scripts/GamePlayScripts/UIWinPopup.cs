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

public class UIWinPopup : MonoBehaviour 
{
    public Text levelText;
    public Text scoreText;
    public Text bonusText;
    public Image doll;
    public Image star1;
    public Image star2;
    public Image star3;
    public Text buttonText;

	void Start () 
    {
		var board = GameObject.Find("Board").GetComponent<itemGrid>();

        var star = board.star;

		levelText.text = "Level " + StageLoader.instance.Stage.ToString();

//		AdmobSetting.instance.showinterstitial ();

        star1.gameObject.SetActive(false);
        star2.gameObject.SetActive(false);
        star3.gameObject.SetActive(false);

        // start coroutine to show stars
        StartCoroutine(ShowStars());

        // hide the button
        buttonText.gameObject.transform.parent.gameObject.SetActive(false);

        if (star == 1)
        {
            bonusText.text = Configuration.instance.bonus1Star.ToString();
        }
        else if (star == 2)
        {
            bonusText.text = Configuration.instance.bonus2Star.ToString();
        }
        else if (star == 3)
        {
            bonusText.text = Configuration.instance.bonus3Star.ToString();
        }
        else
        {
            bonusText.text = "0";
        }

        scoreText.text = "Score: " + board.score.ToString();

		var name = "doll_" + StageLoader.instance.doll + "_4";
//		doll.sprite = Resources.Load<Sprite>(Configuration.Doll(name));

		if (StageLoader.instance.Stage == Configuration.instance.maxLevel)
        {
            buttonText.text = "Close";
        }

        Configuration.instance.life += 1;

        if (Configuration.instance.life > Configuration.instance.maxLife)
        {
            Configuration.instance.life = Configuration.instance.maxLife;
        }
	}

    public void MapAutoPopup()
    {
		Configuration.instance.autoPopup = StageLoader.instance.Stage + 1;
    }

    IEnumerator ShowStars()
    {
        yield return new WaitForSeconds(1f);

		var board = GameObject.Find("Board").GetComponent<itemGrid>();
        var star = board.star;

        GameObject explosion1;
        GameObject explosion2;
        GameObject explosion3;

        switch (star)
        {
            case 1:
                star1.gameObject.SetActive(true);
                SFXManager.instance.Star1Audio();
                explosion1 = Instantiate(Resources.Load(Configuration.StarExplode()) as GameObject, transform.position, Quaternion.identity) as GameObject;
                explosion1.transform.SetParent(star1.gameObject.transform, false);

                star2.gameObject.SetActive(false);
                star3.gameObject.SetActive(false);
                break;
            case 2:
                star1.gameObject.SetActive(true);
                SFXManager.instance.Star1Audio();
                explosion1 = Instantiate(Resources.Load(Configuration.StarExplode()) as GameObject, transform.position, Quaternion.identity) as GameObject;
                explosion1.transform.SetParent(star1.gameObject.transform, false);

                yield return new WaitForSeconds(0.5f);

                star2.gameObject.SetActive(true);
                SFXManager.instance.Star2Audio();
                explosion2 = Instantiate(Resources.Load(Configuration.StarExplode()) as GameObject, transform.position, Quaternion.identity) as GameObject;
                explosion2.transform.SetParent(star2.gameObject.transform, false);

                star3.gameObject.SetActive(false);
                break;
            case 3:
                star1.gameObject.SetActive(true);
                SFXManager.instance.Star1Audio();
                explosion1 = Instantiate(Resources.Load(Configuration.StarExplode()) as GameObject, transform.position, Quaternion.identity) as GameObject;
                explosion1.transform.SetParent(star1.gameObject.transform, false);

                yield return new WaitForSeconds(0.5f);

                star2.gameObject.SetActive(true);
                SFXManager.instance.Star2Audio();
                explosion2 = Instantiate(Resources.Load(Configuration.StarExplode()) as GameObject, transform.position, Quaternion.identity) as GameObject;
                explosion2.transform.SetParent(star2.gameObject.transform, false);

                yield return new WaitForSeconds(0.5f);

                star3.gameObject.SetActive(true);
                SFXManager.instance.Star3Audio();
                explosion3 = Instantiate(Resources.Load(Configuration.StarExplode()) as GameObject, transform.position, Quaternion.identity) as GameObject;
                explosion3.transform.SetParent(star3.gameObject.transform, false);
                break;
            default:
                star1.gameObject.SetActive(false);
                star2.gameObject.SetActive(false);
                star3.gameObject.SetActive(false);
                break;
        }

        yield return new WaitForSeconds(1f);

//        board.ShowAds();

        yield return new WaitForSeconds(1f);

        buttonText.gameObject.transform.parent.gameObject.SetActive(true);
    }
}
