/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

#if UNITY_EDITOR

// Cartoon FX  - (c) 2015 Jean Moreno

// Help Component that can be added to any GameObject or Prefab
//
// Can be useful if you want to add comments to a particular
// Prefab or GameObject about its usage

using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(CFX_InspectorHelp))]
public class CFX_InspectorHelpEditor : Editor
{
	private CFX_InspectorHelp inspHelp { get { return (this.target as CFX_InspectorHelp); } }
	
	public override void OnInspectorGUI ()
	{
		if(inspHelp.Locked)
		{
			ShowHelpGUI();
		}
		else
		{
			EditorStyles.textField.wordWrap = true;
			inspHelp.Title = EditorGUILayout.TextField(inspHelp.Title);
			inspHelp.HelpText = EditorGUILayout.TextArea(inspHelp.HelpText);
			inspHelp.MsgType = (int)((MessageType)EditorGUILayout.EnumPopup("Message Type", (MessageType)inspHelp.MsgType));
			
			EditorGUILayout.HelpBox("Use the contextual menu (right click or cog icon) on this Component to enable editing back", MessageType.Warning);
			if(GUILayout.Button("Lock Message", GUILayout.Height(30)))
			{
				inspHelp.Locked = true;
			}
			
			if(GUI.changed)
			{
				EditorUtility.SetDirty(inspHelp);
			}
			
			GUILayout.Space(12);
			EditorGUILayout.LabelField("MESSAGE PREVIEW:", EditorStyles.largeLabel);
			
			ShowHelpGUI();
		}
	}
	
	private void ShowHelpGUI()
	{
		GUILayout.Space(12);
		
		if(!string.IsNullOrEmpty(inspHelp.Title))
		{
			EditorGUILayout.LabelField(inspHelp.Title, EditorStyles.boldLabel);
		}
		
		EditorGUILayout.HelpBox(inspHelp.HelpText, (MessageType)inspHelp.MsgType);
		
		GUILayout.Space(12);
	}
}

#endif
