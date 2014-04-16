using UnityEngine;
using System.Collections;

public class SpawnPlayers : MonoBehaviour {

	private GameObject player1;
	private GameObject player2;

	private Vector3 positionP1;
	private Vector3 positionP2;

	private Quaternion rotationP1;
	private Quaternion rotationP2;

	void Start () {
		positionP2 = new Vector3(1.45f,0.03f,-22.6f);
		positionP1 = new Vector3(-1.45f,0.03f,-22.6f);

		rotationP2 = Quaternion.Euler(0,276.1699f,0); 
		rotationP1 = Quaternion.Euler(0,79.08807f,0); 
		Info info = (Info)(GameObject.Find("info")).GetComponent("Info");
		player1 = (GameObject)Instantiate((Object)GameObject.Find(info.GetNameP1()),positionP1,rotationP1);
		player2 = (GameObject)Instantiate((Object)GameObject.Find(info.GetNameP2()),positionP2,rotationP2);

		player1.AddComponent("ActionsP1");
		player1.AddComponent("HealthBarP1");

		player2.AddComponent("Manage");
		player2.AddComponent("HealthBarP2");
	}

	public GameObject GetP1(){
		return player1;
	}
	public GameObject GetP2(){
		return player2;
	}
}
