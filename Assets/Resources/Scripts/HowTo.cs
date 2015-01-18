using UnityEngine;
using System.Collections;


public class HowTo : MonoBehaviour {
	
	private DocumentClass _docClass;

	// Use this for initialization
	void Start () {
		_docClass =  (DocumentClass)GameObject.Find("DocumentClassObj").GetComponent("DocumentClass");
	}
	
	// Update is called once per frame
	void Update () {
		//_docClass.LoadNextScene();
	}

	void OnGUI () {
		//GUI.DrawTexture ();
	}
}
