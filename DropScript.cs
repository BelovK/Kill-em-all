using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DropScript : MonoBehaviour {
	public float DelayBeforTimerStart=1,DisSpeed=1;
	float DBTS;
	Image image;
	Color color;
	PlayerScript PS;
	UI UI;
	Rigidbody2D RB;
	Transform goldColector;
	// Use this for initialization
	void Start () {
		goldColector = GameObject.Find ("Golds").GetComponentInParent<Transform> ();
		RB = gameObject.GetComponent<Rigidbody2D> ();
		image = gameObject.GetComponent<Image> ();
		color = Color.white;
		UI = GameObject.Find ("Canvas").GetComponent<UI> ();
		PS = GameObject.Find ("playerPix").GetComponent<PlayerScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if ((gameObject.transform.position - goldColector.position).magnitude <= 1f)
			Destr ();
		if (!UI.pause) {
			if (DelayBeforTimerStart > 0) {
				DelayBeforTimerStart -= Time.deltaTime;
			} else {
				color.a -= DisSpeed;
				image.color = color;
				if (color.a <= 0)
					Destroy (gameObject, 0);
			}
		}
	}
	public void Destr(){
		Destroy (gameObject, 0);
	}
	public void SendGold()
	{
		RB.AddForce ((goldColector.position - gameObject.transform.position).normalized*8000);
		PS.GoldUp (1);
	}
}
