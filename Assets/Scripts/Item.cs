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
using System.Collections.Generic;

public class Item : MonoBehaviour 
{
	[Header("Parent")]
	public itemGrid board;
	public Node node;
	
	[Header("Variables")]
	public int color;
	public ITEM_TYPE type;
	public ITEM_TYPE next = ITEM_TYPE.NONE;    
	public BREAKER_EFFECT effect = BREAKER_EFFECT.NORMAL;
	
	[Header("Check")]
	public bool drag;
	public bool nextSound = true;
	public bool destroying;
	public bool dropping;
	public bool changing;
	public Vector3 mousePostion = Vector3.zero;
	public Vector3 deltaPosition = Vector3.zero;
	public Vector3 swapDirection = Vector3.zero;
	
	[Header("Swap")]
	public Node neighborNodeLeft;
	public Node neighborNodeRight;
	public Node neighborNodeTop;
	public Node neighborNodeBottom;
	public Node neighborNodeTopLeft;
	public Node neighborNodeTopRight;
	public Node neighborNodeBottomLeft;
	public Node neighborNodeBottomRight;
	
	
	public Node neighborNode;
	public Item swapItem;
	
	[Header("Drop")]
	public List<Vector3> dropPath;
	
	public bool forced;


	void Start(){
	
	}

	void Update()
	{

		checkNeighbor ();
		if (drag)
		{
			getNeighbor ();
			
		}
		
	}
	
	
	
	
	#region Type
	
	
	public bool Movable()
	{
		if (type == ITEM_TYPE.MINE_1_LAYER ||
			type == ITEM_TYPE.MINE_2_LAYER ||
			type == ITEM_TYPE.MINE_3_LAYER ||
			type == ITEM_TYPE.MINE_4_LAYER ||
			type == ITEM_TYPE.MINE_5_LAYER ||
			type == ITEM_TYPE.MINE_6_LAYER ||
			type == ITEM_TYPE.ROCK_CANDY_1||
			type == ITEM_TYPE.ROCK_CANDY_2||
			type == ITEM_TYPE.ROCK_CANDY_3||
			type == ITEM_TYPE.ROCK_CANDY_4||
			type == ITEM_TYPE.ROCK_CANDY_5||
			type == ITEM_TYPE.ROCK_CANDY_6)
		{
			return false;
		}
		
		// cage
		if (node.cage != null)
		{
			if (node.cage.type == LOCK_TYPE.LOCK_1)
			{
				return false;
			}
		}
		
		return true;
	}
	
	public bool Matchable()
	{
		if (type == ITEM_TYPE.MINE_1_LAYER ||
			type == ITEM_TYPE.MINE_2_LAYER ||
			type == ITEM_TYPE.MINE_3_LAYER ||
			type == ITEM_TYPE.MINE_4_LAYER ||
			type == ITEM_TYPE.MINE_5_LAYER ||
			type == ITEM_TYPE.MINE_6_LAYER ||
			type == ITEM_TYPE.ROCK_CANDY_1 ||
			type == ITEM_TYPE.ROCK_CANDY_2 ||
			type == ITEM_TYPE.ROCK_CANDY_3 ||
			type == ITEM_TYPE.ROCK_CANDY_4 ||
			type == ITEM_TYPE.ROCK_CANDY_5 ||
			type == ITEM_TYPE.ROCK_CANDY_6 ||
			type == ITEM_TYPE.BREAKABLE ||
			type == ITEM_TYPE.ITEM_COLORCONE ||
			type == ITEM_TYPE.COLLECTIBLE_1 ||
			type == ITEM_TYPE.COLLECTIBLE_2 ||
			type == ITEM_TYPE.COLLECTIBLE_3 ||
			type == ITEM_TYPE.COLLECTIBLE_4 ||
			type == ITEM_TYPE.COLLECTIBLE_5 ||
			type == ITEM_TYPE.COLLECTIBLE_6 ||
			type == ITEM_TYPE.COLLECTIBLE_7 ||
			type == ITEM_TYPE.COLLECTIBLE_8 ||
			type == ITEM_TYPE.COLLECTIBLE_9)
		{
			return false;
		}
		
		return true;
	}
	
	public bool Destroyable()
	{
		if (type == ITEM_TYPE.COLLECTIBLE_1 ||
			type == ITEM_TYPE.COLLECTIBLE_2 ||
			type == ITEM_TYPE.COLLECTIBLE_3 ||
			type == ITEM_TYPE.COLLECTIBLE_4 ||
			type == ITEM_TYPE.COLLECTIBLE_5 ||
			type == ITEM_TYPE.COLLECTIBLE_6 ||
			type == ITEM_TYPE.COLLECTIBLE_7 ||
			type == ITEM_TYPE.COLLECTIBLE_8 ||
			type == ITEM_TYPE.COLLECTIBLE_9 || 
			type == ITEM_TYPE.COLLECTIBLE_10 ||
			type == ITEM_TYPE.COLLECTIBLE_11 ||
			type == ITEM_TYPE.COLLECTIBLE_12 ||
			type == ITEM_TYPE.COLLECTIBLE_13 ||
			type == ITEM_TYPE.COLLECTIBLE_14 ||
			type == ITEM_TYPE.COLLECTIBLE_15 ||
			type == ITEM_TYPE.COLLECTIBLE_16 ||
			type == ITEM_TYPE.COLLECTIBLE_17 ||
			type == ITEM_TYPE.COLLECTIBLE_18 ||
			type == ITEM_TYPE.COLLECTIBLE_19 ||
			type == ITEM_TYPE.COLLECTIBLE_20)
		{
			return false;
		}
		
		return true;
	}
	
	public bool IsCookie()
	{
		if (type == ITEM_TYPE.BlueBox ||
			type == ITEM_TYPE.GreenBox ||
			type == ITEM_TYPE.ORANGEBOX ||
			type == ITEM_TYPE.PURPLEBOX ||
			type == ITEM_TYPE.REDBOX ||
			type == ITEM_TYPE.YELLOWBOX)
		{
			return true;
		}
		
		return false;
		
	}
	
	public bool IsCollectible()
	{
		if (type == ITEM_TYPE.COLLECTIBLE_1 ||
			type == ITEM_TYPE.COLLECTIBLE_2 ||
			type == ITEM_TYPE.COLLECTIBLE_3 ||
			type == ITEM_TYPE.COLLECTIBLE_4 ||
			type == ITEM_TYPE.COLLECTIBLE_5 ||
			type == ITEM_TYPE.COLLECTIBLE_6 ||
			type == ITEM_TYPE.COLLECTIBLE_7 ||
			type == ITEM_TYPE.COLLECTIBLE_8 ||
			type == ITEM_TYPE.COLLECTIBLE_9 ||
			type == ITEM_TYPE.COLLECTIBLE_10 ||
			type == ITEM_TYPE.COLLECTIBLE_11 ||
			type == ITEM_TYPE.COLLECTIBLE_12 ||
			type == ITEM_TYPE.COLLECTIBLE_13 ||
			type == ITEM_TYPE.COLLECTIBLE_14 ||
			type == ITEM_TYPE.COLLECTIBLE_15 ||
			type == ITEM_TYPE.COLLECTIBLE_16 ||
			type == ITEM_TYPE.COLLECTIBLE_17 ||
			type == ITEM_TYPE.COLLECTIBLE_18 ||
			type == ITEM_TYPE.COLLECTIBLE_19 ||
			type == ITEM_TYPE.COLLECTIBLE_20)
		{
			return true;
		}
		
		return false;
	}
	
	public bool IsGingerbread()
	{
		if (type == ITEM_TYPE.ROCKET_1 ||
			type == ITEM_TYPE.ROCKET_2 ||
			type == ITEM_TYPE.ROCKET_3 ||
			type == ITEM_TYPE.ROCKET_4 ||
			type == ITEM_TYPE.ROCKET_5 ||
			type == ITEM_TYPE.ROCKET_6)
		{
			return true;
		}
		
		return false;
	}
	
	public bool IsMarshmallow()
	{
		if (type == ITEM_TYPE.BREAKABLE)
		{
			return true;
		}
		return false;
	}
	
	public bool IsChocolate()
	{
		if (type == ITEM_TYPE.MINE_1_LAYER ||
			type == ITEM_TYPE.MINE_2_LAYER ||
			type == ITEM_TYPE.MINE_3_LAYER ||
			type == ITEM_TYPE.MINE_4_LAYER ||
			type == ITEM_TYPE.MINE_5_LAYER ||
			type == ITEM_TYPE.MINE_6_LAYER)
		{
			return true;
		}
		
		return false;
	}
	
	public bool IsRockCandy()
	{
		if (type == ITEM_TYPE.ROCK_CANDY_1 ||
			type == ITEM_TYPE.ROCK_CANDY_2 ||
			type == ITEM_TYPE.ROCK_CANDY_3 ||
			type == ITEM_TYPE.ROCK_CANDY_4 ||
			type == ITEM_TYPE.ROCK_CANDY_5 ||
			type == ITEM_TYPE.ROCK_CANDY_6)
		{
			return true;
		}
		
		return false;
	}
	
	public ITEM_TYPE OriginCookieType()
	{
		var order = board.NodeOrder(node.i, node.j);
		
		return StageLoader.instance.itemLayerData[order];
	}
	
