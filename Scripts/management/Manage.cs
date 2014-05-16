using UnityEngine;
using System.Collections;

public class Manage : MonoBehaviour {
	
	void Start () {
		Info info = (Info)(GameObject.Find("info")).GetComponent("Info");
		SpawnPlayers sp = (SpawnPlayers)(GameObject.Find ("Spawn")).GetComponent("SpawnPlayers");
		BaseActP1 ba = (BaseActP1)(sp.GetP1()).GetComponent("BaseActP1");

		if (info.GetSingleplayer()) {
			gameObject.AddComponent ("EnemyAction");
			ba.computerplayer = true;
		} else{
			gameObject.AddComponent ("ActionsP2");
			ba.computerplayer = false;
		}
		gameObject.AddComponent("ComboBarP2");
	}
}
