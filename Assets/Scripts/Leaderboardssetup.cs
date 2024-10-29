
using UnityEngine;
using System.Collections;



public class Leaderboardssetup : MonoBehaviour {
	private static Leaderboardssetup _instance = null;
	public string leaderboardid = "";
	// Use this for initialization
	private Leaderboardssetup() {
//		PlayGamesPlatform.DebugLogEnabled = true;
//		PlayGamesPlatform.Activate ();
	}


	public static Leaderboardssetup Instance {
		get {
			if (_instance == null) {
				_instance = new Leaderboardssetup();
			}
			return _instance;
		}
	}

	void Start(){
		
	}

}
