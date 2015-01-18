using UnityEngine;
using System.Collections;

/**
 * This is the global Document Class which is preserved for all scenes.
 * It manages Scene-Control.
 **/ 
public class DocumentClass : MonoBehaviour {
	private Texture2D _backgroundTex;

	public int toolbarInt = 0;
	public string[] toolbarStrings = new string[] {"StartMenu", "HowTo", "Toolbar3"};
	
	void Awake () {
		DontDestroyOnLoad(this);
	}
	// Use this for initialization
	void Start () {
		_backgroundTex = (Texture2D) Resources.Load ("Textures/background", typeof(Texture2D));

		Debug.Log (_backgroundTex);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		//Drav Background Texture
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), _backgroundTex);

		toolbarInt = GUILayout.Toolbar(toolbarInt, toolbarStrings);

		switch (toolbarInt) {
			case 0:
				Application.LoadLevel("MainMenu");
				break;
			case 1:
				Application.LoadLevel("HowTo");
				break;
			case 2:
				break;
		}//end switch



	}//end OnGUI
}