	ITEM_TYPE GetColRowBreaker(ITEM_TYPE check, Vector3 direction)
	{
		
		if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
		{
			
			switch (check)
			{
			case ITEM_TYPE.BlueBox:
			case ITEM_TYPE.BlueBox_COLUMN:
			case ITEM_TYPE.BlueBox_ROW:
			case ITEM_TYPE.BlueBox_BOMB:
			case ITEM_TYPE.BlueBox_Cross:
				return ITEM_TYPE.BlueBox_ROW;
			case ITEM_TYPE.GreenBox:
			case ITEM_TYPE.GreenBox_COLUMN:
			case ITEM_TYPE.GreenBox_ROW:
			case ITEM_TYPE.GreenBox_BOMB:
			case ITEM_TYPE.GreenBox_Cross:
				return ITEM_TYPE.GreenBox_ROW;
			case ITEM_TYPE.ORANGEBOX:
			case ITEM_TYPE.ORANGEBOX_COLUMN:
			case ITEM_TYPE.ORANGEBOX_ROW:
			case ITEM_TYPE.ORANGEBOX_BOMB:
			case ITEM_TYPE.ORANGEBOX_Cross:
				return ITEM_TYPE.ORANGEBOX_ROW;
			case ITEM_TYPE.PURPLEBOX:
			case ITEM_TYPE.PURPLEBOX_COLUMN:
			case ITEM_TYPE.PURPLEBOX_ROW:
			case ITEM_TYPE.PURPLEBOX_BOMB:
			case ITEM_TYPE.PURPLEBOX_Cross:
				return ITEM_TYPE.PURPLEBOX_ROW;
			case ITEM_TYPE.REDBOX:
			case ITEM_TYPE.REDBOX_COLUMN:
			case ITEM_TYPE.REDBOX_ROW:
			case ITEM_TYPE.REDBOX_BOMB:
			case ITEM_TYPE.REDBOX_Cross:
				return ITEM_TYPE.REDBOX_ROW;
			case ITEM_TYPE.YELLOWBOX:
			case ITEM_TYPE.YELLOWBOX_COLUMN:
			case ITEM_TYPE.YELLOWBOX_ROW:
			case ITEM_TYPE.YELLOWBOX_BOMB:
			case ITEM_TYPE.YELLOWBOX_Cross:
				return ITEM_TYPE.YELLOWBOX_ROW;
			default:
				return ITEM_TYPE.NONE;
			}
		}
		else
		{
			
			switch (check)
			{
			case ITEM_TYPE.BlueBox:
			case ITEM_TYPE.BlueBox_COLUMN:
			case ITEM_TYPE.BlueBox_ROW:
			case ITEM_TYPE.BlueBox_BOMB:
			case ITEM_TYPE.BlueBox_Cross:
				return ITEM_TYPE.BlueBox_COLUMN;
			case ITEM_TYPE.GreenBox:
			case ITEM_TYPE.GreenBox_COLUMN:
			case ITEM_TYPE.GreenBox_ROW:
			case ITEM_TYPE.GreenBox_BOMB:
			case ITEM_TYPE.GreenBox_Cross:
				return ITEM_TYPE.GreenBox_COLUMN;
			case ITEM_TYPE.ORANGEBOX:
			case ITEM_TYPE.ORANGEBOX_COLUMN:
			case ITEM_TYPE.ORANGEBOX_ROW:
			case ITEM_TYPE.ORANGEBOX_BOMB:
			case ITEM_TYPE.ORANGEBOX_Cross:
				return ITEM_TYPE.ORANGEBOX_COLUMN;
			case ITEM_TYPE.PURPLEBOX:
			case ITEM_TYPE.PURPLEBOX_COLUMN:
			case ITEM_TYPE.PURPLEBOX_ROW:
			case ITEM_TYPE.PURPLEBOX_BOMB:
			case ITEM_TYPE.PURPLEBOX_Cross:
				return ITEM_TYPE.PURPLEBOX_COLUMN;
			case ITEM_TYPE.REDBOX:
			case ITEM_TYPE.REDBOX_COLUMN:
			case ITEM_TYPE.REDBOX_ROW:
			case ITEM_TYPE.REDBOX_BOMB:
			case ITEM_TYPE.REDBOX_Cross:
				return ITEM_TYPE.REDBOX_COLUMN;
			case ITEM_TYPE.YELLOWBOX:
			case ITEM_TYPE.YELLOWBOX_COLUMN:
			case ITEM_TYPE.YELLOWBOX_ROW:
			case ITEM_TYPE.YELLOWBOX_BOMB:
			case ITEM_TYPE.YELLOWBOX_Cross:
				return ITEM_TYPE.YELLOWBOX_COLUMN;
			default:
				return ITEM_TYPE.NONE;
			}
		}
	}
	
	public bool IsBombBreaker(ITEM_TYPE check)
	{
		if (check == ITEM_TYPE.BlueBox_BOMB ||
			check == ITEM_TYPE.GreenBox_BOMB ||
			check == ITEM_TYPE.ORANGEBOX_BOMB ||
			check == ITEM_TYPE.PURPLEBOX_BOMB ||
			check == ITEM_TYPE.REDBOX_BOMB ||
			check == ITEM_TYPE.YELLOWBOX_BOMB)
		{
			return true;
		}
		
		return false;
	}
	
	public bool IsXBreaker(ITEM_TYPE check)
	{
		if (check == ITEM_TYPE.BlueBox_Cross ||
			check == ITEM_TYPE.GreenBox_Cross ||
			check == ITEM_TYPE.ORANGEBOX_Cross ||
			check == ITEM_TYPE.PURPLEBOX_Cross ||
			check == ITEM_TYPE.REDBOX_Cross ||
			check == ITEM_TYPE.YELLOWBOX_Cross)
		{
			return true;
		}
		
		return false;
	}
	
	public bool IsColumnBreaker(ITEM_TYPE check)
	{
		if (check == ITEM_TYPE.BlueBox_COLUMN ||
			check == ITEM_TYPE.GreenBox_COLUMN ||
			check == ITEM_TYPE.ORANGEBOX_COLUMN ||
			check == ITEM_TYPE.PURPLEBOX_COLUMN ||
			check == ITEM_TYPE.REDBOX_COLUMN ||
			check == ITEM_TYPE.YELLOWBOX_COLUMN)
		{
			return true;
		}
		
		return false;
	}
	
	public bool IsRowBreaker(ITEM_TYPE check)
	{
		if (check == ITEM_TYPE.BlueBox_ROW ||
			check == ITEM_TYPE.GreenBox_ROW ||
			check == ITEM_TYPE.ORANGEBOX_ROW ||
			check == ITEM_TYPE.PURPLEBOX_ROW ||
			check == ITEM_TYPE.REDBOX_ROW ||
			check == ITEM_TYPE.YELLOWBOX_ROW)
		{
			return true;
		}
		
		return false;
	}
	
	public bool IsBreaker(ITEM_TYPE check)
	{
		if (IsBombBreaker(check) || IsXBreaker(check) || IsColumnBreaker(check) || IsRowBreaker(check))
		{
			return true;
		}
		
		return false;
	}
	
	public ITEM_TYPE GetBombBreaker(ITEM_TYPE check)
	{
		switch (check)
		{
		case ITEM_TYPE.BlueBox:
		case ITEM_TYPE.BlueBox_COLUMN:
		case ITEM_TYPE.BlueBox_ROW:
		case ITEM_TYPE.BlueBox_BOMB:
		case ITEM_TYPE.BlueBox_Cross:
			return ITEM_TYPE.BlueBox_BOMB;
		case ITEM_TYPE.GreenBox:
		case ITEM_TYPE.GreenBox_COLUMN:
		case ITEM_TYPE.GreenBox_ROW:
		case ITEM_TYPE.GreenBox_BOMB:
		case ITEM_TYPE.GreenBox_Cross:
			return ITEM_TYPE.GreenBox_BOMB;
		case ITEM_TYPE.ORANGEBOX:
		case ITEM_TYPE.ORANGEBOX_COLUMN:
		case ITEM_TYPE.ORANGEBOX_ROW:
		case ITEM_TYPE.ORANGEBOX_BOMB:
		case ITEM_TYPE.ORANGEBOX_Cross:
			return ITEM_TYPE.ORANGEBOX_BOMB;
		case ITEM_TYPE.PURPLEBOX:
		case ITEM_TYPE.PURPLEBOX_COLUMN:
		case ITEM_TYPE.PURPLEBOX_ROW:
		case ITEM_TYPE.PURPLEBOX_BOMB:
		case ITEM_TYPE.PURPLEBOX_Cross:
			return ITEM_TYPE.PURPLEBOX_BOMB;
		case ITEM_TYPE.REDBOX:
		case ITEM_TYPE.REDBOX_COLUMN:
		case ITEM_TYPE.REDBOX_ROW:
		case ITEM_TYPE.REDBOX_BOMB:
		case ITEM_TYPE.REDBOX_Cross:
			return ITEM_TYPE.REDBOX_BOMB;
		case ITEM_TYPE.YELLOWBOX:
		case ITEM_TYPE.YELLOWBOX_COLUMN:
		case ITEM_TYPE.YELLOWBOX_ROW:
		case ITEM_TYPE.YELLOWBOX_BOMB:
		case ITEM_TYPE.YELLOWBOX_Cross:
			return ITEM_TYPE.YELLOWBOX_BOMB;
		default:
			return ITEM_TYPE.NONE;
		}
	}
	
	public ITEM_TYPE GetXBreaker(ITEM_TYPE check)
	{
		switch (check)
		{
		case ITEM_TYPE.BlueBox:
		case ITEM_TYPE.BlueBox_COLUMN:
		case ITEM_TYPE.BlueBox_ROW:
		case ITEM_TYPE.BlueBox_BOMB:
		case ITEM_TYPE.BlueBox_Cross:
			return ITEM_TYPE.BlueBox_Cross;
		case ITEM_TYPE.GreenBox:
		case ITEM_TYPE.GreenBox_COLUMN:
		case ITEM_TYPE.GreenBox_ROW:
		case ITEM_TYPE.GreenBox_BOMB:
		case ITEM_TYPE.GreenBox_Cross:
			return ITEM_TYPE.GreenBox_Cross;
		case ITEM_TYPE.ORANGEBOX:
		case ITEM_TYPE.ORANGEBOX_COLUMN:
		case ITEM_TYPE.ORANGEBOX_ROW:
		case ITEM_TYPE.ORANGEBOX_BOMB:
		case ITEM_TYPE.ORANGEBOX_Cross:
			return ITEM_TYPE.ORANGEBOX_Cross;
		case ITEM_TYPE.PURPLEBOX:
		case ITEM_TYPE.PURPLEBOX_COLUMN:
		case ITEM_TYPE.PURPLEBOX_ROW:
		case ITEM_TYPE.PURPLEBOX_BOMB:
		case ITEM_TYPE.PURPLEBOX_Cross:
			return ITEM_TYPE.PURPLEBOX_Cross;
		case ITEM_TYPE.REDBOX:
		case ITEM_TYPE.REDBOX_COLUMN:
		case ITEM_TYPE.REDBOX_ROW:
		case ITEM_TYPE.REDBOX_BOMB:
		case ITEM_TYPE.REDBOX_Cross:
			return ITEM_TYPE.REDBOX_Cross;
		case ITEM_TYPE.YELLOWBOX:
		case ITEM_TYPE.YELLOWBOX_COLUMN:
		case ITEM_TYPE.YELLOWBOX_ROW:
		case ITEM_TYPE.YELLOWBOX_BOMB:
		case ITEM_TYPE.YELLOWBOX_Cross:
			return ITEM_TYPE.YELLOWBOX_Cross;
		default:
			return ITEM_TYPE.NONE;
		}
	}
	
