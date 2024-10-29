/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;
/** Rectangle transform rotator */
public class toyAnimation : MonoBehaviour {

    public void log(string s){
        Debug.Log(s);
    }
    RectTransform tr;

	public float range = 10f;
	public float Speed = 0.5f;

    Quaternion target;

	void Start () {
		tr = GetComponent<RectTransform>();
        target = Quaternion.Euler(0,0,range);
	}

	void Update () {

        if(
            target.Equals(Quaternion.Euler(0,0,range)) &&
            (int)(tr.rotation.eulerAngles.z +0.5f) == (int)target.eulerAngles.z
        ){
            //log("A");
            target = Quaternion.Euler(0,0,-range);
        }

        if(
            target.Equals(Quaternion.Euler(0,0,-range)) &&
            (int)(tr.rotation.eulerAngles.z +0.5f) == (int)target.eulerAngles.z
        ){
            //log("B");
            target = Quaternion.Euler(0,0,range);
        }


		tr.rotation = Quaternion.RotateTowards(tr.rotation,target,Speed);
	}
}
