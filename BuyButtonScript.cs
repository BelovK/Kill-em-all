using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuyButtonScript : MonoBehaviour {
	public int pay;
	public Button[] button;
	PlayerScript player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("playerPix").GetComponent<PlayerScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Press(){
		if (player.gold >= pay) {
			gameObject.SetActive (false);
			player.GoldUpAndSave (-pay);
			PlayerPrefs.SetInt (gameObject.name, 1);
			foreach (Button b in button) {
				b.interactable = true;
				b.onClick.Invoke ();
			}

		}
	}
	public void Open(){
		if (PlayerPrefs.GetInt (gameObject.name) == 1) {
			gameObject.SetActive (false);
			foreach (Button b in button) {
				b.interactable = true;
				b.onClick.Invoke();
			}
		}
	}
}
