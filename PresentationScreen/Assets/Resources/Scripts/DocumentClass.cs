using UnityEngine;
using System.Collections;

/**
 * This is the global Document Class which is preserved for all scenes.
 * It manages Scene-Control.
 **/ 
public class DocumentClass : MonoBehaviour {

	void Awake () {
		DontDestroyOnLoad(this);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		if (GUI.Button (new Rect(10, 10, 50, 50), "Test")) {
			Debug.Log ("I clicked the button");
			Application.LoadLevel("HowTo");
		}
	}
}
