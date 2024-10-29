/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;

public class SoundButton : MonoBehaviour
{
    private SpriteSwapper m_spriteSwapper;
    private bool m_on;

    private void Start()
    {
        m_spriteSwapper = GetComponent<SpriteSwapper>();
        m_on = PlayerPrefs.GetInt("sound_on") == 1;
        if (!m_on)
            m_spriteSwapper.SwapSprite();
    }

    public void Toggle()
    {
        m_on = !m_on;
        AudioListener.volume = m_on ? 1 : 0;
        PlayerPrefs.SetInt("sound_on", m_on ? 1 : 0);
    }

    public void ToggleSprite()
    {
        m_on = !m_on;
        m_spriteSwapper.SwapSprite();
    }
}
