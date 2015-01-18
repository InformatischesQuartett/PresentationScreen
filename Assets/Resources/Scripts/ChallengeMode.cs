using UnityEngine;
using System.Collections;

public class ChallengeMode : MonoBehaviour {
	private DocumentClass _docClass;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		/*Exit Challenge Mode Scene when finished with song*/
		if (!Config.ChallengeMode) {
			_docClass.LoadNextScene();
		}
	}

}
