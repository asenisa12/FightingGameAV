using UnityEngine;
using System.Collections;


public class ActionsP2 : BaseActP2{

	private float movSpeed = 0.05f;
	public float charcterPosX;
	private int actionNo;
	public GUISkin skin;


	void Start () {
		MoveDir = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		actionNo = 0;
		SpawnPlayers sp = (SpawnPlayers)(GameObject.Find ("Spawn")).GetComponent("SpawnPlayers");
		target = sp.GetP1();
		player = sp.GetP2();
		skin = (GUISkin)Resources.Load("P1Skin", typeof(GUISkin));
		Screen.showCursor = false;
	}

	private int Action(){

		if (PlEnHealthStat () > 0) {
			return 0;
		}
		if(Input.GetKeyDown("up")){
			InvokeRepeating ("Jump", 0.02f,0.02f);
			return 7;
		}else if (Input.GetKey ("left")&&transform.position.y<0.3f) {	
			animation.Play ("move1");
			Debug.Log (Distance());
			return 1;
		}else if (Input.GetKey ("right")&&transform.position.y<0.3f) {
			
			animation.Play ("moveBack");	
			
			return 2;
		}else if (Input.GetKeyDown(".")){
			animation.Play ("defend");
			return 5;
		}else if((GetTargetAnim()==1 || GetTargetAnim()==2) && GetPlayingAnim()!=3 && Distance ()< 0.74f){
				animation.Play ("punched");
			return 6;
		}else if (Input.GetKeyDown (",")) {
			if (animation["default"].enabled || animation["defend"].enabled) {
				animation.Play ("punchR");
				AddToCombo(2);
				Attack(-14);
			}
			return 3;
		} else if (Input.GetKeyDown ("m")) {
			if (animation["default"].enabled || animation["defend"].enabled) {
				animation.Play ("punchL1");
				AddToCombo(1);
				Attack(-8);
			}
			return 4;
		} else if(Input.GetKeyDown("n")){
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
		GUI.skin = skin;
		if (PlEnHealthStat()==1){
			GUI.Label (new Rect (Screen.width/ 2 - 200, Screen.height / 2 - 135, 200, 40),"Player2 WINS!!");
		}
	}
	void Update () {
		actionNo = Action();
	}
	void FixedUpdate(){
		if (actionNo == 1) {
			if(Distance()>0.73){
				MoveDir.x -= movSpeed; 
				transform.position = MoveDir;
			}
		}
		if (actionNo == 2) {
			MoveDir.x += movSpeed; 
			transform.position = MoveDir;
		}

	}
}

