using UnityEngine;
using System.Collections;


public class EnemyScript : MonoBehaviour {
	static  public ArrayList  list = new ArrayList();
	Rigidbody2D rb;
	public Sprite[] ZS;
	public Vector2 direction;
	public float speed;
	public GameObject blood;
	public GameObject drop;
	public float ExplStr;
	public int Rand = 10;
	Vector2 FirstForce;
	public AudioClip[] AC;
	public AudioSource AS;
	UI UI;
	bool hz = true;
	// Use this for initialization
	void Start () {
		direction = (GameObject.Find ("playerPix").transform.position - gameObject.transform.position).normalized;
		gameObject.GetComponent<SpriteRenderer> ().sprite = ZS [Random.Range (0, ZS.Length)];
		AS.clip = AC [Random.Range (0, AC.Length)];
		AS.Play ();
		rb = gameObject.GetComponent<Rigidbody2D> ();
		FirstForce = direction * Random.Range (speed * 0.5f, speed * 1.3f);
		rb.AddForce (FirstForce);
		gameObject.GetComponent<Animation> ().PlayQueued ("ZWalk");
		list.Add (gameObject);
		UI = GameObject.Find ("Canvas").GetComponent<UI> ();

	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log (rb.velocity.magnitude);
		if (rb.velocity.magnitude <= 1f && rb.velocity.magnitude > 0 && gameObject.GetComponent<BoxCollider2D> ().enabled) {
			Debug.Log (rb.velocity.magnitude);
			direction = (GameObject.Find ("playerPix").transform.position - gameObject.transform.position).normalized;
			transform.eulerAngles = new Vector3 (0, 0, direction.x < 0 ? Vector2.Angle (direction, Vector2.up) : -Vector2.Angle (direction, Vector2.up));
			rb.AddForce (FirstForce);

		}
	}
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.collider.tag == "Weapon") {
			gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			coll.gameObject.GetComponentInParent<PlayerScript> ().KillsUp ();
			Dead (coll.contacts [0].point);
		}
		if (coll.collider.tag == "Spell") {
			gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			coll.gameObject.GetComponentInParent<PlayerScript> ().KillsUp (hz);
			Dead (coll.contacts [0].point);
		}
		if (coll.collider.tag == "Player") {
			if(!UI.StartPanel.activeInHierarchy)
				UI.GameOver ();
			Destroy (gameObject);
		}
	}
	void Dead(){
		rb.AddForce (-direction * ExplStr);
		Instantiate(blood,gameObject.transform.position,Quaternion.identity);
		Drop ();
		gameObject.GetComponent<Animation> ().Stop ();
		list.Remove (gameObject);
		Destroy (gameObject, 1);
	}
	void Dead(Vector2 point){
		GameObject Player = GameObject.Find ("playerPix");
		rb.AddForce (-direction * ExplStr);
		gameObject.GetComponent<AudioSource> ().Play ();
		Quaternion q = new Quaternion (Player.transform.localRotation.x, Player.transform.localRotation.y, Player.transform.localRotation.z, Player.transform.localRotation.w);
		Instantiate(blood,point,q);
		Drop ();
		gameObject.GetComponent<Animation> ().Stop ();
		list.Remove (gameObject);
		Destroy (gameObject, 1);
	}
	void Drop(){
		if (Random.Range (0, Rand+1) == 0) {
			var dr = (GameObject)Instantiate (drop, gameObject.transform.position, Quaternion.identity);
			dr.gameObject.transform.SetParent ((GameObject.Find ("Canvas").transform));
			dr.gameObject.transform.SetAsLastSibling ();
			dr.gameObject.transform.localScale = new Vector3 (0.7f, 0.7f, 0.7f);
		}
	}
	public void Destr(){
		Destroy (gameObject, 0);
	}
	public void DestroyAll(){
		foreach (GameObject Z in list.ToArray()) {
			Z.GetComponent<EnemyScript> ().Destr ();
			list.Remove (Z);
		}
	}
	public void SleapAll(){
		foreach (GameObject Z in list.ToArray()) {
			Z.GetComponent<EnemyScript> ().rb.velocity = new Vector2 (0, 0);
			Z.GetComponent<Animation> ().Stop ();
		}
	}
	public void WakeUpAll(){
		foreach (GameObject Z in list.ToArray()) {
			Z.GetComponent<EnemyScript> ().rb.AddForce(Z.GetComponent<EnemyScript> ().FirstForce);
			Z.GetComponent<Animation> ().PlayQueued ("ZWalk");;
		}
	}
}
