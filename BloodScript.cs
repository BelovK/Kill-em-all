using UnityEngine;
using System.Collections;

public class BloodScript : MonoBehaviour {
	public GameObject BloodEffect;
	public Sprite[] SBloods;
	public SpriteRenderer BloodColor;
	public Color _color;
	public float speed = 1f;
	// Use this for initialization
	void Start () {
		BloodColor.sprite = SBloods [Random.Range (0, SBloods.Length)];
		Destroy (gameObject, speed * 20);
		var bl = Instantiate (BloodEffect, transform.position, Quaternion.identity);
		Destroy (bl, 3);
	}
	
	// Update is called once per frame
	void Update () {
		_color = BloodColor.color;
		_color.a -= speed * Time.deltaTime;
		BloodColor.color = _color;
	}
}
