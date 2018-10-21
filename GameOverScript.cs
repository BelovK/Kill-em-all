using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameOverScript : MonoBehaviour {
	public Text TMaxScore,New;
	public PlayerScript PS;
	// Use this for initialization
	void OnEnable () {
		if (PS.Kills > PlayerPrefs.GetInt ("MaxKills") || PlayerPrefs.GetInt ("MaxKills") == 0 ) {
			PlayerPrefs.SetInt ("MaxKills", PS.Kills);
			New.gameObject.SetActive (true);
			TMaxScore.text = PlayerPrefs.GetInt ("MaxKills").ToString();
		}
		TMaxScore.text = PlayerPrefs.GetInt ("MaxKills").ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
