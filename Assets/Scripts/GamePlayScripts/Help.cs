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

public class Help : MonoBehaviour 
{
    public static Help instance = null;

    [Header("Variables")]
    public int step;
    public GameObject current;

    [Header("Check")]
    public bool help;
    public bool onMap;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

	void Start () 
    {
        // Map scene
        if (onMap == true)
        {
            
        }
        // Play scene
        else
        {
            // show help
            if (StageLoader.instance.Stage == 1 || // match 3
                StageLoader.instance.Stage == 2 || // match 4
				StageLoader.instance.Stage == 3 || // T and L shapes
				StageLoader.instance.Stage == 4 || // match 5
				StageLoader.instance.Stage == 5 || // match 2 special treats
				StageLoader.instance.Stage == 6 || // Gingerbread Man
				StageLoader.instance.Stage == 7 || // Lollipop
				StageLoader.instance.Stage == 9 || // Waffle
				StageLoader.instance.Stage == 12 || // Rolling Pin
				StageLoader.instance.Stage == 13 || // Collectible
				StageLoader.instance.Stage == 15 || // Pastry Bag
				StageLoader.instance.Stage == 16 || // Marshmallow
				StageLoader.instance.Stage == 18 || // Magic Cookie
				StageLoader.instance.Stage == 25 || // Oven Mitt
				StageLoader.instance.Stage == 31 || // Chocolate
				StageLoader.instance.Stage == 61 || // Cage
				StageLoader.instance.Stage == 76) // Rock Candy 
            {
                help = true;
            }
            else
            {
                SelfDisactive();
            }
        }
    }

