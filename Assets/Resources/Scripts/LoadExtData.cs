using UnityEngine;
using System.Collections;
using System.Xml;

public class LoadExtData : MonoBehaviour {
	private string filePath;
	private TextAsset textAsset;
	private XmlDocument xmldoc;


	// Use this for initialization
	void Start () {
		PrintValues ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PrintValues(){
		Debug.Log ("ChallengeMode: " + Config.ChallengeMode);
		Debug.Log ("DemoTime: " + Config.DemoTime);
		Debug.Log ("SongTitle: " + Config.SongTitle);
	}

}