	public ITEM_TYPE GetColumnBreaker(ITEM_TYPE check)
	{
		switch (check)
		{
		case ITEM_TYPE.BlueBox:
		case ITEM_TYPE.BlueBox_COLUMN:
		case ITEM_TYPE.BlueBox_ROW:
		case ITEM_TYPE.BlueBox_BOMB:
		case ITEM_TYPE.BlueBox_Cross:
			return ITEM_TYPE.BlueBox_COLUMN;
		case ITEM_TYPE.GreenBox:
		case ITEM_TYPE.GreenBox_COLUMN:
		case ITEM_TYPE.GreenBox_ROW:
		case ITEM_TYPE.GreenBox_BOMB:
		case ITEM_TYPE.GreenBox_Cross:
			return ITEM_TYPE.GreenBox_COLUMN;
		case ITEM_TYPE.ORANGEBOX:
		case ITEM_TYPE.ORANGEBOX_COLUMN:
		case ITEM_TYPE.ORANGEBOX_ROW:
		case ITEM_TYPE.ORANGEBOX_BOMB:
		case ITEM_TYPE.ORANGEBOX_Cross:
			return ITEM_TYPE.ORANGEBOX_COLUMN;
		case ITEM_TYPE.PURPLEBOX:
		case ITEM_TYPE.PURPLEBOX_COLUMN:
		case ITEM_TYPE.PURPLEBOX_ROW:
		case ITEM_TYPE.PURPLEBOX_BOMB:
		case ITEM_TYPE.PURPLEBOX_Cross:
			return ITEM_TYPE.PURPLEBOX_COLUMN;
		case ITEM_TYPE.REDBOX:
		case ITEM_TYPE.REDBOX_COLUMN:
		case ITEM_TYPE.REDBOX_ROW:
		case ITEM_TYPE.REDBOX_BOMB:
		case ITEM_TYPE.REDBOX_Cross:
			return ITEM_TYPE.REDBOX_COLUMN;
		case ITEM_TYPE.YELLOWBOX:
		case ITEM_TYPE.YELLOWBOX_COLUMN:
		case ITEM_TYPE.YELLOWBOX_ROW:
		case ITEM_TYPE.YELLOWBOX_BOMB:
		case ITEM_TYPE.YELLOWBOX_Cross:
			return ITEM_TYPE.YELLOWBOX_COLUMN;
		default:
			return ITEM_TYPE.NONE;
		}
	}
	
	public ITEM_TYPE GetRowBreaker(ITEM_TYPE check)
	{
		switch (check)
		{
		case ITEM_TYPE.BlueBox:
		case ITEM_TYPE.BlueBox_COLUMN:
		case ITEM_TYPE.BlueBox_ROW:
		case ITEM_TYPE.BlueBox_BOMB:
		case ITEM_TYPE.BlueBox_Cross:
			return ITEM_TYPE.BlueBox_ROW;
		case ITEM_TYPE.GreenBox:
		case ITEM_TYPE.GreenBox_COLUMN:
		case ITEM_TYPE.GreenBox_ROW:
		case ITEM_TYPE.GreenBox_BOMB:
		case ITEM_TYPE.GreenBox_Cross:
			return ITEM_TYPE.GreenBox_ROW;
		case ITEM_TYPE.ORANGEBOX:
		case ITEM_TYPE.ORANGEBOX_COLUMN:
		case ITEM_TYPE.ORANGEBOX_ROW:
		case ITEM_TYPE.ORANGEBOX_BOMB:
		case ITEM_TYPE.ORANGEBOX_Cross:
			return ITEM_TYPE.ORANGEBOX_ROW;
		case ITEM_TYPE.PURPLEBOX:
		case ITEM_TYPE.PURPLEBOX_COLUMN:
		case ITEM_TYPE.PURPLEBOX_ROW:
		case ITEM_TYPE.PURPLEBOX_BOMB:
		case ITEM_TYPE.PURPLEBOX_Cross:
			return ITEM_TYPE.PURPLEBOX_ROW;
		case ITEM_TYPE.REDBOX:
		case ITEM_TYPE.REDBOX_COLUMN:
		case ITEM_TYPE.REDBOX_ROW:
		case ITEM_TYPE.REDBOX_BOMB:
		case ITEM_TYPE.REDBOX_Cross:
			return ITEM_TYPE.REDBOX_ROW;
		case ITEM_TYPE.YELLOWBOX:
		case ITEM_TYPE.YELLOWBOX_COLUMN:
		case ITEM_TYPE.YELLOWBOX_ROW:
		case ITEM_TYPE.YELLOWBOX_BOMB:
		case ITEM_TYPE.YELLOWBOX_Cross:
			return ITEM_TYPE.YELLOWBOX_ROW;
		default:
			return ITEM_TYPE.NONE;
		}
	}
	
	public ITEM_TYPE GetCookie(ITEM_TYPE check)
	{
		switch (check)
		{
		case ITEM_TYPE.BlueBox:
		case ITEM_TYPE.BlueBox_COLUMN:
		case ITEM_TYPE.BlueBox_ROW:
		case ITEM_TYPE.BlueBox_BOMB:
		case ITEM_TYPE.BlueBox_Cross:
			return ITEM_TYPE.BlueBox;
		case ITEM_TYPE.GreenBox:
		case ITEM_TYPE.GreenBox_COLUMN:
		case ITEM_TYPE.GreenBox_ROW:
		case ITEM_TYPE.GreenBox_BOMB:
		case ITEM_TYPE.GreenBox_Cross:
			return ITEM_TYPE.GreenBox;
		case ITEM_TYPE.ORANGEBOX:
		case ITEM_TYPE.ORANGEBOX_COLUMN:
		case ITEM_TYPE.ORANGEBOX_ROW:
		case ITEM_TYPE.ORANGEBOX_BOMB:
		case ITEM_TYPE.ORANGEBOX_Cross:
			return ITEM_TYPE.ORANGEBOX;
		case ITEM_TYPE.PURPLEBOX:
		case ITEM_TYPE.PURPLEBOX_COLUMN:
		case ITEM_TYPE.PURPLEBOX_ROW:
		case ITEM_TYPE.PURPLEBOX_BOMB:
		case ITEM_TYPE.PURPLEBOX_Cross:
			return ITEM_TYPE.PURPLEBOX;
		case ITEM_TYPE.REDBOX:
		case ITEM_TYPE.REDBOX_COLUMN:
		case ITEM_TYPE.REDBOX_ROW:
		case ITEM_TYPE.REDBOX_BOMB:
		case ITEM_TYPE.REDBOX_Cross:
			return ITEM_TYPE.REDBOX;
		case ITEM_TYPE.YELLOWBOX:
		case ITEM_TYPE.YELLOWBOX_COLUMN:
		case ITEM_TYPE.YELLOWBOX_ROW:
		case ITEM_TYPE.YELLOWBOX_BOMB:
		case ITEM_TYPE.YELLOWBOX_Cross:
			return ITEM_TYPE.YELLOWBOX;
		default:
			return ITEM_TYPE.NONE;
		}
	}
	
	#endregion
	
	#region Touch
	public Vector3 GetMousePosition()
	{
		return Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}

	
	void checkNeighbor(){
		

		if (node != null) {
			if (node.LeftNeighbor () != null) {
				if (node.LeftNeighbor ().item != null) {
					neighborNodeLeft = node.LeftNeighbor ();
					
				}
			}
			
			if (node.RightNeighbor () != null) {
				if (node.RightNeighbor ().item != null) {
					neighborNodeRight = node.RightNeighbor ();
					
				}
			}
			
			if (node.TopNeighbor () != null) {
				if (node.TopNeighbor ().item != null) {
					neighborNodeTop = node.TopNeighbor ();
					
				}
			}
			
			if (node.BottomNeighbor () != null) {
				if (node.BottomNeighbor ().item != null) {
					neighborNodeBottom = node.BottomNeighbor ();
					
				}
			}
			if (node.TopLeftNeighbor () != null) {
				if (node.TopLeftNeighbor ().item != null) {
					neighborNodeTopLeft = node.TopLeftNeighbor ();
					
				}
			}
			
			if (node.TopRightNeighbor () != null) {
				if (node.TopRightNeighbor ().item != null) {
					neighborNodeTopRight = node.TopRightNeighbor ();
					
				}
			}
			
			if (node.BottomLeftNeighbor () != null) {
				if (node.BottomLeftNeighbor ().item != null) {
					neighborNodeBottomLeft = node.BottomLeftNeighbor ();
					
				}
			}
			
			if (node.BottomRightNeighbor () != null) {
				if (node.BottomRightNeighbor ().item != null) {
					neighborNodeBottomRight = node.BottomRightNeighbor ();
					
				}
			}
		}
	}
	
	void getNeighbor()
	{
		
		if (neighborNode == null ) {
			swapItem = this;
			board.touchedItem = swapItem;
			board.swappedItem = swapItem;
		}
		OnStartSwap();
		OnCompleteSwap();
		Reset ();


	}

	public void OnStartSwap()
	{
		gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
		
		SFXManager.instance.SwapAudio();
		
		board.lockSwap = true;

		Debug.Log ("in getneighbour metho d: " + forced);
		board.dropTime = 1;
	}


	public void OnCompleteSwap()
	
	{

		gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
		
		var matchesHere = (node.FindMatches() != null)? node.FindMatches().Count : 0;
		var matchesAtNeighbor = (swapItem.node.FindMatches() != null)? swapItem.node.FindMatches().Count : 0;
		var special = false;
		
		if (type == ITEM_TYPE.ITEM_COLORCONE && (swapItem.IsCookie() || IsBreaker(swapItem.type) || swapItem.type == ITEM_TYPE.ITEM_COLORCONE))
		{
			special = true;
		}
		else if (swapItem.type == ITEM_TYPE.ITEM_COLORCONE && (IsCookie() || IsBreaker(type) || type == ITEM_TYPE.ITEM_COLORCONE))
		{
			special = true;
		}
		if (IsBreaker(type) && IsBreaker(swapItem.type))
		{
			special = true;
		}

//		if (forced == false)
//		{
			board.moveLeft--;
			board.UITop.DecreaseMoves();

//		}
		
		if (special == true)
		{
			RainbowDestroy(this, swapItem);
			
			TwoColRowBreakerDestroy(this, swapItem);
			
			TwoBombBreakerDestroy(this, swapItem);
			
			TwoXBreakerDestory(this, swapItem);
			
			ColRowBreakerAndBombBreakerDestroy(this, swapItem);
			
			ColRowBreakerAndXBreakerDestroy(this, swapItem);
			
			BombBreakerAndXBreakerDestroy(this, swapItem);
			
			simpleColumnBreaderDestroy (this, swapItem);

			simpleRowBreakerDestroy (this, swapItem);
		}
		else
		{
			if (matchesHere == 5) {
				
				next = GetColRowBreaker (this.type, transform.position - swapItem.transform.position);
			} else if (matchesAtNeighbor == 5) {
				
				swapItem.next = GetColRowBreaker (swapItem.type, transform.position - swapItem.transform.position);
			} else if (matchesHere >= 7) {
				
				next = GetXBreaker (this.type);
			} else if (matchesAtNeighbor >= 7) {
				
				swapItem.next = GetXBreaker (swapItem.type);
			}
			else if (matchesHere == 6) {
				
				next = GetBombBreaker (this.type);
			} else if (matchesAtNeighbor == 6) {
				swapItem.next = GetBombBreaker (swapItem.type);
			}

			board.FindMatches();
		}
		
		Reset();
	}
	
	public void OnStartSwapBack()
	{
		gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
		
		SFXManager.instance.SwapBackAudio();
		
		if (Help.instance.gameObject.activeSelf == true)
		{
			Help.instance.HideOnSwapBack();
		}        
	}
	
	public void OnCompleteSwapBack()
	{
		gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
		
		transform.position = board.NodeLocalPosition(node.i, node.j);
		
		Reset();
		

		StartCoroutine(board.ShowHint());
	}