    public void Show()
    {
        // don't show help when level is passed
		if (CoreData.instance.GetOpendedLevel() > StageLoader.instance.Stage)
        {
            SelfDisactive();
            return;
        }

        GameObject prefab = null;

		if (StageLoader.instance.Stage == 1)
        {
            if (step == 0)
            {
                prefab = Instantiate(Resources.Load(Configuration.Level1Step1())) as GameObject;
                prefab.name = "Level 1 Step 1";

                step = 1;
            }
            else if (step == 2)
            {
                prefab = Instantiate(Resources.Load(Configuration.Level1Step3())) as GameObject;
                prefab.name = "Level 1 Step 3";

                // finish
                step = 3;
            }
        }
		else if (StageLoader.instance.Stage == 2)
        {
            if (step == 0)
            {
                prefab = Instantiate(Resources.Load(Configuration.Level2Step1())) as GameObject;
                prefab.name = "Level 2 Step 1";

                step = 1;
            }
            else if (step == 1)
            {
                prefab = Instantiate(Resources.Load(Configuration.Level2Step2())) as GameObject;
                prefab.name = "Level 2 Step 2";

                step = 2;
            }
            else if (step == 2)
            {
                prefab = Instantiate(Resources.Load(Configuration.Level2Step3())) as GameObject;
                prefab.name = "Level 2 Step 3";

                step = 3;
            }
        }
		else if (StageLoader.instance.Stage == 3)
        {
            if (step == 0)
            {
                prefab = Instantiate(Resources.Load(Configuration.Level3Step1())) as GameObject;
                prefab.name = "Level 3 Step 1";

                step = 1;
            }
            else if (step == 1)
            {
                prefab = Instantiate(Resources.Load(Configuration.Level3Step2())) as GameObject;
                prefab.name = "Level 3 Step 2";

                step = 2;
            }
            else if (step == 2)
            {
                prefab = Instantiate(Resources.Load(Configuration.Level3Step3())) as GameObject;
                prefab.name = "Level 3 Step 3";

                step = 3;
            }
            else if (step == 3)
            {
                prefab = Instantiate(Resources.Load(Configuration.Level3Step4())) as GameObject;
                prefab.name = "Level 3 Step 4";

                step = 4;
            }
            else if (step == 4)
            {
                prefab = Instantiate(Resources.Load(Configuration.Level3Step5())) as GameObject;
                prefab.name = "Level 3 Step 5";

                step = 5;
            }
        }
		else if (StageLoader.instance.Stage == 4)
        {
            if (step == 0)
            {
                prefab = Instantiate(Resources.Load(Configuration.Level4Step1())) as GameObject;
                prefab.name = "Level 4 Step 1";

                step = 1;
            }
            else if (step == 1)
            {
                prefab = Instantiate(Resources.Load(Configuration.Level4Step2())) as GameObject;
                prefab.name = "Level 4 Step 2";

                step = 2;
            }
            else if (step == 2)
            {
                prefab = Instantiate(Resources.Load(Configuration.Level4Step3())) as GameObject;
                prefab.name = "Level 4 Step 3";

                step = 3;
            }
        }
		else if (StageLoader.instance.Stage == 5)
        {
            if (step == 0)
            {
                prefab = Instantiate(Resources.Load(Configuration.Level5Step1())) as GameObject;
                prefab.name = "Level 5 Step 1";

                step = 1;
            }
            else if (step == 1)
            {
                prefab = Instantiate(Resources.Load(Configuration.Level5Step2())) as GameObject;
                prefab.name = "Level 5 Step 2";

                step = 2;
            }
        }
		else if (StageLoader.instance.Stage == 6)
        {
            if (step == 0)
            {
                prefab = Instantiate(Resources.Load(Configuration.Level6Step1())) as GameObject;
                prefab.name = "Level 6 Step 1";

                step = 1;
            }
        }
		else if (StageLoader.instance.Stage == 7)
        {
            if (step == 0)
            {
                prefab = Instantiate(Resources.Load(Configuration.Level7Step1())) as GameObject;
                prefab.name = "Level 7 Step 1";

                step = 1;
            }
        }
		else if (StageLoader.instance.Stage == 9)
        {
            if (step == 0)
            {
                prefab = Instantiate(Resources.Load(Configuration.Level9Step1())) as GameObject;
                prefab.name = "Level 9 Step 1";

                step = 1;
            }
        }
		else if (StageLoader.instance.Stage == 12)
        {
            if (step == 0)
            {
                prefab = Instantiate(Resources.Load(Configuration.Level12Step1())) as GameObject;
                prefab.name = "Level 12 Step 1";

                step = 1;
            }
        }
		else if (StageLoader.instance.Stage == 13)
        {
            if (step == 0)
            {
                prefab = Instantiate(Resources.Load(Configuration.Level13Step1())) as GameObject;
                prefab.name = "Level 13 Step 1";

                step = 1;
            }
        }
		else if (StageLoader.instance.Stage == 15)
        {
            if (step == 0)
            {
                prefab = Instantiate(Resources.Load(Configuration.Level15Step1())) as GameObject;
                prefab.name = "Level 15 Step 1";

                step = 1;
            }
        }
		else if (StageLoader.instance.Stage == 16)
        {
            if (step == 0)
            {
                prefab = Instantiate(Resources.Load(Configuration.Level16Step1())) as GameObject;
                prefab.name = "Level 16 Step 1";

                step = 1;
            }
        }
		else if (StageLoader.instance.Stage == 18)
        {
            if (step == 0)
            {
                prefab = Instantiate(Resources.Load(Configuration.Level18Step1())) as GameObject;
                prefab.name = "Level 18 Step 1";

                step = 1;
            }
        }
		else if (StageLoader.instance.Stage == 25)
        {
            if (step == 0)
            {
                prefab = Instantiate(Resources.Load(Configuration.Level25Step1())) as GameObject;
                prefab.name = "Level 25 Step 1";

                step = 1;
            }
        }
		else if (StageLoader.instance.Stage == 31)
        {
            if (step == 0)
            {
                prefab = Instantiate(Resources.Load(Configuration.Level31Step1())) as GameObject;
                prefab.name = "Level 31 Step 1";

                step = 1;
            }
        }
		else if (StageLoader.instance.Stage == 61)
        {
            if (step == 0)
            {
                prefab = Instantiate(Resources.Load(Configuration.Level61Step1())) as GameObject;
                prefab.name = "Level 61 Step 1";

                step = 1;
            }
        }
		else if (StageLoader.instance.Stage == 76)
        {
            if (step == 0)
            {
                prefab = Instantiate(Resources.Load(Configuration.Level76Step1())) as GameObject;
                prefab.name = "Level 76 Step 1";

                step = 1;
            }
        }

        if (prefab != null)
        {
            prefab.gameObject.transform.SetParent(gameObject.transform);
            prefab.GetComponent<RectTransform>().localScale = Vector3.one;

            current = prefab;
        }        
    }

