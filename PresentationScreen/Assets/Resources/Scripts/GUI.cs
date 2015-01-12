using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * Class that handles the GUI of the BlinkenTiles Presentation Screen.
 * 
 * Class Interaction Design 2014/2015, Hochschule Furtwangen University
 * Author: Sarah Haefele
 **/

public class GUI : MonoBehaviour {
	//creating custom GUI style
	GUIStyle myGUIStyle = new GUIStyle();
	private Graphic backgroundImage;


	void Start () {
		//enabeling richtext
		myGUIStyle.richText = true;

		//set backgroundImage by loading the prefab
		backgroundImage = (Graphic)Resources.Load("Prefabs/BackgroundImage", typeof(Graphic));
		if (backgroundImage == null) {
			Debug.Log ("Couldn't find backgroundImage");
		} else {
			Debug.Log("Found Image.");
		}
		//Instantiate background Image
		//Instantiate (backgroundImage, new Vector3(x,y,0), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