	public void Reset()
	{
		drag = false;
		forced = true;

		Debug.Log ("forced value is reset method : " + forced);
		neighborNodeBottom = null;
		neighborNodeLeft = null;
		neighborNodeRight = null;
		neighborNodeTop = null;
		
		neighborNode = null;
		swapItem = null;		
	}
	
	bool CheckHelpSwapable(SWAP_DIRECTION direction)
	{
		if (StageLoader.instance.Stage == 1)
		{
			if (Help.instance.step == 2)
			{
				if (node.OrderOnBoard() == 5 && direction == SWAP_DIRECTION.BOTTOM)
				{
					return true;
				}
				else if (node.OrderOnBoard() == 14 && direction == SWAP_DIRECTION.TOP)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}
		else if (StageLoader.instance.Stage == 2)
		{
			if (Help.instance.step == 1)
			{
				if (node.OrderOnBoard() == 10 && direction == SWAP_DIRECTION.BOTTOM)
				{
					return true;
				}
				else if (node.OrderOnBoard() == 17 && direction == SWAP_DIRECTION.TOP)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else if (Help.instance.step == 2)
			{
				if (node.OrderOnBoard() == 19 && direction == SWAP_DIRECTION.BOTTOM)
				{
					return true;
				}
				else if (node.OrderOnBoard() == 26 && direction == SWAP_DIRECTION.TOP)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}
		else if (StageLoader.instance.Stage == 3)
		{
			if (Help.instance.step == 1)
			{
				if (node.OrderOnBoard() == 14 && direction == SWAP_DIRECTION.BOTTOM)
				{
					return true;
				}
				else if (node.OrderOnBoard() == 22 && direction == SWAP_DIRECTION.TOP)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else if (Help.instance.step == 2)
			{
				if (node.OrderOnBoard() == 38 && direction == SWAP_DIRECTION.BOTTOM)
				{
					return true;
				}
				else if (node.OrderOnBoard() == 46 && direction == SWAP_DIRECTION.TOP)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else if (Help.instance.step == 3)
			{
				if (node.OrderOnBoard() == 18 && direction == SWAP_DIRECTION.BOTTOM)
				{
					return true;
				}
				else if (node.OrderOnBoard() == 26 && direction == SWAP_DIRECTION.TOP)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else if (Help.instance.step == 4)
			{
				if (node.OrderOnBoard() == 26 && direction == SWAP_DIRECTION.BOTTOM)
				{
					return true;
				}
				else if (node.OrderOnBoard() == 34 && direction == SWAP_DIRECTION.TOP)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}
		else if (StageLoader.instance.Stage == 4)
		{
			if (Help.instance.step == 1)
			{
				if (node.OrderOnBoard() == 36 && direction == SWAP_DIRECTION.RIGHT)
				{
					return true;
				}
				else if (node.OrderOnBoard() == 37 && direction == SWAP_DIRECTION.LEFT)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else if (Help.instance.step == 2)
			{
				if (node.OrderOnBoard() == 52 && direction == SWAP_DIRECTION.RIGHT)
				{
					return true;
				}
				else if (node.OrderOnBoard() == 53 && direction == SWAP_DIRECTION.LEFT)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}
		else if (StageLoader.instance.Stage == 5)
		{
			if (Help.instance.step == 1)
			{
				if (node.OrderOnBoard() == 42 && direction == SWAP_DIRECTION.RIGHT)
				{
					return true;
				}
				else if (node.OrderOnBoard() == 43 && direction == SWAP_DIRECTION.LEFT)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}
		else if (StageLoader.instance.Stage == 6)
		{
			if (Help.instance.step == 1)
			{
				if (node.OrderOnBoard() == 45 && direction == SWAP_DIRECTION.RIGHT)
				{
					return true;
				}
				else if (node.OrderOnBoard() == 46 && direction == SWAP_DIRECTION.LEFT)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}
		
		return true;
	}
	
	#endregion
	
	#region ColorAndAppear
	
	public void GenerateColor(int except)
	{
		var colors = new List<int>();
		
		var usingColors = StageLoader.instance.usingColors;
		
		for (int i = 0; i < usingColors.Count; i++)
		{
			int color = usingColors[i];
			
			bool generatable = true;
			Node neighbor = null;
			
			neighbor = node.TopNeighbor();
			if (neighbor != null)
			{
				if (neighbor.item != null)
				{
					if (neighbor.item.color == color)
					{
						generatable = false;
					}
				}
			}
			
			neighbor = node.LeftNeighbor();
			if (neighbor != null)
			{
				if (neighbor.item != null)
				{
					if (neighbor.item.color == color)
					{
						generatable = false;
					}
				}
			}
			
			neighbor = node.RightNeighbor();
			if (neighbor != null)
			{
				if (neighbor.item != null)
				{
					if (neighbor.item.color == color)
					{
						generatable = false;
					}
				}
			}
			
			if (generatable && color != except)
			{
				colors.Add(color);
			}
		} // end for
		
		int index = usingColors[Random.Range(0, usingColors.Count)];
		
		if (colors.Count > 0)
		{
			index = colors[Random.Range(0, colors.Count)];
		}
		
		if (index == except)
		{
			index = (index++) % usingColors.Count;
		}
		
		this.color = index;
		
		ChangeSpriteAndType(index);
	}
	
	public void ChangeSpriteAndType(int itemColor)
	{
		GameObject prefab = null;
		
		switch (itemColor)
		{
		case 1:
			prefab = Resources.Load(Configuration.Item1()) as GameObject;
			type = ITEM_TYPE.BlueBox;
			break;
		case 2:
			prefab = Resources.Load(Configuration.Item2()) as GameObject;
			type = ITEM_TYPE.GreenBox;
			break;
		case 3:
			prefab = Resources.Load(Configuration.Item3()) as GameObject;
			type = ITEM_TYPE.ORANGEBOX;
			break;
		case 4:
			prefab = Resources.Load(Configuration.Item4()) as GameObject;
			type = ITEM_TYPE.PURPLEBOX;
			break;
		case 5:
			prefab = Resources.Load(Configuration.Item5()) as GameObject;
			type = ITEM_TYPE.REDBOX;
			break;
		case 6:
			prefab = Resources.Load(Configuration.Item6()) as GameObject;
			type = ITEM_TYPE.YELLOWBOX;
			break;
		}
		
		if (prefab != null)
		{
			GetComponent<SpriteRenderer>().sprite = prefab.GetComponent<SpriteRenderer>().sprite;
		}
	}
	
	public void ChangeToRainbow()
	{
		var prefab = Resources.Load(Configuration.ItemColorCone()) as GameObject;
		
		type = ITEM_TYPE.ITEM_COLORCONE;
		
		color = 0;
		
		GetComponent<SpriteRenderer>().sprite = prefab.GetComponent<SpriteRenderer>().sprite;
	}
	
	public void ChangeToGingerbread(ITEM_TYPE check)
	{
		if (node.item.IsGingerbread() == true)
		{
			return;
		}
		
		var upper = board.GetUpperItem(this.node);
		
		if (upper != null && upper.IsGingerbread())
		{
			return;
		}
		
		SFXManager.instance.GingerbreadAudio();
		
		GameObject explosion = null;
		
		switch (node.item.type)
		{
		case ITEM_TYPE.BlueBox:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.BlueBoxExplosion()) as GameObject);
			break;
		case ITEM_TYPE.GreenBox:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.GreenBoxExplosion()) as GameObject);
			break;
		case ITEM_TYPE.ORANGEBOX:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.OrangeCookieExplosion()) as GameObject);
			break;
		case ITEM_TYPE.PURPLEBOX:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.PurpleCookieExplosion()) as GameObject);
			break;
		case ITEM_TYPE.REDBOX:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.RedCookieExplosion()) as GameObject);
			break;
		case ITEM_TYPE.YELLOWBOX:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.YellowCookieExplosion()) as GameObject);
			break;
		}
		
		if (explosion != null) explosion.transform.position = node.item.transform.position;
		
		GameObject prefab = null;
		
		switch (check)
		{
		case ITEM_TYPE.ROCKET_1:
			prefab = Resources.Load(Configuration.Rocket1()) as GameObject;
			check = ITEM_TYPE.ROCKET_1;
			color = 1;
			break;
		case ITEM_TYPE.ROCKET_2:
			prefab = Resources.Load(Configuration.Rocket2()) as GameObject;
			check = ITEM_TYPE.ROCKET_2;
			color = 2;
			break;
		case ITEM_TYPE.ROCKET_3:
			prefab = Resources.Load(Configuration.Rocket3()) as GameObject;
			check = ITEM_TYPE.ROCKET_3;
			color = 3;
			break;
		case ITEM_TYPE.ROCKET_4:
			prefab = Resources.Load(Configuration.Rocket4()) as GameObject;
			check = ITEM_TYPE.ROCKET_4;
			color = 4;
			break;
		case ITEM_TYPE.ROCKET_5:
			prefab = Resources.Load(Configuration.Rocket5()) as GameObject;
			check = ITEM_TYPE.ROCKET_5;
			color = 5;
			break;
		case ITEM_TYPE.ROCKET_6:
			prefab = Resources.Load(Configuration.Rocket6()) as GameObject;
			check = ITEM_TYPE.ROCKET_6;
			color = 6;
			break;
		}
		
