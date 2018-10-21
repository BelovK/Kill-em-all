using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingScript : MonoBehaviour {
	public Slider MV, AV, SF;
	public CanvasScaler CS;
	public InputField IFCode;
	UI UI;
	public AudioSource AS;
	public AudioSource[] ASEffects;
	public Toggle T;

	// Use this for initialization
	public void Start () {
		UI = GameObject.Find ("Canvas").GetComponent<UI> ();
		MV.value = PlayerPrefs.GetFloat ("Mvolume");
		AV.value = PlayerPrefs.GetFloat ("Evolume");
		SF.value = PlayerPrefs.GetFloat ("Scale");
		if (PlayerPrefs.GetInt ("Mute") == 0)
			T.isOn = false;
		else
			T.isOn = true;
		Update ();
	}
	
	// Update is called once per frame
	void Update () {
		CS.matchWidthOrHeight = SF.value;
		AS.volume =MV.value;
		AS.mute = T.isOn;
		foreach (AudioSource a in ASEffects) {
			a.volume = AV.value;
			a.mute = T.isOn;
		}
	}
	public void Code(){
		switch (IFCode.text) {
		case "Deletegold":
			{
				PlayerPrefs.SetInt ("gold", 0);
				UI.Objects.Player.gold = 0;
				UI.GoldUpdate (UI.Objects.Player.gold.ToString());
				break;
			}
		case "DeleteKills":
			{
				PlayerPrefs.SetInt ("MaxKills", 0);
				break;
			}
		case "Deletekills":
			{
				PlayerPrefs.SetInt ("MaxKills", 0);
				break;
			}
		case "gmm":
			{
				UI.Objects.Player.gold += 10;
				UI.GoldUpdate (UI.Objects.Player.gold.ToString());
				PlayerPrefs.SetInt ("gold",UI.Objects.Player.gold);
				break;
			}
		case "gmm100":
			{
				UI.Objects.Player.gold += 100;
				UI.GoldUpdate (UI.Objects.Player.gold.ToString());
				PlayerPrefs.SetInt ("gold",UI.Objects.Player.gold);
				break;
			}
		}

	}
	public void SaveSettings(){
		PlayerPrefs.SetFloat ("Mvolume", AS.volume);
		PlayerPrefs.SetFloat ("Evolume", MV.value);
		PlayerPrefs.SetFloat ("Scale", SF.value);
		PlayerPrefs.SetInt ("Mute",T.isOn ? 1 : 0);
		PlayerPrefs.Save ();
	}
}
