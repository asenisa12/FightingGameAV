using UnityEngine;
using System.Collections;

public class EnemyAction : BaseActP2 {

	private float movSpeed;
	private bool retreat;
	private int punchesNum;
	private bool punchLR;
	public GUISkin skin;

	void Start () {

		MoveDir = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		punchLR = false;
		retreat = false;
		punchesNum = 0;
		movSpeed = 0.03f;
		SpawnPlayers sp = (SpawnPlayers)(GameObject.Find ("Spawn")).GetComponent("SpawnPlayers");
		target = sp.GetP1();
		player = sp.GetP2();


		Screen.showCursor = false;

			InvokeRepeating ("ChooseAction", 0.01f,0.01f);
	}

	void punchL(){
		animation.Play ("punchL1");
		Attack (-5);
	}
	private IEnumerator Punch() {
		yield return new WaitForSeconds(0.1f);

		if (!animation.isPlaying) {
			if (!punchLR) {
				animation.Play ("punchL1");
				Attack (-8);
				punchLR = true;
			}else{
				animation.Play ("punchR");
				Attack (-14);
				punchLR = false;
			}
		}
	}

	private void MoveL(){
		animation.Play("move1");
		MoveDir.x -= movSpeed; 
		transform.position = MoveDir;
	}

	private void MoveR(){
		animation.Play ("moveBack");
		MoveDir.x += movSpeed; 
		transform.position = MoveDir;
	}


	private void ChooseAction(){

		if (retreat){
			MoveR();
			if(Distance() >2.5f) 
				retreat=false;
		}else if (Distance () > 0.73f) {
			MoveL ();
		}else if((GetTargetAnim()==1 || GetTargetAnim()==2) && GetPlayingAnim()!=3 && Distance ()< 0.74f){

			punchesNum++;
			if(punchesNum<=2){
				animation.Play ("punched");
			}else if(punchesNum>2 && punchesNum<=3){
				animation.Play ("defend");
			}else if(punchesNum>3){
				animation.Play ("defend");
				retreat =true;
				punchesNum =0;
			}
		}else if(Distance () < 0.74f) {
			StartCoroutine(Punch());
		}

	}

	IEnumerator Timer() {
		yield return new WaitForSeconds(2);
		Application.LoadLevel("Menu");
	}
	void OnGUI(){
		GUI.skin = skin;
		if (PlEnHealthStat()==1){
			GUI.Label (new Rect (Screen.width/ 2 - 200, Screen.height / 2 - 135, 200, 40),"Player2 WINS!!");
		}
	}

	void Update () {
		if (PlEnHealthStat () > 0) {
			CancelInvoke();

			if (PlEnHealthStat()==1)
				StartCoroutine(Timer());
		}
	}
}
