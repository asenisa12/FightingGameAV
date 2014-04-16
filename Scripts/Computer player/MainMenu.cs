using UnityEngine;
using System.Collections;
public class MainMenu : MonoBehaviour {
	private Texture texture;
	public Font myFont;
	public GUISkin scin;
	void Start(){
		//myFont.
		Screen.showCursor = true;
	}
	void OnGUI () {
		GUI.skin =scin;
		Info info = (Info)(GameObject.Find("info")).GetComponent("Info");
		GUI.Label(new Rect(10,10, 100, 30), "Hello World!");
		if (GUI.Button (new Rect (Screen.width/2-100,Screen.height/4, 200, 50), "SinglePlayer")) {
			info.SetSinglePlayer(true);
			Application.LoadLevel("mainmenu2");
		}

		if (GUI.Button (new Rect (Screen.width/2-100,Screen.height/2.6f, 200, 50), "MultyPlayer")) {

			info.SetSinglePlayer(false);
			Application.LoadLevel("mainmenu2");
		}

		if (GUI.Button (new Rect (Screen.width/2-100,Screen.height/1.5f, 200, 50), "EXIT GAME")) {
			Application.Quit();
		}
	}
	
}
