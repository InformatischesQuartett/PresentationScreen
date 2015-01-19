using UnityEngine;
using System.Collections;

public class TimeLapse : MonoBehaviour {
    private DocumentClass _docClass;
    private MovieTexture _movieTexture;

    private float _updateTimer;

    private void Start()
    {
        _docClass = (DocumentClass)GameObject.Find("DocumentClassObj").GetComponent("DocumentClass");

        _movieTexture = Resources.Load<MovieTexture>("Textures/Timelapse");
        _movieTexture.Play();
    }

    private void Update()
    {
        _updateTimer += Time.deltaTime;

        if (_updateTimer > 7)
            _docClass.LoadNextScene();
    }

    private void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), _movieTexture);
    }
}
