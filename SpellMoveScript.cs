using UnityEngine;
using System.Collections;

public class SpellMoveScript : MonoBehaviour {
	bool active = false;
	Vector3 tmp;
	public float speed;
	public float MaxSize;
	Color col,OrCol;
	UI UI;
	// Use this for initialization
	void Start () {
		UI = GameObject.Find ("Canvas").GetComponent<UI> ();
		OrCol = gameObject.GetComponent<SpriteRenderer> ().color;
		col = Color.clear;
		gameObject.GetComponent<SpriteRenderer> ().color = col;
	}

	// Update is called once per frame
	void Update () {
		if (active && !UI.pause) {
			tmp.Set(gameObject.transform.localScale.x+speed*Time.deltaTime,gameObject.transform.localScale.y+speed*Time.deltaTime,1);
			gameObject.transform.localScale = tmp;
			if (gameObject.transform.localScale.x >= MaxSize) {
				active = false;
				gameObject.transform.localScale = new Vector3 (0.5f, 0.5f, 1);
				gameObject.GetComponent<SpriteRenderer> ().color = col;
			}
		}
	
	}
	public void UseSpell(){
		active = true;
		gameObject.GetComponent<SpriteRenderer> ().color = OrCol;
	}
}
