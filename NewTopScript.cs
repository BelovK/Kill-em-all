using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class NewTopScript : MonoBehaviour {
	public InputField Name;
	public TOPScript TS;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void CreateNewScore(){
		TS.CreateNewTop (Name.text);
		TS.NewLoad ();
	}
}
