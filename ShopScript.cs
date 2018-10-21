using UnityEngine;
using System.Collections;

public class ShopScript : MonoBehaviour {
	public BuyButtonScript[] BuyButtons;
	// Use this for initialization
	public void Start () {
		foreach (BuyButtonScript b in BuyButtons)
			b.Open ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Add(){
		
	}
}
