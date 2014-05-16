using UnityEngine;
using System.Collections;

public class HealthBarP1 : MonoBehaviour {
	private float maxHealth;
	private float curHealth;
	private float healthBarLength;
	private GameObject player;
	public GUISkin skin;

	void Start () {
		SpawnPlayers sp = (SpawnPlayers)(GameObject.Find ("Spawn")).GetComponent("SpawnPlayers");
		player = sp.GetP1();
		maxHealth = 600f;
		curHealth = 600f;
		healthBarLength = Screen.width / 3;
		skin = (GUISkin)Resources.Load("HealthSkin", typeof(GUISkin));
	}
	public void AdjustHealth(int adj){
		ActionsP1 ac = (ActionsP1)player.GetComponent ("ActionsP1");
		if (ac.GetPlayingAnim() == 3)
			adj /= 2;

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
		GUI.Box (new Rect(10, 10, healthBarLength, 40),(int)Percent()+"%");
	}


	public int GetHealth(){
		return (int)curHealth;
	}

}