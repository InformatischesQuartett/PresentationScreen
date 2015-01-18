using UnityEngine;
using System.Collections;
using System.IO;

public class BehindTheScenes : MonoBehaviour {

	private Texture2D[] _imageFiles;

	private float _updateStep;
	private float _updateTimer;

	private DocumentClass docClass;

	private const string path = @"C:\Users\Fabian\Dropbox\HS Furtwangen\Master\1. Semester\Interaktionsdesign\BlinkenTiles\Assets\StreamingAssets\Network";
	
	private void Start () {
		_imageFiles = new Texture2D[4];

		_updateStep = 0;
		_updateTimer = 0;

		LoadImages();

		docClass =  (DocumentClass)GameObject.Find("DocumentClassObj").GetComponent("DocumentClass");
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
		var sizeFactor = Screen.width/1920f;

		if (_updateTimer > 0)
			GUI.DrawTexture(new Rect(288 * sizeFactor, 100 * sizeFactor, 384 * sizeFactor, 318 * sizeFactor), _imageFiles[0]);

		if (_updateTimer > 4)
			GUI.DrawTexture(new Rect(1248 * sizeFactor, 100 * sizeFactor, 384 * sizeFactor, 318 * sizeFactor), _imageFiles[1]);

		if (_updateTimer > 8)
			GUI.DrawTexture(new Rect(1248 * sizeFactor, 600 * sizeFactor, 384 * sizeFactor, 318 * sizeFactor), _imageFiles[2]);

		if (_updateTimer > 12)
			GUI.DrawTexture(new Rect(288 * sizeFactor, 600 * sizeFactor, 384 * sizeFactor, 318 * sizeFactor), _imageFiles[3]);

		if (_updateTimer > 17)
		{
			_updateTimer = 0;
			_updateStep++;

			if (_updateStep == 3)
			{
				/*Go to next Scene*/
				docClass.LoadNextScene();

				return;
			}

			LoadImages();
		}

		_updateTimer += Time.deltaTime;
	}
}
