/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class AnimatedButton : UIBehaviour, IPointerDownHandler
{
	[Serializable]
	public class ButtonClickedEvent : UnityEvent { }

    public bool interactable = true;

	[SerializeField]
	private ButtonClickedEvent m_OnClick = new ButtonClickedEvent();

	private Animator m_animator;

	override protected void Start()
	{
		base.Start();
		m_animator = GetComponent<Animator>();
	}

	public ButtonClickedEvent onClick
	{
		get { return m_OnClick; }
		set { m_OnClick = value; }
	}

	public virtual void OnPointerDown(PointerEventData eventData)
	{
		if (eventData.button != PointerEventData.InputButton.Left || !interactable)
			return;

		Press();
	}

	private void Press()
	{
		if (!IsActive())
			return;

        m_animator.SetTrigger("Pressed");
        Invoke("InvokeOnClickAction", 0.1f);
	}

    private void InvokeOnClickAction()
    {
        m_OnClick.Invoke();
    }
}