		if (prefab != null)
		{
			type = check;
			effect = BREAKER_EFFECT.NORMAL;
			
			GetComponent<SpriteRenderer>().sprite = prefab.GetComponent<SpriteRenderer>().sprite;
		}
	}
	
	public void ChangeToBombBreaker()
	{
		GameObject prefab = null;
		
		switch (type)
		{
		case ITEM_TYPE.BlueBox:
			prefab = Resources.Load(Configuration.Item1Bomb()) as GameObject;
			type = ITEM_TYPE.BlueBox_BOMB;
			break;
		case ITEM_TYPE.GreenBox:
			prefab = Resources.Load(Configuration.Item2Bomb()) as GameObject;
			type = ITEM_TYPE.GreenBox_BOMB;
			break;
		case ITEM_TYPE.ORANGEBOX:
			prefab = Resources.Load(Configuration.Item3Bomb()) as GameObject;
			type = ITEM_TYPE.ORANGEBOX_BOMB;
			break;
		case ITEM_TYPE.PURPLEBOX:
			prefab = Resources.Load(Configuration.Item4Bomb()) as GameObject;
			type = ITEM_TYPE.PURPLEBOX_BOMB;
			break;
		case ITEM_TYPE.REDBOX:
			prefab = Resources.Load(Configuration.Item5Bomb()) as GameObject;
			type = ITEM_TYPE.REDBOX_BOMB;
			break;
		case ITEM_TYPE.YELLOWBOX:
			prefab = Resources.Load(Configuration.Item6Bomb()) as GameObject;
			type = ITEM_TYPE.YELLOWBOX_BOMB;
			break;
		}
		
		if (prefab != null)
		{
			GetComponent<SpriteRenderer>().sprite = prefab.GetComponent<SpriteRenderer>().sprite;
		}
	}
	
	public void ChangeToXBreaker()
	{
		GameObject prefab = null;
		
		switch (type)
		{
		case ITEM_TYPE.BlueBox:
			prefab = Resources.Load(Configuration.Item1Cross()) as GameObject;
			type = ITEM_TYPE.BlueBox_Cross;
			break;
		case ITEM_TYPE.GreenBox:
			prefab = Resources.Load(Configuration.Item2Cross()) as GameObject;
			type = ITEM_TYPE.GreenBox_Cross;
			break;
		case ITEM_TYPE.ORANGEBOX:
			prefab = Resources.Load(Configuration.Item3Cross()) as GameObject;
			type = ITEM_TYPE.ORANGEBOX_Cross;
			break;
		case ITEM_TYPE.PURPLEBOX:
			prefab = Resources.Load(Configuration.Item4Cross()) as GameObject;
			type = ITEM_TYPE.PURPLEBOX_Cross;
			break;
		case ITEM_TYPE.REDBOX:
			prefab = Resources.Load(Configuration.Item5Cross()) as GameObject;
			type = ITEM_TYPE.REDBOX_Cross;
			break;
		case ITEM_TYPE.YELLOWBOX:
			prefab = Resources.Load(Configuration.Item6Cross()) as GameObject;
			type = ITEM_TYPE.YELLOWBOX_Cross;
			break;
		}
		
		if (prefab != null)
		{
			GetComponent<SpriteRenderer>().sprite = prefab.GetComponent<SpriteRenderer>().sprite;
		}
	}
	
	public void ChangeToColRowBreaker()
	{
		GameObject prefab = null;
		
		if (Random.Range(0, 2) == 0)
		{
			switch (type)
			{
			case ITEM_TYPE.BlueBox:
				prefab = Resources.Load(Configuration.Item1Column()) as GameObject;
				type = ITEM_TYPE.BlueBox_COLUMN;
				break;
			case ITEM_TYPE.GreenBox:
				prefab = Resources.Load(Configuration.Item2Column()) as GameObject;
				type = ITEM_TYPE.GreenBox_COLUMN;
				break;
			case ITEM_TYPE.ORANGEBOX:
				prefab = Resources.Load(Configuration.Item3Column()) as GameObject;
				type = ITEM_TYPE.ORANGEBOX_COLUMN;
				break;
			case ITEM_TYPE.PURPLEBOX:
				prefab = Resources.Load(Configuration.Item4Column()) as GameObject;
				type = ITEM_TYPE.PURPLEBOX_COLUMN;
				break;
			case ITEM_TYPE.REDBOX:
				prefab = Resources.Load(Configuration.Item5Column()) as GameObject;
				type = ITEM_TYPE.REDBOX_COLUMN;
				break;
			case ITEM_TYPE.YELLOWBOX:
				prefab = Resources.Load(Configuration.Item6Column()) as GameObject;
				type = ITEM_TYPE.YELLOWBOX_COLUMN;
				break;
			}
		}
		else
		{
			switch (type)
			{
			case ITEM_TYPE.BlueBox:
				prefab = Resources.Load(Configuration.Item1Row()) as GameObject;
				type = ITEM_TYPE.BlueBox_ROW;
				break;
			case ITEM_TYPE.GreenBox:
				prefab = Resources.Load(Configuration.Item2Row()) as GameObject;
				type = ITEM_TYPE.GreenBox_ROW;
				break;
			case ITEM_TYPE.ORANGEBOX:
				prefab = Resources.Load(Configuration.Item3Row()) as GameObject;
				type = ITEM_TYPE.ORANGEBOX_ROW;
				break;
			case ITEM_TYPE.PURPLEBOX:
				prefab = Resources.Load(Configuration.Item4Row()) as GameObject;
				type = ITEM_TYPE.PURPLEBOX_ROW;
				break;
			case ITEM_TYPE.REDBOX:
				prefab = Resources.Load(Configuration.Item5Row()) as GameObject;
				type = ITEM_TYPE.REDBOX_ROW;
				break;
			case ITEM_TYPE.YELLOWBOX:
				prefab = Resources.Load(Configuration.Item6Row()) as GameObject;
				type = ITEM_TYPE.YELLOWBOX_ROW;
				break;
			}
		}
		
		if (prefab != null)
		{
			GetComponent<SpriteRenderer>().sprite = prefab.GetComponent<SpriteRenderer>().sprite;
		}
	}
	
	public void SetRandomNextType()
	{
		var random = Random.Range(0, 2);
		
		if (random == 0)
		{
			switch (type)
			{
			case ITEM_TYPE.BlueBox:
				next  = ITEM_TYPE.BlueBox_COLUMN;
				break;
			case ITEM_TYPE.GreenBox:
				next = ITEM_TYPE.GreenBox_COLUMN;
				break;
			case ITEM_TYPE.ORANGEBOX:
				next = ITEM_TYPE.ORANGEBOX_COLUMN;
				break;
			case ITEM_TYPE.PURPLEBOX:
				next = ITEM_TYPE.PURPLEBOX_COLUMN;
				break;
			case ITEM_TYPE.REDBOX:
				next = ITEM_TYPE.REDBOX_COLUMN;
				break;
			case ITEM_TYPE.YELLOWBOX:
				next = ITEM_TYPE.YELLOWBOX_COLUMN;
				break;
			}
		}
		else if (random == 1)
		{
			switch (type)
			{
			case ITEM_TYPE.BlueBox:
				next = ITEM_TYPE.BlueBox_ROW;
				break;
			case ITEM_TYPE.GreenBox:
				next = ITEM_TYPE.GreenBox_ROW;
				break;
			case ITEM_TYPE.ORANGEBOX:
				next = ITEM_TYPE.ORANGEBOX_ROW;
				break;
			case ITEM_TYPE.PURPLEBOX:
				next = ITEM_TYPE.PURPLEBOX_ROW;
				break;
			case ITEM_TYPE.REDBOX:
				next = ITEM_TYPE.REDBOX_ROW;
				break;
			case ITEM_TYPE.YELLOWBOX:
				next = ITEM_TYPE.YELLOWBOX_ROW;
				break;
			}
		}
		else if (random == 2)
		{
			switch (type)
			{
			case ITEM_TYPE.BlueBox:
				next = ITEM_TYPE.BlueBox_BOMB;
				break;
			case ITEM_TYPE.GreenBox:
				next = ITEM_TYPE.GreenBox_BOMB;
				break;
			case ITEM_TYPE.ORANGEBOX:
				next = ITEM_TYPE.ORANGEBOX_BOMB;
				break;
			case ITEM_TYPE.PURPLEBOX:
				next = ITEM_TYPE.PURPLEBOX_BOMB;
				break;
			case ITEM_TYPE.REDBOX:
				next = ITEM_TYPE.REDBOX_BOMB;
				break;
			case ITEM_TYPE.YELLOWBOX:
				next = ITEM_TYPE.YELLOWBOX_BOMB;
				break;
			}
		}
	}
	
	#endregion
	
	#region Destroy
	
	public void Destroy(bool forced = false)
	{
		if (Destroyable() == false && forced == false)
		{
			return;
		}
		
		if (destroying == true) return;
		else destroying = true;
		
		if (node != null && node.cage != null)
		{
			node.CageExplode();
			return;
		}
		
		board.destroyingItems++;
		
		iTween.ScaleTo(gameObject, iTween.Hash(
			"scale", Vector3.zero,
			"onstart", "OnStartDestroy",
			"oncomplete", "OnCompleteDestroy",
			"easetype", iTween.EaseType.linear,
			"time", Configuration.instance.destroyTime
		));
	}
	
	public void OnStartDestroy()
	{
		if (node != null) node.WaffleExplode();
		
		board.CollectItem(this);
		
		board.DestroyNeighborItems(this);
		
		if (effect == BREAKER_EFFECT.BIG_COLUMN_BREAKER) {
			BigColumnBreakerExplosion ();
		} else if (effect == BREAKER_EFFECT.BIG_ROW_BREAKER) {
			BigRowBreakerExplosion ();
		} else if (effect == BREAKER_EFFECT.CROSS) {
			CrossBreakerExplosion ();
		} else if (effect == BREAKER_EFFECT.BOMB_X_BREAKER) {
			BombXBreakerExplosion ();
		} else if (effect == BREAKER_EFFECT.CROSS_X_BREAKER) {
			CrossXBreakerExplosion ();
		} else if (effect == BREAKER_EFFECT.COLUMN_EFFECT) {
		
			col_BreakerExplosion ();
		} else if (effect == BREAKER_EFFECT.ROW_EFFECT) {
			row_BreakerExplosion ();
		}
		
		else if (effect == BREAKER_EFFECT.NORMAL)
		{
			if (IsCookie())
			{
				CookieExplosion();
			}
			else if (IsGingerbread())
			{
				GingerbreadExplosion();
			}
			else if (IsMarshmallow())
			{
				MarshmallowExplosion();
			}
			else if (IsChocolate())
			{
				ChocolateExplosion();
			}
			else if (IsRockCandy())
			{
				RockCandyExplosion();
			}
			else if (IsCollectible())
			{
				CollectibleExplosion();
			}
			else if (IsBombBreaker(type))
			{
				BombBreakerExplosion();
			}
			else if (IsXBreaker(type))
			{
				XBreakerExplosion();
			}
			else if (type == ITEM_TYPE.ITEM_COLORCONE)
			{
				RainbowExplosion();
			}
			else if (IsColumnBreaker(type))
			{
				ColumnBreakerExplosion();
			}
			else if (IsRowBreaker(type))
			{
				RowBreakerExplosion();
			}   
		}
	}
	
	public void OnCompleteDestroy()
	{
		if (board.state == GAME_STATE.PRE_WIN_AUTO_PLAYING)
		{
			board.score += Configuration.instance.finishedScoreItem * board.dropTime;
		}
		else
		{
			board.score += Configuration.instance.scoreItem * board.dropTime;
		}
		
		board.UITop.UpdateProgressBar(board.score);
		
		board.UITop.UpdateScoreAmount(board.score);
		
		if (next != ITEM_TYPE.NONE)
		{
			
			if (IsBombBreaker(next) || IsXBreaker(next))
			{
				if (nextSound == true) SFXManager.instance.BombBreakerAudio();
			}
			else if (IsRowBreaker(next) || IsColumnBreaker(next))
			{
				if (nextSound == true) SFXManager.instance.ColRowBreakerAudio();
			}
			else if (next == ITEM_TYPE.ITEM_COLORCONE)
			{
				if (nextSound == true) SFXManager.instance.RainbowAudio();
			}
			
			node.GenerateItem(next);
		}
		else if (type == ITEM_TYPE.MINE_2_LAYER)
		{
			node.GenerateItem(ITEM_TYPE.MINE_1_LAYER);
			
			board.GetNode(node.i, node.j).item.gameObject.transform.position = board.NodeLocalPosition(node.i, node.j); ;
		}
		else if (type == ITEM_TYPE.MINE_3_LAYER)
		{
			node.GenerateItem(ITEM_TYPE.MINE_2_LAYER);
			
			board.GetNode(node.i, node.j).item.gameObject.transform.position = board.NodeLocalPosition(node.i, node.j); ;
		}
		else if (type == ITEM_TYPE.MINE_4_LAYER)
		{
			node.GenerateItem(ITEM_TYPE.MINE_3_LAYER);
			
			board.GetNode(node.i, node.j).item.gameObject.transform.position = board.NodeLocalPosition(node.i, node.j); ;
		}
		else
		{
			node.item = null;
		}
		
		if (destroying == true)
		{
			board.destroyingItems--;
			
			if (dropping == true) board.droppingItems--;
			
			GameObject.Destroy(gameObject);
		}
	}
	
	public IEnumerator ResetDestroying()
	{
		yield return new WaitForSeconds(Configuration.instance.destroyTime);
		
		destroying = false;
	}
	
	#endregion
	
	#region Explosion
	
	void CookieExplosion()
	{
		SFXManager.instance.CookieCrushAudio();
		
		GameObject explosion = null;
		
		switch (type)
		{
		case ITEM_TYPE.BlueBox:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.BlueBoxExplosion()) as GameObject);
			break;
		case ITEM_TYPE.GreenBox:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.GreenBoxExplosion()) as GameObject);
			break;
		case ITEM_TYPE.ORANGEBOX:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.OrangeCookieExplosion()) as GameObject);
			break;
		case ITEM_TYPE.PURPLEBOX:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.PurpleCookieExplosion()) as GameObject);
			break;
		case ITEM_TYPE.REDBOX:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.RedCookieExplosion()) as GameObject);
			break;
		case ITEM_TYPE.YELLOWBOX:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.YellowCookieExplosion()) as GameObject);
			break;
		}
		
		if (explosion != null)
		{
			explosion.transform.position = transform.position;
		}
	}
	
	void GingerbreadExplosion()
	{
		SFXManager.instance.GingerbreadExplodeAudio();
		
		GameObject explosion = null;
		
		switch (type)
		{
		case ITEM_TYPE.ROCKET_1:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.BlueBoxExplosion()) as GameObject);
			break;
		case ITEM_TYPE.ROCKET_2:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.GreenBoxExplosion()) as GameObject);
			break;
		case ITEM_TYPE.ROCKET_3:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.OrangeCookieExplosion()) as GameObject);
			break;
		case ITEM_TYPE.ROCKET_4:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.PurpleCookieExplosion()) as GameObject);
			break;
		case ITEM_TYPE.ROCKET_5:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.RedCookieExplosion()) as GameObject);
			break;
		case ITEM_TYPE.ROCKET_6:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.YellowCookieExplosion()) as GameObject);
			break;
		}
		
		if (explosion != null)
		{
			explosion.transform.position = transform.position;
		}
	}
	
	void MarshmallowExplosion()
	{
		SFXManager.instance.MarshmallowExplodeAudio();
		
		GameObject explosion = null;
		
		explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.BreakableExplosion()) as GameObject);
		
		if (explosion != null)
		{
			explosion.transform.position = transform.position;
		}
	}
	
	public void ChocolateExplosion()
	{
		SFXManager.instance.ChocolateExplodeAudio();
		
		GameObject explosion = null;
		
		explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.MineExplosion()) as GameObject);
		
		if (explosion != null)
		{
			explosion.transform.position = transform.position;
		}
	}
	
	public void RockCandyExplosion()
	{
		SFXManager.instance.RockCandyExplodeAudio();
		
		GameObject explosion = null;
		
		switch (type)
		{
		case ITEM_TYPE.ROCK_CANDY_1:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.BlueBoxExplosion()) as GameObject);
			break;
		case ITEM_TYPE.ROCK_CANDY_2:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.GreenBoxExplosion()) as GameObject);
			break;
		case ITEM_TYPE.ROCK_CANDY_3:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.OrangeCookieExplosion()) as GameObject);
			break;
		case ITEM_TYPE.ROCK_CANDY_4:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.PurpleCookieExplosion()) as GameObject);
			break;
		case ITEM_TYPE.ROCK_CANDY_5:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.RedCookieExplosion()) as GameObject);
			break;
		case ITEM_TYPE.ROCK_CANDY_6:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.YellowCookieExplosion()) as GameObject);
			break;
		}
		
		if (explosion != null)
		{
			explosion.transform.position = transform.position;
		}
	}
	
	void CollectibleExplosion()
	{
		SFXManager.instance.CollectibleExplodeAudio();
	}
	
	void BombBreakerExplosion()
	{
		SFXManager.instance.BombExplodeAudio();
		
		BombBreakerDestroy();
		
		GameObject explosion = null;
		
		switch (type)
		{
		case ITEM_TYPE.BlueBox_BOMB:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.BreakerExplosion1()) as GameObject);
			break;
		case ITEM_TYPE.GreenBox_BOMB:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.BreakerExplosion2()) as GameObject);
			break;
		case ITEM_TYPE.ORANGEBOX_BOMB:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.BreakerExplosion3()) as GameObject);
			break;
		case ITEM_TYPE.PURPLEBOX_BOMB:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.BreakerExplosion4()) as GameObject);
			break;
		case ITEM_TYPE.REDBOX_BOMB:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.BreakerExplosion5()) as GameObject);
			break;
		case ITEM_TYPE.YELLOWBOX_BOMB:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.BreakerExplosion6()) as GameObject);
			break;
		}
		
		if (explosion != null)
		{
			explosion.transform.position = transform.position;
			explosion.transform.position = new Vector3(explosion.transform.position.x, explosion.transform.position.y, -12f);
		}
	}
	
	void RainbowExplosion()
	{
		SFXManager.instance.RainbowExplodeAudio();
		
		GameObject explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.RainbowExplosion()) as GameObject);
		
		if (explosion != null)
		{
			explosion.transform.position = transform.position;
		}
	}
	
	void XBreakerExplosion()
	{
		SFXManager.instance.ColRowBreakerExplodeAudio();
		
		XBreakerDestroy();
		
		GameObject explosion = null;
		GameObject animation = null;
		GameObject cross = null;
		
		switch (GetCookie(type))
		{
		case ITEM_TYPE.BlueBox:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.ColRowBreaker1()) as GameObject);
			animation = Instantiate(Resources.Load(Configuration.ColumnBreakerAnimation1()) as GameObject, transform.position, Quaternion.identity) as GameObject;
			break;
		case ITEM_TYPE.GreenBox:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.ColRowBreaker2()) as GameObject);
			animation = Instantiate(Resources.Load(Configuration.ColumnBreakerAnimation2()) as GameObject, transform.position, Quaternion.identity) as GameObject;
			break;
		case ITEM_TYPE.ORANGEBOX:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.ColRowBreaker3()) as GameObject);
			animation = Instantiate(Resources.Load(Configuration.ColumnBreakerAnimation3()) as GameObject, transform.position, Quaternion.identity) as GameObject;
			break;
		case ITEM_TYPE.PURPLEBOX:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.ColRowBreaker4()) as GameObject);
			animation = Instantiate(Resources.Load(Configuration.ColumnBreakerAnimation4()) as GameObject, transform.position, Quaternion.identity) as GameObject;
			break;
		case ITEM_TYPE.REDBOX:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.ColRowBreaker5()) as GameObject);
			animation = Instantiate(Resources.Load(Configuration.ColumnBreakerAnimation5()) as GameObject, transform.position, Quaternion.identity) as GameObject;
			break;
		case ITEM_TYPE.YELLOWBOX:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.ColRowBreaker6()) as GameObject);
			animation = Instantiate(Resources.Load(Configuration.ColumnBreakerAnimation6()) as GameObject, transform.position, Quaternion.identity) as GameObject;
			break;
		}
		
		if (animation != null)
		{
			cross = Instantiate(animation);
			animation.transform.Rotate(Vector3.back, 45);
			animation.transform.position = new Vector3(animation.transform.position.x, animation.transform.position.y, -12f);
		}
		
		if (cross != null)
		{
			cross.transform.Rotate(Vector3.back, -45);
			cross.transform.position = new Vector3(cross.transform.position.x, cross.transform.position.y, -12f);
		}
		
		if (explosion != null)
		{
			explosion.transform.position = transform.position;
		}
		
		GameObject.Destroy(animation, 1f);
	}
	
	void ColumnBreakerExplosion()
	{
		SFXManager.instance.ColRowBreakerExplodeAudio();
		
		ColumnDestroy();
		
		GameObject explosion = null;
		GameObject animation = null;
		
		switch (type)
		{
		case ITEM_TYPE.BlueBox_COLUMN:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.ColRowBreaker1()) as GameObject);
			animation = Instantiate(Resources.Load(Configuration.ColumnBreakerAnimation1()) as GameObject, transform.position, Quaternion.identity) as GameObject;
			break;
		case ITEM_TYPE.GreenBox_COLUMN:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.ColRowBreaker2()) as GameObject);
			animation = Instantiate(Resources.Load(Configuration.ColumnBreakerAnimation2()) as GameObject, transform.position, Quaternion.identity) as GameObject;
			break;
		case ITEM_TYPE.ORANGEBOX_COLUMN:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.ColRowBreaker3()) as GameObject);
			animation = Instantiate(Resources.Load(Configuration.ColumnBreakerAnimation3()) as GameObject, transform.position, Quaternion.identity) as GameObject;
			break;
		case ITEM_TYPE.PURPLEBOX_COLUMN:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.ColRowBreaker4()) as GameObject);
			animation = Instantiate(Resources.Load(Configuration.ColumnBreakerAnimation4()) as GameObject, transform.position, Quaternion.identity) as GameObject;
			break;
		case ITEM_TYPE.REDBOX_COLUMN:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.ColRowBreaker5()) as GameObject);
			animation = Instantiate(Resources.Load(Configuration.ColumnBreakerAnimation5()) as GameObject, transform.position, Quaternion.identity) as GameObject;
			break;
		case ITEM_TYPE.YELLOWBOX_COLUMN:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.ColRowBreaker6()) as GameObject);
			animation = Instantiate(Resources.Load(Configuration.ColumnBreakerAnimation6()) as GameObject, transform.position, Quaternion.identity) as GameObject;
			break;
		}
		
		if (explosion != null)
		{
			explosion.transform.position = transform.position;
		}
		
		if (animation != null)
		{
			animation.transform.position = new Vector3(animation.transform.position.x, animation.transform.position.y, -12f);
		}
		
		GameObject.Destroy(animation, 1f);
	}
	
	void BigColumnBreakerExplosion()
	{
		SFXManager.instance.ColRowBreakerExplodeAudio();
		
		ColumnDestroy(node.j - 1);
		ColumnDestroy(node.j);
		ColumnDestroy(node.j + 1);
		
		GameObject explosion = null;
		GameObject animation = null;
		
		switch (type)
		{
		case ITEM_TYPE.BlueBox_COLUMN:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.ColRowBreaker1()) as GameObject);
			animation = Instantiate(Resources.Load(Configuration.BigColumnBreakerAnimation1()) as GameObject, transform.position, Quaternion.identity) as GameObject;
			break;
		case ITEM_TYPE.GreenBox_COLUMN:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.ColRowBreaker2()) as GameObject);
			animation = Instantiate(Resources.Load(Configuration.BigColumnBreakerAnimation2()) as GameObject, transform.position, Quaternion.identity) as GameObject;
			break;
		case ITEM_TYPE.ORANGEBOX_COLUMN:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.ColRowBreaker3()) as GameObject);
			animation = Instantiate(Resources.Load(Configuration.BigColumnBreakerAnimation3()) as GameObject, transform.position, Quaternion.identity) as GameObject;
			break;
		case ITEM_TYPE.PURPLEBOX_COLUMN:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.ColRowBreaker4()) as GameObject);
			animation = Instantiate(Resources.Load(Configuration.BigColumnBreakerAnimation4()) as GameObject, transform.position, Quaternion.identity) as GameObject;
			break;
		case ITEM_TYPE.REDBOX_COLUMN:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.ColRowBreaker5()) as GameObject);
			animation = Instantiate(Resources.Load(Configuration.BigColumnBreakerAnimation5()) as GameObject, transform.position, Quaternion.identity) as GameObject;
			break;
		case ITEM_TYPE.YELLOWBOX_COLUMN:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.ColRowBreaker6()) as GameObject);
			animation = Instantiate(Resources.Load(Configuration.BigColumnBreakerAnimation6()) as GameObject, transform.position, Quaternion.identity) as GameObject;
			break;
		}
		
		if (explosion != null)
		{
			explosion.transform.position = transform.position;
		}
		
		if (animation != null)
		{
			animation.transform.position = new Vector3(animation.transform.position.x, animation.transform.position.y, -12f);
		}
		
		GameObject.Destroy(animation, 1f);
	}
	
	void CrossBreakerExplosion()
	{
		SFXManager.instance.ColRowBreakerExplodeAudio();
		
		ColumnDestroy();
		RowDestroy();
		
		GameObject explosion = null;
		GameObject columnEffect = null;
		GameObject rowEffect = null;
		
		switch (GetCookie(type))
		{
		case ITEM_TYPE.BlueBox:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.ColRowBreaker1()) as GameObject);
			columnEffect = Instantiate(Resources.Load(Configuration.ColumnBreakerAnimation1()) as GameObject, transform.position, Quaternion.identity) as GameObject;
			break;
		case ITEM_TYPE.GreenBox:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.ColRowBreaker2()) as GameObject);
			columnEffect = Instantiate(Resources.Load(Configuration.ColumnBreakerAnimation2()) as GameObject, transform.position, Quaternion.identity) as GameObject;
			break;
		case ITEM_TYPE.ORANGEBOX:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.ColRowBreaker3()) as GameObject);
			columnEffect = Instantiate(Resources.Load(Configuration.ColumnBreakerAnimation3()) as GameObject, transform.position, Quaternion.identity) as GameObject;
			break;
		case ITEM_TYPE.PURPLEBOX:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.ColRowBreaker4()) as GameObject);
			columnEffect = Instantiate(Resources.Load(Configuration.ColumnBreakerAnimation4()) as GameObject, transform.position, Quaternion.identity) as GameObject;
			break;
		case ITEM_TYPE.REDBOX:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.ColRowBreaker5()) as GameObject);
			columnEffect = Instantiate(Resources.Load(Configuration.ColumnBreakerAnimation5()) as GameObject, transform.position, Quaternion.identity) as GameObject;
			break;
		case ITEM_TYPE.YELLOWBOX:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.ColRowBreaker6()) as GameObject);
			columnEffect = Instantiate(Resources.Load(Configuration.ColumnBreakerAnimation6()) as GameObject, transform.position, Quaternion.identity) as GameObject;
			break;
		}
		
		if (columnEffect != null)
		{
			rowEffect = Instantiate(columnEffect as GameObject, transform.position, Quaternion.identity) as GameObject;
			columnEffect.transform.position = new Vector3(columnEffect.transform.position.x, columnEffect.transform.position.y, -12f);
		}
		
		if (rowEffect != null)
		{
			rowEffect.transform.Rotate(Vector3.back, 90);
			rowEffect.transform.position = new Vector3(rowEffect.transform.position.x, rowEffect.transform.position.y, -12f);
		}
		
		if (explosion != null)
		{
			explosion.transform.position = transform.position;
		}
		
		GameObject.Destroy(rowEffect, 1f);
		
		GameObject.Destroy(columnEffect, 1f);
	}
	
	void RowBreakerExplosion()
	{
		SFXManager.instance.ColRowBreakerExplodeAudio();
		
		RowDestroy();
		
		GameObject explosion = null;
		GameObject animation = null;
		
		switch (type)
		{
		case ITEM_TYPE.BlueBox_ROW:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.ColRowBreaker1()) as GameObject);
			animation = Instantiate(Resources.Load(Configuration.ColumnBreakerAnimation1()) as GameObject, transform.position, Quaternion.identity) as GameObject;
			break;
		case ITEM_TYPE.GreenBox_ROW:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.ColRowBreaker2()) as GameObject);
			animation = Instantiate(Resources.Load(Configuration.ColumnBreakerAnimation2()) as GameObject, transform.position, Quaternion.identity) as GameObject;
			break;
		case ITEM_TYPE.ORANGEBOX_ROW:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.ColRowBreaker3()) as GameObject);
			animation = Instantiate(Resources.Load(Configuration.ColumnBreakerAnimation3()) as GameObject, transform.position, Quaternion.identity) as GameObject;
			break;
		case ITEM_TYPE.PURPLEBOX_ROW:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.ColRowBreaker4()) as GameObject);
			animation = Instantiate(Resources.Load(Configuration.ColumnBreakerAnimation4()) as GameObject, transform.position, Quaternion.identity) as GameObject;
			break;
		case ITEM_TYPE.REDBOX_ROW:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.ColRowBreaker5()) as GameObject);
			animation = Instantiate(Resources.Load(Configuration.ColumnBreakerAnimation5()) as GameObject, transform.position, Quaternion.identity) as GameObject;
			break;
		case ITEM_TYPE.YELLOWBOX_ROW:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.ColRowBreaker6()) as GameObject);
			animation = Instantiate(Resources.Load(Configuration.ColumnBreakerAnimation6()) as GameObject, transform.position, Quaternion.identity) as GameObject;
			break;
		}
		
		if (animation != null)
		{
			animation.transform.Rotate(Vector3.back, 90);
			animation.transform.position = new Vector3(animation.transform.position.x, animation.transform.position.y, -12f);
		}
		
		if (explosion != null)
		{
			explosion.transform.position = transform.position;
		}
		
		GameObject.Destroy(animation, 1f);
	}
	
	void BigRowBreakerExplosion()
	{
		SFXManager.instance.ColRowBreakerExplodeAudio();
		
		RowDestroy(node.i - 1);
		RowDestroy(node.i);
		RowDestroy(node.i + 1);
		
		GameObject explosion = null;
		GameObject animation = null;
		
		switch (type)
		{
		case ITEM_TYPE.BlueBox_ROW:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.ColRowBreaker1()) as GameObject);
			animation = Instantiate(Resources.Load(Configuration.BigColumnBreakerAnimation1()) as GameObject, transform.position, Quaternion.identity) as GameObject;
			break;
		case ITEM_TYPE.GreenBox_ROW:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.ColRowBreaker2()) as GameObject);
			animation = Instantiate(Resources.Load(Configuration.BigColumnBreakerAnimation2()) as GameObject, transform.position, Quaternion.identity) as GameObject;
			break;
		case ITEM_TYPE.ORANGEBOX_ROW:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.ColRowBreaker3()) as GameObject);
			animation = Instantiate(Resources.Load(Configuration.BigColumnBreakerAnimation3()) as GameObject, transform.position, Quaternion.identity) as GameObject;
			break;
		case ITEM_TYPE.PURPLEBOX_ROW:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.ColRowBreaker4()) as GameObject);
			animation = Instantiate(Resources.Load(Configuration.BigColumnBreakerAnimation4()) as GameObject, transform.position, Quaternion.identity) as GameObject;
			break;
		case ITEM_TYPE.REDBOX_ROW:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.ColRowBreaker5()) as GameObject);
			animation = Instantiate(Resources.Load(Configuration.BigColumnBreakerAnimation5()) as GameObject, transform.position, Quaternion.identity) as GameObject;
			break;
		case ITEM_TYPE.YELLOWBOX_ROW:
			explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.ColRowBreaker6()) as GameObject);
			animation = Instantiate(Resources.Load(Configuration.BigColumnBreakerAnimation6()) as GameObject, transform.position, Quaternion.identity) as GameObject;
			break;
		}
		
		if (animation != null)
		{
			animation.transform.Rotate(Vector3.back, 90);
			animation.transform.position = new Vector3(animation.transform.position.x, animation.transform.position.y, -12f);
		}
		
		if (explosion != null)
		{
			explosion.transform.position = transform.position;
		}
		
		GameObject.Destroy(animation, 1f);
	}
	
	void BombXBreakerExplosion()
	{
		BombBreakerExplosion();
		
		XBreakerExplosion();
	}
	
	void CrossXBreakerExplosion()
	{
		CrossBreakerExplosion();
		
		XBreakerExplosion();
	}

	void col_BreakerExplosion(){
	
		ColumnBreakerExplosion ();
	}

	void row_BreakerExplosion()
	{
		RowBreakerExplosion ();
	}
	
	#endregion
	
	#region SpecialDestroy
	
	void BombBreakerDestroy()
	{
		List<Item> items = board.ItemAround(node);
		
		foreach (var item in items)
		{
			if (item != null)
			{
				if (item.type == ITEM_TYPE.ITEM_COLORCONE)
				{
					DestroyItemsSameColor(StageLoader.instance.RandomColor());
				}
				
				item.Destroy();
			}
		}
	}
	
	void XBreakerDestroy()
	{
		List<Item> items = board.XCrossItems(node);
		
		foreach (var item in items)
		{
			if (item != null)
			{
				if (item.type == ITEM_TYPE.ITEM_COLORCONE)
				{
					DestroyItemsSameColor(StageLoader.instance.RandomColor());
				}
				
				item.Destroy();
			}
		}
	}
	
	// destroy all items with the same color (when this color swap with a rainbow)
	public void DestroyItemsSameColor(int color)
	{
		List<Item> items = board.GetListItems();
		
		foreach (Item item in items)
		{
			if (item != null)
			{
				if (item.color == color)
				{
					board.sameColorList.Add(item);
				}
			}
		}
		
		board.DestroySameColorList();
	}
	
	public void RainbowDestroy(Item thisItem, Item otherItem)
	{
		if (thisItem.Destroyable() == false || otherItem.Destroyable() == false)
		{
			return;
		}
		
		if (thisItem.type == ITEM_TYPE.ITEM_COLORCONE) {
			
			if (otherItem.IsCookie ()) {
				DestroyItemsSameColor (otherItem.color);
				
				thisItem.Destroy ();
			}
			
			else if (otherItem.IsBombBreaker (otherItem.type) || otherItem.IsRowBreaker (otherItem.type) || otherItem.IsColumnBreaker (otherItem.type) || otherItem.IsXBreaker (otherItem.type)) {
				ChangeItemsType (otherItem.color, otherItem.type);
				
				thisItem.Destroy ();
			}

			else if (otherItem.type == ITEM_TYPE.ITEM_COLORCONE) {
				board.DoubleRainbowDestroy ();
				
				thisItem.Destroy ();
				
				otherItem.Destroy ();
			}
		} else if (otherItem.type == ITEM_TYPE.ITEM_COLORCONE) {
			
			if (thisItem.IsCookie ()) {
				DestroyItemsSameColor (thisItem.color);
				
				otherItem.Destroy ();
			}
			else if (thisItem.IsBombBreaker (thisItem.type) || thisItem.IsRowBreaker (thisItem.type) || thisItem.IsColumnBreaker (thisItem.type) || thisItem.IsXBreaker (thisItem.type)) {
				ChangeItemsType (thisItem.color, thisItem.type);
				
				otherItem.Destroy ();
			} 

			
			else if (thisItem.type == ITEM_TYPE.ITEM_COLORCONE) {
				board.DoubleRainbowDestroy ();
				
				thisItem.Destroy ();
				
				otherItem.Destroy ();
			}
		} 
	}
	
	void ColumnDestroy(int col = -1)
	{
		var items = new List<Item>();
		
		if (col == -1)
		{
			items = board.ColumnItems(node.j);
		}
		else
		{
			items = board.ColumnItems(col);
		}
		
		foreach (var item in items)
		{
			if (item != null)
			{
				if (item.type == ITEM_TYPE.ITEM_COLORCONE)
				{
					DestroyItemsSameColor(StageLoader.instance.RandomColor());
				}
				
				item.Destroy();
			}
		}
	}
	
	public void RowDestroy(int row = -1)
	{
		var items = new List<Item>();
		
		if (row == -1)
		{
			items = board.RowItems(node.i);
		}
		else
		{
			items = board.RowItems(row);
		}
		
		foreach (var item in items)
		{
			if (item != null)
			{
				if (item.type == ITEM_TYPE.ITEM_COLORCONE)
				{
					DestroyItemsSameColor(StageLoader.instance.RandomColor());
				}
				
				item.Destroy();
			}
		}
	}
	
	void TwoColRowBreakerDestroy(Item thisItem, Item otherItem)
	{
		if (thisItem == null || otherItem == null)
		{
			return;
		}
		
		if ((IsRowBreaker(thisItem.type) || IsColumnBreaker(thisItem.type)) && (IsRowBreaker(otherItem.type) || IsColumnBreaker(otherItem.type)))
		{
			thisItem.effect = BREAKER_EFFECT.CROSS;            
			otherItem.effect = BREAKER_EFFECT.NONE;
			
			thisItem.Destroy();
			otherItem.Destroy();
			
			board.FindMatches();
		}
	}
	
	void simpleColumnBreaderDestroy(Item thisItem, Item otherItem){
		
		if (thisItem == null || otherItem == null) {
			
			return;
		}
		
		if ((IsColumnBreaker (thisItem.type))) {
			thisItem.effect = BREAKER_EFFECT.COLUMN_EFFECT;	

			board.FindMatches ();
		}
	}


	void simpleRowBreakerDestroy(Item thisItem, Item otherItem)
	{
		if (thisItem == null || otherItem == null) {
			return;
		}

		if ((IsRowBreaker (thisItem.type))) {
		
			thisItem.effect = BREAKER_EFFECT.ROW_EFFECT;

			board.FindMatches ();
		}
	}
	void TwoBombBreakerDestroy(Item thisItem, Item otherItem)
	{
		if (thisItem == null || otherItem == null)
		{
			return;
		}
		
		if (IsBombBreaker(thisItem.type) && IsBombBreaker(otherItem.type))
		{
			thisItem.Destroy();
			otherItem.Destroy();
			
			board.FindMatches();
		}
	}
	
	void TwoXBreakerDestory(Item thisItem, Item otherItem)
	{
		if (thisItem == null || otherItem == null)
		{
			return;
		}
		
		if (IsXBreaker(thisItem.type) && IsXBreaker(otherItem.type))
		{
			thisItem.Destroy();
			otherItem.Destroy();
			
			board.FindMatches();
		}
	}
	
	void ColRowBreakerAndBombBreakerDestroy(Item thisItem, Item otherItem)
	{
		if (thisItem == null || otherItem == null)
		{
			return;
		}
		
		if ((IsRowBreaker(thisItem.type) || IsColumnBreaker(thisItem.type)) && IsBombBreaker(otherItem.type))
		{
			if (IsRowBreaker(thisItem.type))
			{
				thisItem.effect = BREAKER_EFFECT.BIG_ROW_BREAKER;
			}
			else if (IsColumnBreaker(thisItem.type))
			{
				thisItem.effect = BREAKER_EFFECT.BIG_COLUMN_BREAKER;
			}
			otherItem.type = otherItem.GetCookie(otherItem.type);
			
			thisItem.ChangeToBig();
		}
		else if ((IsRowBreaker(otherItem.type) || IsColumnBreaker(otherItem.type)) && IsBombBreaker(thisItem.type))
		{
			if (IsRowBreaker(otherItem.type))
			{
				otherItem.effect = BREAKER_EFFECT.BIG_ROW_BREAKER;
			}
			else if (IsColumnBreaker(otherItem.type))
			{
				otherItem.effect = BREAKER_EFFECT.BIG_COLUMN_BREAKER;
			}
			thisItem.type = otherItem.GetCookie(otherItem.type);
			
			otherItem.ChangeToBig();
		}
	}
	
	void ColRowBreakerAndXBreakerDestroy(Item thisItem, Item otherItem)
	{
		if (thisItem == null || otherItem == null)
		{
			return;
		}
		
		if ((IsXBreaker(thisItem.type) && (IsColumnBreaker(otherItem.type) || IsRowBreaker(otherItem.type))) || 
			(IsXBreaker(otherItem.type) && (IsColumnBreaker(thisItem.type) || IsRowBreaker(thisItem.type))))
		{
			thisItem.effect = BREAKER_EFFECT.CROSS_X_BREAKER;
			otherItem.type = otherItem.GetCookie(otherItem.type);
			
			thisItem.Destroy();
			otherItem.Destroy();
			
			board.FindMatches();
		}
	}
	
	void BombBreakerAndXBreakerDestroy(Item thisItem, Item otherItem)
	{
		if (thisItem == null || otherItem == null)
		{
			return;
		}
		
		if ((IsBombBreaker(thisItem.type) && IsXBreaker(otherItem.type)) || (IsBombBreaker(otherItem.type) && IsXBreaker(thisItem.type)))
		{
			thisItem.effect = BREAKER_EFFECT.BOMB_X_BREAKER;
			otherItem.type = otherItem.GetCookie(otherItem.type);
			
			thisItem.Destroy();
			otherItem.Destroy();
			
			board.FindMatches();
		}
	}
	
	#endregion
	
	#region Change
	
	void ChangeItemsType(int color, ITEM_TYPE changeToType)
	{
		List<Item> items = board.GetListItems();
		
		foreach (var item in items)
		{
			if (item != null)
			{
				if (item.color == color && item.IsCookie() == true)
				{
					GameObject explosion = CFX_SpawnSystem.GetNextObject(Resources.Load(Configuration.RainbowExplosion()) as GameObject);
					
					if (explosion != null) explosion.transform.position = item.transform.position;
					
					if (item.IsColumnBreaker(changeToType) || item.IsRowBreaker(changeToType))
					{
						if (item.IsCookie())
						{
							item.ChangeToColRowBreaker();
						}
					}
					else if (item.IsBombBreaker(changeToType))
					{
						if (item.IsCookie())
						{
							item.ChangeToBombBreaker();
						}
					}
					else if (item.IsXBreaker(changeToType))
					{
						if (item.IsCookie())
						{
							item.ChangeToXBreaker();
						}
					}
					
					board.changingList.Add(item);
				}
			}
		}
		
		board.DestroyChangingList();
	}
	
	void ChangeToBig()
	{
		if (changing == true) return;
		else changing = true;
		
		this.GetComponent<SpriteRenderer>().sortingLayerName = "Effect";
		
		iTween.ScaleTo(gameObject, iTween.Hash(
			"scale", new Vector3(2.5f, 2.5f, 0),
			"oncomplete", "CompleteChangeToBig",
			"easetype", iTween.EaseType.linear,
			"time", Configuration.instance.changingTime
		));
	}
	
	void CompleteChangeToBig()
	{
		this.Destroy();
		
		board.FindMatches();
	}
	
	#endregion
	
	#region Drop
	
	public void Drop()
	{
		if (dropping) return;
		else dropping = true;
		
		if (dropPath.Count > 1)
		{
			board.droppingItems++;
			
			var dist = (transform.position.y - dropPath[0].y);
			

			var time = (transform.position.y - dropPath[dropPath.Count - 1].y) / board.NodeSize();
			
			while (dist > 0.1f)
			{
				dist -= board.NodeSize();
				dropPath.Insert(0, dropPath[0] + new Vector3(0, board.NodeSize(), 0));
			}
			
			iTween.MoveTo(gameObject, iTween.Hash(
				"path", dropPath.ToArray(),
				"movetopath", false,
				"onstart", "OnStartDrop",
				"oncomplete", "OnCompleteDrop",
				"easetype", iTween.EaseType.linear,
				"time", Configuration.instance.dropTime * time
			));
		}
		else
		{
			Vector3 target = board.NodeLocalPosition(node.i, node.j);
			
			if (Mathf.Abs(transform.position.x - target.x) > 0.1f || Mathf.Abs(transform.position.y - target.y) > 0.1f)
			{
				board.droppingItems++;
				
				var time = (transform.position.y - target.y) / board.NodeSize();
				
				iTween.MoveTo(gameObject, iTween.Hash(
					"position", target,
					"onstart", "OnStartDrop",
					"oncomplete", "OnCompleteDrop",
					"easetype", iTween.EaseType.linear,
					"time", Configuration.instance.dropTime * time
				));
			}
			else
			{
				dropping = false;
			}
		}
	}
	
	public void OnStartDrop()
	{
		
	}
	
	public void OnCompleteDrop()
	{
		if (dropping)
		{
			SFXManager.instance.DropAudio();
			
			// reset
			dropPath.Clear();
			
			board.droppingItems--;
			
			// reset
			dropping = false;            
		}
	}
	
	#endregion
	
}
