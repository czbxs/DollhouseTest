/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;
using UnityEngine.UI;

public class SpriteSwapper : MonoBehaviour
{
	public Sprite enabledSprite;
	public Sprite disabledSprite;

	private bool m_swapped = true;

	private Image m_image;

	public void Awake()
	{
		m_image = GetComponent<Image>();
	}

	public void SwapSprite()
	{
		if (m_swapped)
		{
			m_swapped = false;
			m_image.sprite = disabledSprite;
		}
		else
		{
			m_swapped = true;
			m_image.sprite = enabledSprite;
		}
	}

    public bool IsEnabled()
    {
        if (m_swapped == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
