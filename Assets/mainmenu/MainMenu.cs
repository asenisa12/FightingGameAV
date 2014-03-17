using UnityEngine;
using System.Collections;
public class MainMenu : MonoBehaviour {
	void Start(){
		Screen.showCursor = true;
	}
	void OnGUI () {
		if (GUI.Button (new Rect (Screen.width/2-100,Screen.height/4, 200, 50), "START")) {
			Application.LoadLevel("TestScene");
		}
		if (GUI.Button (new Rect (Screen.width/2-100,Screen.height/1.5f, 200, 50), "EXIT")) {
			Application.Quit();
		}
	}
	
}