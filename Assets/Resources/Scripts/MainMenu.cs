using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	private GameObject _documentClassObj;


	// Use this for initialization
	void Start () {
		if (!Config.createdDocClass) {
			_documentClassObj = new GameObject("DocumentClassObj");
			_documentClassObj.AddComponent("DocumentClass");
			Config.createdDocClass = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
