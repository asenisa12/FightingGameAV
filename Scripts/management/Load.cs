using UnityEngine;
using System.Collections;

public class Load : MonoBehaviour {
	public GUISkin skin;
	void Start () {
		Info info = (Info)(GameObject.Find("info")).GetComponent("Info");
		Application.LoadLevel(info.GetNameMap());
	}
	void OnGUI(){
		GUI.skin = skin;
		GUI.Label (new Rect (Screen.width/ 2 - 200, Screen.height / 2 - 135, 200, 40),"Loading...");
	}
}
