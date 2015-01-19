using UnityEngine;
using System.Collections;
using System.Xml;

public static class Config {

	private static string filePath { get; set; }
	private static TextAsset textAsset { get; set; }
	private static XmlDocument xmldoc { get; set; }

	public static bool ChallengeMode { get; private set; }
	public static float DemoTime { get; private set; }
	public static string SongTitle { get; private set; }
    public static string SongLength { get; private set; }

	public static bool createdDocClass { get; set; }


	/// <summary>
	/// Initializes the Config Class by parsing all Values in the network.xml file referenced by the filePathProperty.
	/// </summary>
	static Config () {
		// will probably eventuaally get it's Value from somewehre else (perhaps the Configset class/ settings.json)
		Config.filePath = "network";
		LoadData ();

		createdDocClass = false;


        PrintValues();
	}//end constructor

	public static void LoadData() {
		xmldoc = new XmlDocument ();
		textAsset = (TextAsset)Resources.Load (filePath);
		xmldoc.LoadXml ( textAsset.text );
		
		//gets firs 
		XmlNodeList networkSet = xmldoc.GetElementsByTagName ("NetworkSet");
		
		bool tmpBool;
		float tmpFloat;
	    float tmpLength;
		foreach (XmlNode element in networkSet[0].ChildNodes) {
			
			switch (element.Name) {
				case "ChallengeMode":
						bool.TryParse (element.InnerText, out tmpBool);
						Config.ChallengeMode = tmpBool;
						break;
		
				case "DemoTime":
						float.TryParse (element.InnerText, out tmpFloat);
						Config.DemoTime = tmpFloat;
						break;
		
				case "Song":
						var childNodes = element.ChildNodes;
						Config.SongTitle = childNodes [0].InnerText;
						break;
                case "Length":
                        var achildNodes = element.ChildNodes;
                        Config.SongLength = achildNodes[0].InnerText;
						break;
		
				default:
						Debug.Log ("Warning: Ran into default Case in Config::Config()");
						break;
			}//end switch
		}//end foreach
	}


	
	public static void PrintValues(){
		Debug.Log ("ChallengeMode: " + Config.ChallengeMode);
		Debug.Log ("DemoTime: " + Config.DemoTime);
		Debug.Log ("SongTitle: " + Config.SongTitle);
        Debug.Log("SongLength: " + Config.SongLength);
	}


} //end class

