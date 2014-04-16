using UnityEngine;
using System.Collections;

public class MainMenu2 : MonoBehaviour {
	public GUISkin skin1;
	public GUISkin skin2;
	public GUISkin skin3;
	public int selGridInt1 = 0;
	public int selGridInt2 = 0;
	private string[] selStrings = new string[] {"Char 1", "Char 2", "Char 3", "Char 4"};

	void Start () {
	
	}
	void OnGUI () {
		GUI.skin = skin1; 

		GUI.Label(new Rect(Screen.width/2-250,Screen.height/4-60,100,20),"Player1");
		GUI.Label(new Rect(Screen.width/2-250,Screen.height/2f-60,100,20),"Player2");

		GUI.skin =skin2;

		selGridInt1 = GUI.SelectionGrid(new Rect(Screen.width/2-250, Screen.height/4, 500, 50), selGridInt1, selStrings, 4);
		selGridInt2 = GUI.SelectionGrid(new Rect(Screen.width/2-250, Screen.height/2f, 500, 50), selGridInt2, selStrings, 4);

		GUI.skin = skin3;

		if (GUI.Button (new Rect (Screen.width/2-100,Screen.height/1.5f, 200, 50), "CHOOSE MAP")) {
			Info info = (Info)(GameObject.Find("info")).GetComponent("Info");
			info.SetNameP1(ChooseName(selGridInt1));
			info.SetNameP2(ChooseName(selGridInt2));
			Application.LoadLevel("Meanu3");
		}
	}

	private string ChooseName(int sel){

		switch (sel){
			case 0:
				return "Tiger";
			case 1:
				return "FighterShaolin";
			case 2:
				return "Tiger";
			case 3:
				return "FighterShaolin";
			default:
				return "";
		}
	}

	void Update () {
		
	}
}
