using UnityEngine;
using System.Collections;
using System.Xml;

public class LoadExtData : MonoBehaviour {
	private string filePath;
	private TextAsset textAsset;
	private XmlDocument xmldoc;

	// Use this for initialization
	void Start () {

		xmldoc = new XmlDocument ();
		textAsset = (TextAsset)Resources.Load ("MyXMLFile");
		xmldoc.LoadXml ( textAsset.text );

		Debug.Log (xmldoc);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
