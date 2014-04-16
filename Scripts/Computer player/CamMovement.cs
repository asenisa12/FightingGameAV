using UnityEngine;
using System.Collections;

public class CamMovement : MonoBehaviour {

	private GameObject player1;
	private GameObject player2;

	private float camPosXadj;

	private float prevDis;

	void Start () {

		SpawnPlayers sp = (SpawnPlayers)(GameObject.Find ("Spawn")).GetComponent("SpawnPlayers");
		player1 = sp.GetP1();
		player2 = sp.GetP2();
		prevDis = Distance();
	}

	private float Distance(){
		return Vector3.Distance(player1.transform.position, player2.transform.position);
	}

	// Update is called once per frame
	void Update () {
		camPosXadj = player1.transform.position.x + Distance () / 2;
		transform.position = new Vector3(camPosXadj, transform.position.y, transform.position.z); 
		if (Distance () > 6 && prevDis < Distance ()) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - 0.05f);
			prevDis = Distance();
		}
		if (Distance () > 6 && prevDis > Distance ()) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + 0.05f);
			prevDis = Distance();
		}
			
	}
}
