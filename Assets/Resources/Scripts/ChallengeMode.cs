using UnityEngine;
using System.Collections;

public class ChallengeMode : MonoBehaviour {
	private DocumentClass _docClass;
	private GUIStyle _fontStyle;

	// Use this for initialization
	void Start () {
		_docClass =  (DocumentClass)GameObject.Find("DocumentClassObj").GetComponent("DocumentClass");
		_fontStyle = new GUIStyle();
		_fontStyle.font = (Font) Resources.Load("Fonts/BNKGOTHM");
		_fontStyle.normal.textColor = Color.white;
		_fontStyle.fontSize = 15;
	}
	
	// Update is called once per frame
	void Update () {

		/*Exit Challenge Mode Scene when finished with song*/
		if (!Config.ChallengeMode) {
			_docClass.LoadNextScene();
		}
	}

	void OnGUI () {
		GUI.Label (new Rect (Screen.width/2,Screen.height/2, 300, 300), "CHALLENGE MODE", _fontStyle);
	}
}
