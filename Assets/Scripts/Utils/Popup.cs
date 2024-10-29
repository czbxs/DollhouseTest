/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    public Color backgroundColor = new Color(10.0f/255.0f, 10.0f/255.0f, 10.0f/255.0f, 0.6f);

	private GameObject m_background;

	public void Open()
	{
		AddBackground();
	}

	public void Close()
	{
		var animator = GetComponent<Animator>();
		if (animator.GetCurrentAnimatorStateInfo(0).IsName("Open"))
			animator.Play("Close");

		RemoveBackground();
		StartCoroutine(RunPopupDestroy());
	}

	private IEnumerator RunPopupDestroy()
    {
		yield return new WaitForSeconds(0.5f);
        Destroy(m_background);
		Destroy(gameObject);
	}

	private void AddBackground()
	{
		var bgTex = new Texture2D(1, 1);
		bgTex.SetPixel(0, 0, backgroundColor);
		bgTex.Apply();

		m_background = new GameObject("PopupBackground");
		var image = m_background.AddComponent<Image>();
		var rect = new Rect(0, 0, bgTex.width, bgTex.height);
		var sprite = Sprite.Create(bgTex, rect, new Vector2(0.5f, 0.5f), 1);
		image.material.mainTexture = bgTex;
		image.sprite = sprite;
		var newColor = image.color;
		image.color = newColor;
		image.canvasRenderer.SetAlpha(0.0f);
		image.CrossFadeAlpha(1.0f, 0.4f, false);

        var canvas = GameObject.Find("Canvas");
		m_background.transform.localScale = new Vector3(1, 1, 1);
        m_background.GetComponent<RectTransform>().sizeDelta = canvas.GetComponent<RectTransform>().sizeDelta;
		m_background.transform.SetParent(canvas.transform, false);
		m_background.transform.SetSiblingIndex(transform.GetSiblingIndex());
	}

	private void RemoveBackground()
	{
		var image = m_background.GetComponent<Image>();
		if (image != null)
			image.CrossFadeAlpha(0.0f, 0.2f, false);
	}
}
