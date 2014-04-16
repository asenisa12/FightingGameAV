using UnityEngine;
using System.Collections;

public class ActionsP1 :BaseActP1 {
	// Use this for initialization
	private float movSpeed = 0.05f;
	public float charcterPosX;
	private int actionNo;
	public GUISkin skin;


	void Start () {
		MoveDir = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		actionNo = 0;
		SpawnPlayers sp = (SpawnPlayers)(GameObject.Find ("Spawn")).GetComponent("SpawnPlayers");
		target = sp.GetP2();
		player = sp.GetP1();

	}
	
	private int Action(){
		if (PlEnHealthStat () > 0) {
			if (PlEnHealthStat()==1)
				StartCoroutine(Timer());
			return 0;
		}

		if (Input.GetKey ("a")&&transform.position.y<0.3f) {
			//if(Front())
				//Debug.Log("Object is to the right");
			animation.Play ("moveBack");
			//Debug.Log (Distance());
	
			return 1;
		}else if (Input.GetKey ("d")&&transform.position.y<0.3f) {
			animation.Play ("move1");	

			return 2;
		}else if(Input.GetKeyDown("w")){
			//animation.Play("Jump");
			InvokeRepeating ("Jump", 0.02f,0.02f);
			return 7;
		}else if (Input.GetKeyDown("r")){
			animation.Play ("defend");
			return 5;
		}else if((GetTargetAnim()==1 || GetTargetAnim()==2) && GetPlayingAnim()!=3 && Distance ()< 0.74f){
				animation.Play ("punched");
			return 6;
		} else if (Input.GetKeyDown ("q")) {
			if (animation["default"].enabled || animation["defend"].enabled) {
			animation.Play ("punchR");
			Attack(-14);
			}
			return 3;
		} else if (Input.GetKeyDown ("e")) {
			if (animation["default"].enabled || animation["defend"].enabled) {
				animation.Play ("punchL1");
				Attack(-8);
			}
			return 4;
		} else {
			if(!animation.isPlaying)
				animation.Play("default");
			return 0;
		}
	}

	IEnumerator Timer() {
		yield return new WaitForSeconds(2);
		Application.LoadLevel("Menu");
	}
	void OnGUI(){
		if (PlEnHealthStat()==1){
			GUI.contentColor = Color.red;
			GUI.skin = skin;
			GUI.Label (new Rect (Screen.width/ 2 -200, Screen.height / 2 - 135, 200, 40),"Player1 WINS!!" );
		}
	}

	public int GetActionNum(){
		return actionNo;
	}
	void Update () {
		actionNo = Action();
	}

	void FixedUpdate(){
		if(actionNo == 1){
			MoveDir.x -= movSpeed; 
			transform.position = MoveDir;
		}
		if(actionNo == 2){
			if(Distance()>0.73)
				MoveDir.x += movSpeed; 
				transform.position = MoveDir;
		}
	}
}