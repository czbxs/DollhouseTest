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

public class PopupOpener : MonoBehaviour
{
    public GameObject popupPrefab;

    protected Canvas m_canvas;

	protected void Start()
	{
		m_canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
	}

	public virtual void OpenPopup()
	{
		var popup = Instantiate(popupPrefab) as GameObject;
		popup.SetActive(true);
		popup.transform.localScale = Vector3.zero;

        // BEGIN_MECANIM_HACK
        // This works around a Mecanim bug present in Unity 5.2.1 where
        // the animation does not start until a frame after the prefab
        // has been instantiated. See:
        // http://forum.unity3d.com/threads/unity-5-2-mecanim-transitions-not-working-the-same-as-5-1.353815
#if UNITY_5_2_1
        var animator = popup.GetComponent<Animator>();
        animator.Update(0.01f);
#endif
        // END_MECANIM_HACK

        if (!m_canvas) m_canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

		popup.transform.SetParent(m_canvas.transform, false);
		popup.GetComponent<Popup>().Open();
	}
}
