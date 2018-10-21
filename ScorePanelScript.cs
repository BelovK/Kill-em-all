using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScorePanelScript : MonoBehaviour {
	public Text Kills,Name,Date;
	public int IntKills;
	public string StrName;
	public System.DateTime TimeDate;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void SetStrings(string SomeKills,string SomeName,string SomeDate){
		Kills.text = SomeKills;
		Name.text = SomeName;
		Date.text = SomeDate;
	}
	public void SetStrings(){
		Kills.text = IntKills.ToString();
		Name.text = StrName;
		Date.text = TimeDate.ToString();
	}
	public void SetSettings(int Kills_,string Name_,System.DateTime Date){
		IntKills = Kills_;
		StrName = Name_;
		TimeDate = Date;
	}
}
