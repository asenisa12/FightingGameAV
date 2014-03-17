using UnityEngine;
using System.Collections;

public class HealthBarP1 : MonoBehaviour {
	private int maxHealth;
	static int curHealth;
	private float healthBarLength;
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("player1");
		maxHealth = 100;
		curHealth = 100;
		healthBarLength = Screen.width / 3;
	}
	public void adjustHealth(int adj){
		ActionsP1 ac = (ActionsP1)player.GetComponent ("ActionsP1");
		if (ac.GetPlayingAnim() == 3)
			adj /= 2;

		curHealth += adj;

		if (curHealth < 0)
			curHealth = 0;
		
		healthBarLength = (Screen.width / 3) * (curHealth / (float)maxHealth);
	}
	void OnGUI(){
		GUI.Box (new Rect(10, 10, healthBarLength, 20),""+ curHealth);
	}
	// Update is called once per frame

	public int GetHealth(){
		return curHealth;
	}
	void Update () {

	}
}