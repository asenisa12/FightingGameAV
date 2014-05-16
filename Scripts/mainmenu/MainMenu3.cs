using UnityEngine;
using System.Collections;

public class MainMenu3 : MonoBehaviour {
	public GUISkin skin1;
	public GUISkin skin2;
	public GUISkin skin3;
	public GUISkin skin4;
	public GUISkin skin5;

	void OnGUI () {
		int size = Screen.width/5;

		GUI.skin = skin1;
		GUI.Label(new Rect(Screen.width/2-250,Screen.height/3,1000,200),"Choose map");

		GUI.skin = skin2;
		if (GUI.Button (new Rect (Screen.width/2-(2*size+10),Screen.height/2f, size, size), "Desert")) {
			Info info = (Info)(GameObject.Find("info")).GetComponent("Info");
			info.SetNameMap("Desert");
			Application.LoadLevel("Loading");
		}

		GUI.skin =skin3;
		if (GUI.Button (new Rect (Screen.width/2-(size+5),Screen.height/2f, size, size), "COMMING SOON...")) {

		}

		GUI.skin =skin4;
		if (GUI.Button (new Rect (Screen.width/2,Screen.height/2f, size, size), "COMMING SOON...")) {
			
		}

		GUI.skin =skin5;
		if (GUI.Button (new Rect (Screen.width/2+size+5,Screen.height/2f, size, size), "COMMING SOON...")) {
			
		}
	}
}
