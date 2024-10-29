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
using System;

public class Life : MonoBehaviour 
{
	//public float timer;
	//public string exitDateTime;
	public float oneLifeRecoveryTime;
	public bool runTimer;

	// UI
	public Text lifeText;
	public Text timerText;

	// Use this for initialization
	void Start () 
	{
		// set life for the first time
		if (PlayerPrefs.HasKey (Configuration.stringLife) == false) 
		{
			//print("Set life first time");

			Configuration.instance.life = Configuration.instance.maxLife;

			// set text
			lifeText.text = Configuration.instance.life.ToString();
			timerText.text = Configuration.instance.life.ToString () + "/" + Configuration.instance.life.ToString ();

            PlayerPrefs.SetInt(Configuration.stringLife, Configuration.instance.life);
            PlayerPrefs.Save();
		} 
        else
        {
            //print("Load from PlayerPrefs or Configuration");
        }

        // load from splash screen
        if (Configuration.instance.timer == 0)
        {
            //print("timer = 0 (load from PlayerPrefs)");

            // get exit date time
            Configuration.instance.exitDateTime = PlayerPrefs.GetString(Configuration.exit_date_time, new DateTime().ToString());

            // get timer
            Configuration.instance.timer = PlayerPrefs.GetFloat(Configuration.stringTimer, 0f);

            // life
            Configuration.instance.life = PlayerPrefs.GetInt(Configuration.stringLife, Configuration.instance.maxLife);
        }
        else
        {
            //print("Load from Configuration. Timer: " + Configuration.instance.timer);
        }

        //print(
        //    "exit date time: " + Configuration.instance.exitDateTime.ToString() + 
        //    " / timer: " + Configuration.instance.timer.ToString() + 
        //    " / life: " + Configuration.instance.life.ToString()
        //);

		// calculate one life recovery time
		oneLifeRecoveryTime = Configuration.instance.lifeRecoveryHour * 60f * 60f + Configuration.instance.lifeRecoveryMinute * 60f + Configuration.instance.lifeRecoverySecond;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (runTimer == false)
		{
			if (Configuration.instance.life < Configuration.instance.maxLife)
			{
				if (CheckRecoveryTime())
				{
					runTimer = true;
				}
			}
		}

		if (runTimer == true)
		{
			CalculateTimer(Time.deltaTime);
		}

		// update timerText
		if (Configuration.instance.life < Configuration.instance.maxLife)
		{
			var hour = Mathf.FloorToInt(Configuration.instance.timer / 3600);
			var minute = Mathf.FloorToInt((Configuration.instance.timer - hour * 3600) / 60);
			var second = Mathf.FloorToInt((Configuration.instance.timer - hour * 3600) - minute * 60);

			if (Configuration.instance.lifeRecoveryHour > 0)
			{
				timerText.text = string.Format("{0:00}:{1:00}:{2:00}", hour, minute, second);
			}
			else
			{
				timerText.text = string.Format("{0:00}:{1:00}", minute, second);
			}
		}
		else
		{
            lifeText.text = Configuration.instance.life.ToString();
			timerText.text = Configuration.instance.life.ToString () + "/" + Configuration.instance.life.ToString ();

			runTimer = false;
			Configuration.instance.timer = 0;
		}
	}

	bool CheckRecoveryTime()
	{
		// check exit date time
        if (Configuration.instance.exitDateTime == new DateTime().ToString())
		{
            //print("Exit date time is default");

			Configuration.instance.exitDateTime = DateTime.Now.ToString();
		}
        else
        {
            //print("Exit data is not default");
        }

		// convert string to date time
		DateTime _exitDateTime = DateTime.Parse(Configuration.instance.exitDateTime);

		if (DateTime.Now.Subtract(_exitDateTime).TotalSeconds > oneLifeRecoveryTime * (Configuration.instance.maxLife - Configuration.instance.life))
		{
			// enough time to recovery all the life
			Configuration.instance.life = Configuration.instance.maxLife;

			// update text
			lifeText.text = Configuration.instance.life.ToString();

			// set timer
			Configuration.instance.timer = 0f;

			return false;
		}
		else
		{
			//print("Recovery duration: " + (float)DateTime.Now.Subtract(_exitDateTime).TotalSeconds);

			CalculateTimer((float)DateTime.Now.Subtract(_exitDateTime).TotalSeconds);

			return true;
		}
	}

	void CalculateTimer(float duration)
	{
        if (Configuration.instance.timer <= 0 && duration < 1)
		{
			Configuration.instance.timer = oneLifeRecoveryTime;
		}

        if (Configuration.instance.timer <= duration)
		{
            //print("Duration: " + (int)duration + " / Recovery time: " + (int)oneLifeRecoveryTime);

            // add one or more life
            if (duration < 1)
            {
                AddLife(1);

                Configuration.instance.timer = oneLifeRecoveryTime;
            }
            else
            {
                if (duration >= oneLifeRecoveryTime)
                {
                    AddLife((int)duration / (int)oneLifeRecoveryTime);

                    Configuration.instance.timer -= (int)duration % (int)oneLifeRecoveryTime;
                }
                else
                {
                    AddLife(1);

                    Configuration.instance.timer = oneLifeRecoveryTime - (duration - Configuration.instance.timer);
                }
            }
		}
		else
		{
            Configuration.instance.timer -= duration;

			// update text
			lifeText.text = Configuration.instance.life.ToString();
		}
	}

	public void AddLife(int count)
	{
		//print("Add life: " + count);

		Configuration.instance.life += count;

		if (Configuration.instance.life > Configuration.instance.maxLife)
		{
			Configuration.instance.life = Configuration.instance.maxLife;
		}

		// update text
		lifeText.text = Configuration.instance.life.ToString();
	}

	public void ReduceLife(int count)
	{
		//print("Reduce life");

		var life = Configuration.instance.life;

		Configuration.instance.life = (life - 1 < 0) ? 0 : life - 1;

		// update text
		lifeText.text = Configuration.instance.life.ToString();

		// update exit date time
		Configuration.instance.exitDateTime = DateTime.Now.ToString();
	}
}
