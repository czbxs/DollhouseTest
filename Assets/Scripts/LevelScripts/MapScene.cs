using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using GooglePlayGames;
using UnityEngine.SocialPlatforms;
//using AppAdvisory.social;

public class MapScene : MonoBehaviour 
{
    public PopupOpener levelPopup;
    public Text coinText;
    public Text starText;
    public PopupOpener shopPopup;
    public GameObject levels;
    public GameObject scrollContent;
    public PopupOpener lifePopup;

    float canvasHeight;
	public GameObject _avatar;
	private Texture def_Texture;


	void Awake()
	{
		def_Texture = _avatar.GetComponent<MeshRenderer> ().material.mainTexture;
	}

	void Start () 
    {

//		GooglePlayManager.instance.LoadLeaderBoards ();
        canvasHeight = ((float)Screen.height / (float)Screen.width) * 720f;

        coinText.text = CoreData.instance.GetPlayerCoin().ToString();

        if (Configuration.instance.autoPopup > 0 && Configuration.instance.autoPopup <= Configuration.instance.maxLevel)
        {
            StartCoroutine(OpenLevelPopup());
        }

        var maxStar = CoreData.instance.GetOpendedLevel() * 3;

        int star = 0;

        for (int i = 1; i <= CoreData.instance.GetOpendedLevel(); i++)
        {
            star += CoreData.instance.GetLevelStar(i);
        }

        starText.text = star.ToString() + "/" + maxStar.ToString();

        var currentPosition = Vector3.zero;

		if (StageLoader.instance.Stage == 0)
        {
            currentPosition = TargetPosition();
        }
        else
        {
			currentPosition = levels.transform.GetChild(StageLoader.instance.Stage).GetComponent<RectTransform>().localPosition;
        }

        scrollContent.GetComponent<RectTransform>().localPosition = new Vector3(0, canvasHeight / 2 - currentPosition.y, 0);
	}

    void Update()
    {
        #region Scroll

        var position = canvasHeight / 2 - TargetPosition().y;

        var y = scrollContent.GetComponent<RectTransform>().localPosition.y;


        #endregion

        #region Button

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // close Level popup
            if (GameObject.Find("LevelPopup(Clone)"))
            {
                GameObject.Find("LevelPopup(Clone)").GetComponent<Popup>().Close();

                // if help popup is open then close it
                if (GameObject.Find("Help").transform.GetChild(0))
                {
                    GameObject.Find("Help").transform.GetChild(0).gameObject.SetActive(false);
                }
                
            }
            else
            {
                Application.Quit();
            }
        }

        #endregion
    }


	public void ButtonClickAudio()
    {
        SFXManager.instance.ButtonClickAudio();
    }

    IEnumerator OpenLevelPopup()
    {
        yield return new WaitForSeconds(0.5f);

		StageLoader.instance.Stage = Configuration.instance.autoPopup;
        StageLoader.instance.LoadLevel();

        Configuration.instance.autoPopup = 0;

        levelPopup.OpenPopup();

        // show help

        yield return new WaitForSeconds(0.5f);

        Help.instance.help = true;
        Help.instance.ShowOnMap();
    }

    public void CoinButtonClick()
    {
        if (!GameObject.Find("ShopPopupMap(Clone)"))
        {
            shopPopup.OpenPopup();
        }
    }

	public void LifeButtonClick()
	{
		//print ("Show Life Pop Up");

        if (!GameObject.Find("LifePopup(Clone)") && !GameObject.Find("ShopPopupMap(Clone)"))
        {
            lifePopup.OpenPopup();
        }
	}

    public void FoundTargetButtonClick()
    {
        SFXManager.instance.ButtonClickAudio();

        StartCoroutine(ScrollContent(new Vector3(0, canvasHeight / 2 - TargetPosition().y, 0)));
    }

    IEnumerator ScrollContent(Vector3 target)
    {
        if (target.y > 0) target.y = 0;

        var from = scrollContent.GetComponent<RectTransform>().localPosition;
        float step = Time.fixedDeltaTime;
        float t = 0;

        while (t <= 1.0f)
        {
            t += step;
            scrollContent.GetComponent<RectTransform>().localPosition = Vector3.Lerp(from, target, t);
            yield return new WaitForFixedUpdate();
        }

        scrollContent.GetComponent<RectTransform>().localPosition = target;
    }

    Vector3 TargetPosition()
    {
        var currentPosition = Vector3.zero;

        foreach (Transform level in levels.transform)
        {
            if (level.gameObject.GetComponent<UILevel>().status == MAP_LEVEL_STATUS.CURRENT)
            {
                currentPosition = level.gameObject.GetComponent<RectTransform>().localPosition;
                break;
            }
        }

        return currentPosition;
    }

    public void UpdateCoinAmountLabel()
    {
        coinText.text = CoreData.instance.GetPlayerCoin().ToString();
    }


}
