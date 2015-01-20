using UnityEngine;
using System.Collections;

public class ChallengeMode : MonoBehaviour {
	private DocumentClass _docClass;
    public MovieTexture _movieTexture;
    private float _updateTimer;
    
    // Use this for initialization
	void Start () {
		_docClass =  (DocumentClass)GameObject.Find("DocumentClassObj").GetComponent("DocumentClass");

        _movieTexture = Resources.Load<MovieTexture>("Textures/HowTo2");
        _movieTexture.Play();
	}
	
	// Update is called once per frame
	void Update () {

		/*Exit Challenge Mode Scene when finished with song*/
		if (!Config.ChallengeMode) {
			_docClass.LoadNextScene();
		}
	}

    private void OnGUI()
    {

        if (_updateTimer < 12)
        {
            GUI.depth = 1;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), _movieTexture);
        }
    }

}
