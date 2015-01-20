using UnityEngine;
using System.Collections;

/**
 * This is the global Document Class which is preserved for all scenes.
 * It handles the Scene Loading.
 * Scenes can be loaded by clicking their respective Keyboard-Keys (enable GUI by pressing Tab to see the keys)
 * or by entering the Scene Loop.
 **/ 
public class DocumentClass : MonoBehaviour {
	private Texture2D _backgroundTex;
	private Texture2D _guiUnderlayTex;
	private Texture2D _challengeModeTex;

	private Texture2D _logoTex;

	private bool _enableGUI = true;
	public bool EnableSceneLoop = false;

	/*Determines which Scene is currently loaded*/
	private int _currSceneCounter = 0;

	private string[] _scenes;

	private GUIStyle _fontStyle;
	private GUIStyle _cmStyle;
	
	void Awake () {
		DontDestroyOnLoad(this);
	}
	// Use this for initialization
	void Start () {
		_backgroundTex = (Texture2D) Resources.Load ("Textures/background", typeof(Texture2D));
		_guiUnderlayTex = (Texture2D) Resources.Load ("Textures/guiUnderlay", typeof(Texture2D));
		_logoTex = (Texture2D) Resources.Load ("Textures/logo", typeof(Texture2D));
		_challengeModeTex = (Texture2D) Resources.Load ("Textures/challengeMode", typeof(Texture2D));

		_scenes = new string[]  {"HowTo", "BehindTheScenes", "TimeLapse"};

		_fontStyle = new GUIStyle();
		_fontStyle.font = (Font) Resources.Load("Fonts/BNKGOTHM");
		_fontStyle.normal.textColor = Color.white;
		_fontStyle.fontSize = 15;

	}

    private float StartTimer;
    private bool first = true;
	// Update is called once per frame
	void Update () {

	    if (first == true)
	    {
	        StartTimer = Time.time;
	        first = false;
	    }

	    Config.TimeRemaining = Config.SongLength-Time.time;
		Config.LoadData ();

		/*Turning GUI on and off*/
		if (Input.GetKeyDown (KeyCode.Tab)) {
			_enableGUI = !_enableGUI;
		}

		/*Switching Levels*/
		if (Input.GetKeyDown (KeyCode.Keypad1) || Input.GetKeyDown (KeyCode.Alpha1)) {
			Debug.Log("Loading Level: MainMenu");
			Application.LoadLevel("MainMenu");
		}
		if (Input.GetKeyDown (KeyCode.Keypad2) || Input.GetKeyDown (KeyCode.Alpha2)) {
			Debug.Log("Loading Level: HowTo");
			Application.LoadLevel("HowTo");
		}
		if (Input.GetKeyDown (KeyCode.Keypad3) || Input.GetKeyDown (KeyCode.Alpha3)) {
			Debug.Log("Loading Level: Behind the Scenes");
			Application.LoadLevel("BehindTheScenes");
		}
		if (Input.GetKeyDown (KeyCode.Keypad4) || Input.GetKeyDown (KeyCode.Alpha4)) {
			Debug.Log("Loading Level: Time Lapse");
			Application.LoadLevel("TimeLapse");
		}
		if (Input.GetKeyDown (KeyCode.Keypad5) || Input.GetKeyDown (KeyCode.Alpha5)) {
			EnableSceneLoop = !EnableSceneLoop;
			Debug.Log("Loop Scenes: " + EnableSceneLoop);

			/*Start the loop*/
			if (EnableSceneLoop) {
				LoadNextScene();
			}
		}

		/*Loading ChallengeMode Scene while in Challenge Mode*/
		if (Config.ChallengeMode && Application.loadedLevelName != "ChallengeMode") {
			Debug.Log ("Loading Challenge Mode Scene");
			Application.LoadLevel ("ChallengeMode");
		}

			
	}

	void OnGUI () {
		//font: Bank Gothic Medium BT
		//Draw Background Texture
        GUI.depth = 2;
		if (Application.loadedLevelName == "MainMenu" || Application.loadedLevelName == "ChallengeMode") {
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), _backgroundTex);
			GUI.DrawTexture (new Rect (Screen.width - 122, Screen.height - 51, 122, 51), _logoTex);
		}

		if (_enableGUI) {

			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height/5), _guiUnderlayTex);
			GUI.Label (new Rect (10,10, 80, 50), "MAIN MENU: 1, \t\tHOW TO: 2, \tBEHIND THE SCENES: 3, \tTIME LAPSE: 4; \tLOOP MODE: 5", _fontStyle);
		}

	    
		if (Application.loadedLevelName == "ChallengeMode") {
			GUI.DrawTexture (new Rect (Screen.width/2 - (_challengeModeTex.width/2),Screen.height/2 - (_challengeModeTex.height/2), _challengeModeTex.width, _challengeModeTex.height), _challengeModeTex);
			GUI.Label (new Rect (Screen.width/2 - (_challengeModeTex.width/2), Screen.height/1.5f, 80, 50), "CURRENT SONG: " + Config.SongTitle + ", \tTIME REMAINING: " + Config.TimeRemaining, _fontStyle);

		}

	}//end OnGUI

	/*Loads next Scene in List*/
	public void LoadNextScene () {
		_currSceneCounter++;
		/*Reset Counter to loop everything*/
		if (_currSceneCounter >= _scenes.Length)
						_currSceneCounter = 0;
		Application.LoadLevel(_scenes[_currSceneCounter]);
		Debug.Log ("Loaded next Scene");
	}
}
