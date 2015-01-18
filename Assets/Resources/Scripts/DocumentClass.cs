using UnityEngine;
using System.Collections;

/**
 * This is the global Document Class which is preserved for all scenes.
 * It manages Scene-Control.
 **/ 
public class DocumentClass : MonoBehaviour {
	private Texture2D _backgroundTex;
	private Texture2D _guiUnderlayTex;

	private bool _enableGUI = true;

	/*Determines which Scene is currently loaded*/
	private int _currSceneCounter = 0;

	private string[] _scenes;
	
	void Awake () {
		DontDestroyOnLoad(this);
	}
	// Use this for initialization
	void Start () {
		_backgroundTex = (Texture2D) Resources.Load ("Textures/background", typeof(Texture2D));
		_guiUnderlayTex = (Texture2D) Resources.Load ("Textures/guiUnderlay", typeof(Texture2D));
		_scenes = new string[]  {"MainMenu", "HowTo", "BehindTheScenes"};
	}
	
	// Update is called once per frame
	void Update () {

		/*Turning GUI on and off*/
		if (Input.GetKeyDown (KeyCode.Tab)) {
			_enableGUI = !_enableGUI;
		}

		/*Switching Levels*/
		if (Input.GetKeyDown (KeyCode.Keypad1) || Input.GetKeyDown (KeyCode.Alpha1)) {
			Debug.Log("Loading Level: HowTo");
			Application.LoadLevel("MainMenu");
		}
		if (Input.GetKeyDown (KeyCode.Keypad2) || Input.GetKeyDown (KeyCode.Alpha2)) {
			Debug.Log("Loading Level: HowTo");
			Application.LoadLevel("HowTo");
		}
		if (Input.GetKeyDown (KeyCode.Keypad3) || Input.GetKeyDown (KeyCode.Alpha2)) {
			Debug.Log("Loading Level: Behind the Scenes");
			//Application.LoadLevel("BehindTheScenes");
		}

	
	}

	void OnGUI () {
		//font: Bank Gothic Medium BT
		//Draw Background Texture
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), _backgroundTex);

		if (_enableGUI) {

			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height/5), _guiUnderlayTex);
			GUI.Label (new Rect (10,10, 80, 50), "Main Menu: 1");
			GUI.Label (new Rect (100,10, 80, 50), "How To: 2");
			GUI.Label (new Rect (190,10, 80, 50), "Behind the Scenes: 3");
		}

	}//end OnGUI

	/*Loads next Scene in List*/
	void loadNextScene () {
		_currSceneCounter++;
		/*Reset Counter to loop everything*/
		if (_currSceneCounter > _scenes.Length)
						_currSceneCounter = 0;
		Application.LoadLevel(_scenes[_currSceneCounter]);
	}
}
