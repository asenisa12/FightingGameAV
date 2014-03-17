using UnityEngine;
using System.Collections;

public class HealthBarP2 : MonoBehaviour {
	private int maxHealth;
	private int curHealth;
	private float healthBarLength;
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("player2");
		curHealth = 100;
		maxHealth = 100;
		healthBarLength = Screen.width / 3;
	}
	public void adjustHealth(int adj){
		ActionsP2 ac = (ActionsP2)player.GetComponent ("ActionsP2");
		if (ac.GetPlayingAnim() == 3)
			adj /= 2;

		curHealth += adj;
		
		if (curHealth < 0)
			curHealth = 0;
		
		healthBarLength = (Screen.width / 3) * (curHealth / (float)maxHealth);
	}
	void OnGUI(){
		GUI.Box (new Rect(Screen.width-(Screen.width/3)-10, 10, healthBarLength, 20),""+ curHealth);
	}

	public int GetHealth(){
		return curHealth;
	}
	// Update is called once per frame
	void Update () {
		//adjustHealth (0);
	}
}
