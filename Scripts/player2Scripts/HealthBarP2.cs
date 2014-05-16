using UnityEngine;
using System.Collections;


public class HealthBarP2 : MonoBehaviour {
	private float maxHealth;
	private float curHealth;
	private float healthBarLength;
	private GameObject player;
	private SpawnPlayers sp;
	public GUISkin skin;

	void Start () {
		sp = (SpawnPlayers)(GameObject.Find ("Spawn")).GetComponent("SpawnPlayers");
		player = sp.GetP2();
		curHealth = 600f;
		maxHealth = 600f;
		healthBarLength = Screen.width / 3;
		skin = (GUISkin)Resources.Load("HealthSkin", typeof(GUISkin));

	}
	public void AdjustHealth(int adj){
		ActionsP2 ac = (ActionsP2)player.GetComponent ("ActionsP2");
		if (ac != null) {
			if (ac.GetPlayingAnim() == 3)
				adj /= 2;
		}else{
			EnemyAction act = (EnemyAction)player.GetComponent ("EnemyAction");
			if (act.GetPlayingAnim() == 3)
				adj /= 2;
		}

		curHealth += adj;
		
		if (curHealth < 0)
			curHealth = 0;
		
		healthBarLength = (Screen.width / 3) * (curHealth / (float)maxHealth);
	}
	private float Percent(){
		return ( curHealth/ maxHealth) * 100;
	}
	void OnGUI(){
		GUI.skin = skin;
		GUI.Box (new Rect(Screen.width-(Screen.width/3)-10, 10, healthBarLength, 40),""+ (int)Percent()+"%");
	}

	public int GetHealth(){
		return (int)curHealth;
	}
}
