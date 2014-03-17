using UnityEngine;
using System.Collections;

public class ActionsP2 : MonoBehaviour {
	// Use this for initialization
	public float movSpeed = 0.13f;
	public float charcterPosX;
	private int actionNo;
	private GameObject target;
	private GameObject player;
	GUIStyle Font;

	void Start () {
		actionNo = 0;
		target = GameObject.Find ("player1");
		player = GameObject.Find ("player2");
		Font  = new GUIStyle();
		
		Font.fontSize = 70;
		Screen.showCursor = false;
	}

	private int Action(){
		if (PlEnHealthStat () > 0) {
			if (PlEnHealthStat()==1)
				StartCoroutine(Timer());
			return 0;
		}

		if (Input.GetKey ("left")) {	
			animation.Play ("move1");
			
			if(Distance()>0.73)
				transform.position = new Vector3 (charcterPosX = transform.position.x - movSpeed, transform.position.y, transform.position.z);
			return 1;
		}else if (Input.GetKeyDown(".")){
			animation.Play ("defend");
			return 5;
		}else if((GetTargetAnim()==1 || GetTargetAnim()==2) && GetPlayingAnim()!=3){
			if (Distance ()< 0.74f)
				animation.Play ("punched");
			return 6;
		}else if (Input.GetKey ("right")) {
			animation.Play ("moveBack");	
			transform.position = new Vector3 (charcterPosX = transform.position.x + movSpeed, transform.position.y, transform.position.z);
			return 1;
		} else if (Input.GetKeyDown (",")) {
			animation.Play ("punchR");
			Attack(-8);
			return 3;
		} else if (Input.GetKeyDown ("m")) {
			animation.Play ("punchL1");
			Attack(-5);
			return 4;
		} else {
			if(!animation.isPlaying)
				animation.Play("default");
			return 0;
		}
	}

	private float Distance(){
		return	Vector3.Distance (target.transform.position, transform.position);
	}

	private void Attack(int damage){
		Debug.Log (Distance());
		
		if (Distance() < 0.74f) {
			HealthBarP1 eh = (HealthBarP1)target.GetComponent ("HealthBarP1");
			eh.adjustHealth (damage);
		}
	}

	private int GetTargetAnim(){
		ActionsP1 ea = (ActionsP1)target.GetComponent ("ActionsP1");
		return ea.GetPlayingAnim ();
	}

	public int GetPlayingAnim(){
		if (animation ["punchR"].enabled)
			return 1;
		if (animation ["punchL1"].enabled)
			return 2;
		if (animation ["defend"].enabled)
			return 3;
		return 0;
	}

	private int PlEnHealthStat(){
		HealthBarP1 eh = (HealthBarP1)target.GetComponent ("HealthBarP1");
		if (eh.GetHealth () == 0) 
				return 1;
		HealthBarP2 ph = (HealthBarP2)player.GetComponent ("HealthBarP2");
		if (ph.GetHealth () == 0)
				return 2;

		return 0;
	}
	IEnumerator Timer() {
		yield return new WaitForSeconds(2);
		Application.LoadLevel("Menu");
	}
	void OnGUI(){
		if (PlEnHealthStat()==1){
			GUI.Label (new Rect (Screen.width/ 2 - 200, Screen.height / 2 - 135, 200, 40),"Player2 WINS!!", Font);
		}
	}
	void Update () {
		actionNo = Action();
	}
}

