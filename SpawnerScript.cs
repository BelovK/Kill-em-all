using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {
	public GameObject TypeEnemy;
	float timer;
	Vector3 RandomVector;
	public Vector2 direction;
	public SpawnSpeed SpawnSpeeds;
	[System.Serializable]
	public class SpawnSpeed{
		public float MinTime;
		public float MaxTime;
	}
	// Use this for initialization
	void Start () {
		direction = (GameObject.Find ("playerPix").transform.position - gameObject.transform.position).normalized;
		timer = Random.Range(SpawnSpeeds.MinTime,SpawnSpeeds.MaxTime);
	}
	
	// Update is called once per frame
	void Update () {
			if (timer > 0)
				timer -= Time.deltaTime;
			else {
				RandomVector = new Vector3 (Random.Range (-1.2f, 1.2f), 0, 0);
				var enemy = Instantiate (TypeEnemy, gameObject.transform.position + RandomVector, Quaternion.identity) as GameObject;
				enemy.GetComponent<EnemyScript> ().direction = direction;
				enemy.transform.eulerAngles = new Vector3 (0, 0, direction.x < 0 ? Vector2.Angle (direction, Vector2.up) : -Vector2.Angle (direction, Vector2.up));
				timer = Random.Range (SpawnSpeeds.MinTime, SpawnSpeeds.MaxTime);
			}
	}
}
