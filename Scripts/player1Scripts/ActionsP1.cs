using UnityEngine;
using System.Collections;

public class ActionsP1 :BaseActP1 {
	// Use this for initialization
	private float movSpeed = 0.05f;
	public float charcterPosX;
	private int actionNo;
	private GUISkin skin;
	private int actionNo2=0;


	void Start () {
		MoveDir = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		actionNo = 0;
		SpawnPlayers sp = (SpawnPlayers)(GameObject.Find ("Spawn")).GetComponent("SpawnPlayers");
		target = sp.GetP2();
		player = sp.GetP1();
		skin = (GUISkin)Resources.Load("P1Skin", typeof(GUISkin));

	}
	
	private int Action(){
		if (Input.GetKey ("escape")){
			Application.LoadLevel("Menu");
		}

		if (PlEnHealthStat () > 0) {
			animation.Play("default");
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
		}else if((/*GetTargetAnim()==1 || */GetTargetAnim()==2) && GetPlayingAnim()!=3 && Distance ()< 0.74f){
				animation.Play ("punched");
			return 6;
		} else if (Input.GetKeyDown ("e")) {
			if (animation["default"].enabled || animation["defend"].enabled) {
			animation.Play ("punchR");
			AddToCombo(2);
			Attack(-14);
			}
			return 3;
		} else if (Input.GetKeyDown ("q")) {
			if (animation["default"].enabled || animation["defend"].enabled) {
				animation.Play ("punchL1");
				Attack(-8);
				AddToCombo(1);
			}
			return 4;
		} else if(Input.GetKeyDown("z")){
			if(FullComboBar() && (animation["default"].enabled || animation["defend"].enabled)){
				animation.Play ("punchL1");
				Attack(-60);
				ClearCombo();
			}
			return 8;
		} else {
			if(!animation.isPlaying)
				animation.Play("default");
			return 0;
		}
	}
	/*
	IEnumerator Timer() {
		yield return new WaitForSeconds(2);
		Application.LoadLevel("Menu");
	}*/

	void OnGUI(){
		GUI.skin = (GUISkin)Resources.Load("Block", typeof(GUISkin));
		if (GUI.Button (new Rect (10,Screen.height/1.3f-(BoxSide()+10), BoxSide(), BoxSide()), "DEFEND")) {
			animation.Play ("defend");
		}

		GUI.skin = (GUISkin)Resources.Load("AttackSkin", typeof(GUISkin));
		if (GUI.Button (new Rect (10,Screen.height/1.3f, BoxSide(), BoxSide()), "LEFT")) {
			if (animation["default"].enabled || animation["defend"].enabled || animation["punched"].enabled) {
				animation.Play ("punchL1");
				Attack(-8);
				AddToCombo(1);
			}
		}

		if (GUI.Button (new Rect ((BoxSide()+20),Screen.height/1.3f, BoxSide(), BoxSide()), "RIGHT")) {
			if (animation["default"].enabled || animation["defend"].enabled) {
				animation.Play ("punchR");
				AddToCombo(2);
				Attack(-14);
			}
		}

		GUI.skin = (GUISkin)Resources.Load("Left", typeof(GUISkin));
		if (GUI.Button (new Rect (Screen.width -2*(BoxSide()+10),Screen.height/1.3f, BoxSide(), BoxSide()), "MOVEL")) {
			animation.Play ("move1");	
			actionNo2 = 1;
		}

		GUI.skin = (GUISkin)Resources.Load("Right", typeof(GUISkin));
		if (GUI.Button (new Rect (Screen.width -(BoxSide()+10),Screen.height/1.3f, BoxSide(), BoxSide()), "MOVER")) {
			animation.Play ("moveBack");
			actionNo2 = 2;
		}

		if (PlEnHealthStat()==1){
			GUI.skin = skin;
			GUI.Label (new Rect (Screen.width/ 2 -200, Screen.height / 2 - 135, 2000, 400),"Player1 WINS!!" );
		}

		if(FullComboBar()){
			GUI.skin = (GUISkin)Resources.Load("SuperPunch", typeof(GUISkin));
			if (GUI.Button (new Rect (Screen.width -(BoxSide()+10),Screen.height/1.3f-(BoxSide()+10), BoxSide(), BoxSide()), "SUPER")) {
				if(animation["default"].enabled || animation["defend"].enabled){
					animation.Play ("punchL1");
					Attack(-60);
					ClearCombo();
				}
			}
		}

		GUI.skin = (GUISkin)Resources.Load("MenuButtons", typeof(GUISkin));
		if (GUI.Button (new Rect (Screen.width/2 -Screen.width/12,10, Screen.width/6, Screen.width/18), "MENU")){ 
			Application.LoadLevel("Menu");
		}
	}
	private float BoxSide(){
		return Screen.width/8;
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
		if(actionNo == 2 && transform.position.x > -31f){
			if(Distance()>0.73)
				MoveDir.x += movSpeed; 
				transform.position = MoveDir;
		}
		if(actionNo2 == 1 && Distance()<14f){
			animation.Play ("move1");	
			MoveDir.x -= movSpeed;
			transform.position = MoveDir;
		}
		if(actionNo2 == 2 && (Distance()>0.73f && transform.position.x > -31f)){
			animation.Play ("moveBack");
			MoveDir.x += movSpeed; 
			transform.position = MoveDir;
		}
	}
}