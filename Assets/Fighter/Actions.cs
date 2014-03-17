using UnityEngine;
using System.Collections;

public class Actions : MonoBehaviour {
	// Use this for initialization
	public float movSpeed = 0.13f;
	public float charcterPosX;
	static int actionNo;
	private GameObject target;
	void Start () {
		target = GameObject.Find ("player1");
	}
	private int Action(){
		if (Input.GetKey ("left")) {	
			animation.Play ("move1");

			if(Distance()>0.6197141)
				transform.position = new Vector3 (charcterPosX = transform.position.x - movSpeed, transform.position.y, transform.position.z);
			return 1;
		}
		else if (Input.GetKey ("right")) {
			animation.Play ("moveBack");	
			//animation.Play ("default");
			transform.position = new Vector3 (charcterPosX = transform.position.x + movSpeed, transform.position.y, transform.position.z);
			return 1;
		} else if (Input.GetKeyDown ("e")) {
			animation.Play ("punchR");
			Attack(-8);
			return 3;
		} else if (Input.GetKeyDown ("q")) {
			animation.Play ("punchL1");
			Attack(-5);
			return 4;
		}
		else if (Input.GetKeyDown("d")){
			animation.Play ("defend");
			return 5;
		} else {
			if(!animation.isPlaying)
				animation.Play("default");
		}
		return 0;
	}
	private float Distance(){
		return	Vector3.Distance (target.transform.position, transform.position);
	}
	private void Attack(int damage){
		Debug.Log (Distance());

		if (Distance() < 0.63f) {
			HealthBar eh = (HealthBar)target.GetComponent ("HealthBar");
			eh.adjustHealth (damage);
		}
	}
	void Update () {
		actionNo = Action();
	}
}
