using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {
	public float timer,ResTimer;
	public float stamina = 0.5f;
	bool off;
	UI UI;
	// Use this for initialization
	void Start () {
		UI = GameObject.Find ("Canvas").GetComponent<UI> ();
	}
	
	// Update is called once per frame
	void Update () {
//		if (timer > 0) {
//			timer = timer - Time.deltaTime;
//		} else
//			off = true;
	}
//	public void ReSet(){
//		if (off) {
//			timer = ResTimer;
//			Streak = 0;
//			off = false;
//		}
//	}
//	public void CheckStreak(){
//		if (!off) {
//			
//		}
//	}
}
