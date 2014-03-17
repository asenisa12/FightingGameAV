using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
	private int maxHealth;
	static int curHealth = 100;
	private float healthBarLength;
	// Use this for initialization
	void Start () {
		maxHealth = 100;
		healthBarLength = Screen.width / 3;
	}
	public void adjustHealth(int adj){
		curHealth += adj;

		if (curHealth < 0)
						curHealth = 0;

		healthBarLength = (Screen.width / 3) * (curHealth / (float)maxHealth);
	}
	void OnGUI(){
		GUI.Box (new Rect(10, 10, healthBarLength, 20),""+ curHealth);
	}
	// Update is called once per frame
	void Update () {
		adjustHealth (0);
	}
}
