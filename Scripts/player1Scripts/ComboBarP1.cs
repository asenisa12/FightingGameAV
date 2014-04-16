using UnityEngine;
using System.Collections;

public class ComboBarP1 : MonoBehaviour {
	private float maxPoints;
	static float curPoints;
	private float comboBarLength;
	private GameObject player;

	void Start () {
		player = GameObject.Find ("player1");
		maxPoints = 5f;
		curPoints = 0f;
		comboBarLength = 0;
	}
	public void AdjustPoints(int adj){
		curPoints += adj;
		if(curPoints>maxPoints)
			curPoints -= adj;
		comboBarLength = (Screen.width / 3) * (curPoints / (float)maxPoints);
	}
	private float Percent(){
		return ( curPoints/ maxPoints) * 100;
	}
	void OnGUI(){
		GUI.Box (new Rect(10, 35, comboBarLength, 20),(int)Percent()+"%");
	}

	public int GetPoints(){
		return (int)curPoints;
	}

}

