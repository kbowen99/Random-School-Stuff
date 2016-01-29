using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIUpdate : MonoBehaviour {
	//Basic Declarations
	Text UpdateTxt;
	string UpdateText = "KMT Matter Simulator \n Press 1, 2, or 3 to select Matter Type! \n KMT \n KMT states that all matter is made up of small particles that remain in constant motion. As matter temperature increases, the particle speed increases";

	// Use this for initialization
	void Start () {
		//instatiate
		UpdateTxt = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		//update the screen with current UpdateText Variable 
		UpdateTxt.text = UpdateText;
	}

	public void NewText(string NewText) {
		//allows updating of the screen from another script
		UpdateText = NewText;
	}
}
