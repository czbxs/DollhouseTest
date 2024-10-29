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

// Cartoon FX  - (c) 2015, Jean Moreno

// Decreases a light's intensity over time.

[RequireComponent(typeof(Light))]
public class CFX_LightIntensityFade : MonoBehaviour
{
	// Duration of the effect.
	public float duration = 1.0f;
	
	// Delay of the effect.
	public float delay = 0.0f;
	
	/// Final intensity of the light.
	public float finalIntensity = 0.0f;
	
	// Base intensity, automatically taken from light parameters.
	private float baseIntensity;
	
	// If <c>true</c>, light will destructs itself on completion of the effect
	public bool autodestruct;
	
	private float p_lifetime = 0.0f;
	private float p_delay;
	
	void Start()
	{
		baseIntensity = GetComponent<Light>().intensity;
	}
	
	void OnEnable()
	{
		p_lifetime = 0.0f;
		p_delay = delay;
		if(delay > 0) GetComponent<Light>().enabled = false;
	}
	
	void Update ()
	{
		if(p_delay > 0)
		{
			p_delay -= Time.deltaTime;
			if(p_delay <= 0)
			{
				GetComponent<Light>().enabled = true;
			}
			return;
		}
		
		if(p_lifetime/duration < 1.0f)
		{
			GetComponent<Light>().intensity = Mathf.Lerp(baseIntensity, finalIntensity, p_lifetime/duration);
			p_lifetime += Time.deltaTime;
		}
		else
		{
			if(autodestruct)
				GameObject.Destroy(this.gameObject);
		}
		
	}
}
