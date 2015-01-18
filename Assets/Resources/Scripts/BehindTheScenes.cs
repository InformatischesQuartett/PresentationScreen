using UnityEngine;
using System.Collections;
using System.IO;

public class BehindTheScenes : MonoBehaviour {

	private Texture2D[] _imageFiles;

	private float _updateStep;
	private float _updateTimer;

	private DocumentClass _docClass;
    private MovieTexture _movieTexture;

    private const string path = @"E:\Dropbox\HS Furtwangen\Master\1. Semester\Interaktionsdesign\BlinkenTiles\Assets\StreamingAssets\Network";
	
	private void Start () {
		_imageFiles = new Texture2D[4];

		_updateStep = 0;
		_updateTimer = 0;

        _movieTexture = Resources.Load<MovieTexture>("Textures/BehindTheScenes");
        _movieTexture.Play();

		LoadImages();

		_docClass = (DocumentClass)GameObject.Find("DocumentClassObj").GetComponent("DocumentClass");
	}

	private void LoadImages()
	{	
		for (var x = 0; x < _imageFiles.Length; x++) {
			var bytes = File.ReadAllBytes(path + @"\imgfile" + (x+1) + ".jpg");
	
			if (_imageFiles[x] == null)
				_imageFiles[x] = new Texture2D(512, 424);

			_imageFiles[x].LoadImage(bytes);
		}
	}

	private void OnGUI() {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), _movieTexture);

		var sizeFactor = Screen.width/1920f;

	    var imgWidth = 413*sizeFactor;
        var imgHeight = imgWidth * 0.8f;

	    var imgLeft = 510*sizeFactor;
	    var imgTop = 288*sizeFactor;
	    var imgRight = 993*sizeFactor;
	    var imgBottom = 681*sizeFactor;

	    if (_updateTimer > 8)
	    {
	        GUI.color = new Color(1, 1, 1, Mathf.Min(1.0f, (_updateTimer-8)/2.0f));
            GUI.DrawTexture(new Rect(imgLeft, imgTop, imgWidth, imgHeight), _imageFiles[0]);
	    }

	    if (_updateTimer > 20)
	    {
            GUI.color = new Color(1, 1, 1, Mathf.Min(1.0f, (_updateTimer - 20) / 2.0f));
            GUI.DrawTexture(new Rect(imgRight, imgTop, imgWidth, imgHeight), _imageFiles[1]);
	    }

        if (_updateTimer > 32)
        {
            GUI.color = new Color(1, 1, 1, Mathf.Min(1.0f, (_updateTimer - 32) / 2.0f));
            GUI.DrawTexture(new Rect(imgLeft, imgBottom, imgWidth, imgHeight), _imageFiles[2]);
        }

        if (_updateTimer > 44)
        {
            GUI.color = new Color(1, 1, 1, Mathf.Min(1.0f, (_updateTimer - 32) / 2.0f));
            GUI.DrawTexture(new Rect(imgRight, imgBottom, imgWidth, imgHeight), _imageFiles[3]);
        }

        if (_updateTimer > 56)
			_docClass.LoadNextScene();

		_updateTimer += Time.deltaTime;
	}
}
