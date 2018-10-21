using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public Animation WeaponAnim;
	public GameObject[] Weapon;
	public GameObject[] WeaponCollection;
	public int Kills = 0;
	public float power = 0;
	public float stamina = 10f;
	float WeaponStam;
	public float deltaPower,deltaStamina;
	public int streak = 0;
	public int gold= 0;
	UI UI;
	public SpellMoveScript Spell;
	private IEnumerator coroutine;
	public 
	// Use this for initialization
	void Start () {
		UI = GameObject.Find ("Canvas").GetComponent<UI> ();
		WeaponStam = Weapon [0].GetComponent<WeaponScript>().stamina;
		UI.SetMinStamina (WeaponStam);
		gold = PlayerPrefs.GetInt ("gold");
		UI.GoldUpdate (gold.ToString ());
	}
	
	// Update is called once per frame
	void Update () {
		if (!(power <= 0)) {
			power -= deltaPower * Time.deltaTime;
			if (power < 9 && UI.PowerButton.interactable)
				UI.PowerOff ();
			UI.SetPower (power);
		}
		if (!(stamina >= 10)) {
			stamina += deltaStamina * Time.deltaTime;
			UI.SetStamina (stamina);
		}
		if (!WeaponAnim.isPlaying) {
			foreach(GameObject S in Weapon)
				if(S.GetComponent<BoxCollider2D> ()!= null)
					S.GetComponent<BoxCollider2D> ().enabled = false;
		}
			if (Input.GetButtonDown ("Fire1")) {
			Hit ();
			}
			if (Input.GetButtonDown ("Horizontal") && Input.GetAxisRaw ("Horizontal") > 0) {//право
			Right();
			}
			if (Input.GetButtonDown ("Horizontal") && Input.GetAxisRaw ("Horizontal") < 0) {//лево
			Left();
			}
			if (Input.GetButtonDown ("Vertical") && Input.GetAxisRaw ("Vertical") < 0) {//лево
			Down();
			}
			if (Input.GetButtonDown ("Vertical") && Input.GetAxisRaw ("Vertical") > 0) {//лево
			Up();
			}
		}
	private IEnumerator TimeForStreak(float waitTime)
	{
			yield return new WaitForSeconds(waitTime);
		if (streak > 1) {
			PowerUp ();
//			Debug.Log ("Streak: " + streak.ToString ());
			UI.ShowStreak ();
		}
			streak = 0;
			
	}
	public void KillsUp(){
		Kills++;
		streak++;
		if (streak == 1) {
			coroutine = TimeForStreak (0.8f);
			StartCoroutine (coroutine);
		}
		UI.KillsUpdate();
	}
	public void KillsUp(bool IsSpell){
		Kills++;
		UI.KillsUpdate();
	}
	void Up(){
		transform.eulerAngles = new Vector3 (0, 0, 0);
	}
	void Down(){
		transform.eulerAngles = new Vector3 (0, 0, 180);
	}
	void Left(){
		transform.eulerAngles = new Vector3 (0, 0, 90);
	}
	void Right(){
		transform.eulerAngles = new Vector3 (0, 0, -90);
	}
	public void SetAng(float value){
		stamina -= WeaponStam*0.1f;
		UI.SetStamina (stamina);
		transform.eulerAngles = new Vector3 (0, 0, value*-360);
	}
	public void AngStamina(){
		if (Weapon[0].GetComponent<BoxCollider2D> ().enabled) {
			stamina -= WeaponStam * 0.03f;
			UI.SetStamina (stamina);
		}
	}
	void Hit(){
		if (stamina >= WeaponStam && !WeaponAnim.isPlaying) {
			stamina -= WeaponStam;
			UI.SetStamina (stamina);
			foreach (GameObject S in Weapon) {
				if (S.GetComponent<BoxCollider2D> () != null)
					S.GetComponent<BoxCollider2D> ().enabled = true;
			}
			if (WeaponAnim.name == "Axe")
				WeaponAnim.Play ("Weapon");
			if (WeaponAnim.name == "BIGAXE")
				WeaponAnim.Play ("WeaponBIGAXE");
			if (WeaponAnim.name == "BigSword")
				WeaponAnim.Play ("BigSword");
			if (WeaponAnim.name == "Kop")
				WeaponAnim.Play ("WeaponKop");
			if (WeaponAnim.name == "Sword")
				WeaponAnim.Play ("WeaponSword");
			if (WeaponAnim.name == "Knifes")
				WeaponAnim.Play ("WeaponKnifes");
		}
	}
	public void SwapWeapon(GameObject _weapon){
		foreach(GameObject S in Weapon)
			S.gameObject.SetActive (false);
		_weapon.gameObject.SetActive (true);
		Weapon[0] = _weapon;
		WeaponStam = Weapon [0].GetComponent<WeaponScript>().stamina;
		WeaponAnim = Weapon [0].GetComponent<Animation> ();
		UI.SetMinStamina (WeaponStam);
	}
	public void SwapWeapon(GameObject[] _weapon){
		foreach(GameObject S in Weapon)
			S.gameObject.SetActive (false);
		foreach(GameObject S in _weapon)
			S.gameObject.SetActive (true);
		WeaponAnim = Weapon [0].GetComponent<Animation> ();
		WeaponStam = Weapon [0].GetComponent<WeaponScript>().stamina;
		UI.SetMinStamina (WeaponStam);
	}
	void PowerUp(){
		switch (streak) {
		case 2:
			power += 2;
			break;
		case 3:
			power += 3;
			break;
		case 4:
			power += 6;
			break;
		case 5:
			power += 10;
			break;
		}
		if (power >= 9)
			UI.PowerOn ();
	}
	public void UseSpeel(){
		power = 0;
		UI.PowerOff ();
		UI.SetPower (power);
		Spell.UseSpell ();
	}
	public void GoldUp(int Up){
		if (gold + Up < 0)
			Debug.Log ("Not mach money");
		else {
			gold += Up;
			PlayerPrefs.SetInt ("gold", gold);
			UI.GoldUpdate (gold.ToString ());
		}
	}
	public void GoldUpAndSave(int _gold){
		if (gold + _gold < 0)
			Debug.Log ("Not mach money");
		else {
			gold += _gold;
			PlayerPrefs.SetInt ("gold", gold);
			PlayerPrefs.Save ();
			UI.GoldUpdate (gold.ToString ());
		}
	}
}
