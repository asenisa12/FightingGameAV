using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	void OnMouseDown(){
		renderer.material.color = Color.white;
	}

	void OnMouseEnter()
	{
		renderer.material.color = Color.blue; 
	}
	
	void OnMouseExit()
	{
		renderer.material.color = Color.white;
	}
	// Use this for initialization
	void Start () {
		//GUI.scin.color = Color.blue;
		renderer.material.color = Color.blue; 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