    public void ShowOnMap()
    {
        // don't show help when level is passed
		if (CoreData.instance.GetOpendedLevel() > StageLoader.instance.Stage)
        {
            return;
        }

        GameObject prefab = null;

        // Begin 5 moves
		if (StageLoader.instance.Stage == 10)
        {
            if (step == 0)
            {
                prefab = Instantiate(Resources.Load(Configuration.Level10BeginStep1())) as GameObject;
                prefab.name = "Level 10 Begin Step 1";

                step = 1;
            }
        }
        // begin Magic Cookie
		else if (StageLoader.instance.Stage == 20)
        {
            if (step == 0)
            {
                prefab = Instantiate(Resources.Load(Configuration.Level20BeginStep1())) as GameObject;
                prefab.name = "Level 20 Begin Step 1";

                step = 1;
            }
        }
        // begin Magic Bomb
		else if (StageLoader.instance.Stage == 23)
        {
            if (step == 0)
            {
                prefab = Instantiate(Resources.Load(Configuration.Level23BeginStep1())) as GameObject;
                prefab.name = "Level 23 Begin Step 1";

                step = 1;
            }
        }

        if (prefab != null)
        {
            prefab.gameObject.transform.SetParent(gameObject.transform);
            prefab.GetComponent<RectTransform>().localScale = Vector3.one;

            current = prefab;
        }
    }

    public void Hide()
    {
		if (StageLoader.instance.Stage == 1 || 
			StageLoader.instance.Stage == 2 ||
			StageLoader.instance.Stage == 3 ||
			StageLoader.instance.Stage == 4 ||
			StageLoader.instance.Stage == 5 ||
			StageLoader.instance.Stage == 6 ||
			StageLoader.instance.Stage == 7 ||
			StageLoader.instance.Stage == 9 ||
			StageLoader.instance.Stage == 12 ||
			StageLoader.instance.Stage == 15 ||
			StageLoader.instance.Stage == 18 ||
			StageLoader.instance.Stage == 25)
        {
            if (current != null)
            {
                current.SetActive(false);
            }            
        }

		if (StageLoader.instance.Stage == 6)
        {
            step = 0;
            SelfDisactive();
        }
		else if (StageLoader.instance.Stage == 7 && step == 2)
        {
            step = 0;
            SelfDisactive();
        }
		else if (StageLoader.instance.Stage == 9)
        {
            step = 0;
            SelfDisactive();
        }
		else if (StageLoader.instance.Stage == 12 && step == 2)
        {
            step = 0;
            SelfDisactive();
        }
		else if (StageLoader.instance.Stage == 15 && step == 2)
        {
            step = 0;
            SelfDisactive();
        }
		else if (StageLoader.instance.Stage == 16)
        {
            step = 0;
            SelfDisactive();
        }
		else if (StageLoader.instance.Stage == 18 && step == 2)
        {
            step = 0;
            SelfDisactive();
        }
		else if (StageLoader.instance.Stage == 25 && step == 2)
        {
            step = 0;
            SelfDisactive();
        }
		else if (StageLoader.instance.Stage == 31)
        {
            step = 0;
            SelfDisactive();
        }
		else if (StageLoader.instance.Stage == 61)
        {
            step = 0;
            SelfDisactive();
        }
		else if (StageLoader.instance.Stage == 76)
        {
            step = 0;
            SelfDisactive();
        }
    }

    public void HideOnSwapBack()
    {
		if (StageLoader.instance.Stage == 2 ||
			StageLoader.instance.Stage == 3)
        {
            step = 0;
            SelfDisactive();
        }
    }

    public void SelfDisactive()
    {
        if (GameObject.Find("Board"))
        {
			GameObject.Find("Board").GetComponent<itemGrid>().Hint();
        } 

        help = false;        

        gameObject.SetActive(false);        
    }
}
