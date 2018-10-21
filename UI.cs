using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;
public class UI : MonoBehaviour {
	[System.Serializable]
	public class StartObjects{
		public PlayerScript Player;
		public SpawnerScript[] Spawner;
	}
	public StatsScript Kills,Golds;
	public StartObjects Objects;
	public GameObject DeadPanel,TopPanel,phoneUI,StartPanel,SettingPanel,PausePanel;
	public UltraTextScript UTS;
	public ShopScript Shop;
	public Slider power,stamina;
	public Button PowerButton;
	[Space(20)]
	public EnemyScript enemy;
	public bool pause;
	// Use this for initialization
	void Start () {
		KillsUpdate ();
		PowerOff ();
		Shop.gameObject.SetActive (true);
		Shop.Start ();
		Shop.gameObject.SetActive (false);
		SettingPanel.SetActive (true);
		SettingPanel.GetComponent<SettingScript> ().Start ();
		SettingPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void Pause(){
		pause = true;
		PausePanel.SetActive (true);
		Objects.Player.enabled = false;
		for (int i = 0; i < Objects.Spawner.Length; i++) {
			Objects.Spawner[i].enabled= false;
		}
		enemy.SleapAll ();

	}
	public void UnPause(){
		pause = false;
		PausePanel.SetActive (false);
		Objects.Player.enabled = true;
		for (int i = 0; i < Objects.Spawner.Length; i++) {
			Objects.Spawner[i].enabled= true;
		}
		enemy.WakeUpAll ();
	}
	void Stop(){
		Objects.Player.enabled = false;
		for (int i = 0; i < Objects.Spawner.Length; i++) {
			Objects.Spawner[i].enabled= false;
		}
		enemy.DestroyAll ();
		Objects.Player.stamina = 10;
		SetStamina (Objects.Player.stamina);
		Objects.Player.power = 0;
		SetPower (Objects.Player.power);
	}
	void Unpause(){
		Objects.Player.enabled = true;
		Objects.Player.Kills = 0;
//		Objects.Player.KillsUp ();
		for (int i = 0; i < Objects.Spawner.Length; i++) {
			Objects.Spawner[i].enabled= true;
		}
	}
	public void KillsUpdate(){
		Kills.SetText(Objects.Player.Kills.ToString());
	}
	public void ShowStreak(){
		UTS.SetTextAndShow (1,Objects.Player.streak, 0.5f);
	}
	public void EXIT(){
		PlayerPrefs.Save ();
		Application.Quit ();
	}
	public void GameOver(){
		PlayerPrefs.Save ();
		if (!TopPanel.activeInHierarchy) {
			DeadPanel.SetActive (true);
		}
		phoneUI.SetActive (false);
		TopPanel.SetActive (true);
		PowerOff ();
		Stop ();
	}
	public void SetPower(float _power){
		power.value = _power;
	}
	public void SetStamina(float _power){
		stamina.value = _power;
	}
	public void SetMinStamina(float Min){
		stamina.minValue = Min;
	}
	public void PowerOn(){
		PowerButton.interactable = true;
	}
	public void PowerOff(){
		PowerButton.interactable = false;
	}
	public void GoldUpdate(string txt){
		Golds.SetText(txt);
	}
}
