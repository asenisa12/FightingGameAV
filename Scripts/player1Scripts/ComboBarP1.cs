using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ComboBarP1 : MonoBehaviour {
	private float maxPoints;
	static float curPoints;
	private float comboBarLength;
	private GameObject player;
	private List<float> combo = new List<float>(); 
	private int[] combin1 = new int[4]{1,1,2,1};
	private int[] combin2 = new int[4]{2,1,1,2};

	void Start () {

		SpawnPlayers sp = (SpawnPlayers)(GameObject.Find ("Spawn")).GetComponent("SpawnPlayers");
		player = sp.GetP1();
		maxPoints = 2f;
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

		GUI.skin = (GUISkin)Resources.Load("ComboSkin", typeof(GUISkin));
		GUI.Box (new Rect(10, 55, comboBarLength, 40),(int)Percent()+"%");
	}

	public int GetPoints(){
		return (int)curPoints;
	}

	private int PlayingAnim(){
		ActionsP1 act = (ActionsP1)player.GetComponent("ActionsP1"); 
		return act.GetPlayingAnim();
	}

	public void ComboPointsAdj(int act){
		if(combo.Count<5){
			combo.Add(act);
		} else combo.Clear();

	}

	private void CheckForCombo(){

		for(int i=0;i <combo.Count; i++){
			if(combo[i]!=combin1[i]){
				for(int j=0;j <combo.Count; j++)
					if(combo[j]!=combin2[j]){
						combo.Clear();
						return;
					}
				AdjustPoints(1);
				combo.Clear();
				return;	
			}
		}
		AdjustPoints(1);
		combo.Clear();
		return;
	}

	public bool Full(){
		return curPoints == maxPoints;
	}

	private float Distance(){
		ActionsP1 act = (ActionsP1)player.GetComponent("ActionsP1"); 
		return act.Distance();
	}

	void Update(){
		if (animation ["punched"].enabled || Distance() > 0.74f) combo.Clear();
		if(combo.Count == 4)	
			CheckForCombo();
	}
}

