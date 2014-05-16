using UnityEngine;
using System.Collections;

public class Info : MonoBehaviour {

	private bool Singleplayer = false;
	private string nameP1;
	private string nameP2;
	private string nameMap;

	public void SetNameMap(string name){
		nameMap = name;
	}

	public string GetNameMap(){
		return nameMap;
	}

	public void SetNameP1(string name){
		nameP1 = name;
	}

	public void SetNameP2(string name){
		nameP2 = name;
	}

	public string GetNameP1(){
		return nameP1;
	}
	public string GetNameP2(){
		return nameP2;
	}

	public void SetSinglePlayer (bool var){
		Singleplayer = var;
	}

	public bool GetSingleplayer(){
		return Singleplayer;
	}

	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}
}