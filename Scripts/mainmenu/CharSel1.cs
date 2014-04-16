using UnityEngine;
using System.Collections;

public class CharSel1 : MonoBehaviour {
	public GUISkin scin;
	void Start () {
		 GUI.Label(new Rect(Screen.width/2-250,Screen.height/4-20,100,20),"Player1");
	}

}
