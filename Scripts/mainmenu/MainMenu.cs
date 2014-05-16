using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	private Texture texture;
	public GUISkin scin;

	void Start(){
		Screen.showCursor = true;
	}
	void OnGUI () {
		GUI.skin =scin;
		Info info = (Info)(GameObject.Find("info")).GetComponent("Info");

		if (GUI.Button (new Rect (Screen.width/2-100,Screen.height/4.5f, 250, 80), "SinglePlayer")) {
			info.SetSinglePlayer(true);
			Application.LoadLevel("mainmenu2");
		}

		if (GUI.Button (new Rect (Screen.width/2-100,Screen.height/2.4f, 250, 80), "MultyPlayer")) {

			info.SetSinglePlayer(false);
			Application.LoadLevel("mainmenu2");
		}

		if (GUI.Button (new Rect (Screen.width/2-100,Screen.height/1.2f, 250, 80), "EXIT GAME")) {
			Application.Quit();
		}
	}
	
}