using UnityEngine;
using System.Collections;

public class MainMenu2 : MonoBehaviour {
	public GUIStyle style;
	public GUISkin skin2;
	public GUISkin skin3;
	public int selGridInt1 = 0;
	public int selGridInt2 = 0;
	private string[] selStrings = new string[] {"TIGER", "MONK", "GIRL", "Char 4"};

	void Start () {
	
	}
	void OnGUI () {

		GUI.Label(new Rect(Screen.width/2-250,Screen.height/4-60,100,20),"Player1",style);
		GUI.Label(new Rect(Screen.width/2-250,Screen.height/2f-60,100,20),"Player2",style);

		GUI.skin =skin2;

		selGridInt1 = GUI.SelectionGrid(new Rect(Screen.width/2-260, Screen.height/4, 500, 80), selGridInt1, selStrings, 4);
		selGridInt2 = GUI.SelectionGrid(new Rect(Screen.width/2-260, Screen.height/2f, 500, 80), selGridInt2, selStrings, 4);

		GUI.skin = skin3;

		if (GUI.Button (new Rect (Screen.width/2-270,Screen.height/1.5f, 250, 80), "CHOOSE MAP")) {
			Info info = (Info)(GameObject.Find("info")).GetComponent("Info");
			info.SetNameP1(ChooseName(selGridInt1));
			info.SetNameP2(ChooseName(selGridInt2));
			Application.LoadLevel("Meanu3");
		}
		if (GUI.Button (new Rect (Screen.width/2,Screen.height/1.5f, 250, 80), "BACK")) {
			Application.LoadLevel("Menu");
		}
	}

	private string ChooseName(int sel){

		switch (sel){
			case 0:
				return "Tiger";
			case 1:
				return "FighterShaolin";
			case 2:
				return "BootyFighter";
			case 3:
				return "FighterShaolin";
			default:
				return "";
		}
	}

	void Update () {
		
	}
}
