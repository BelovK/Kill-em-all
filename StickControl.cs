using UnityEngine;
using System.Collections;

public class StickControl : MonoBehaviour {
	PlayerScript ps;
	RectTransform RT;
	Vector2 Pos;
	// Use this for initialization
	void Start () {
		ps = GameObject.Find ("playerPix").GetComponent<PlayerScript> ();
		RT = gameObject.GetComponent<RectTransform> ();
	}

	// Update is called once per frame
	void Update () {
		
		if (Pos != RT.anchoredPosition) {
			if (Input.GetMouseButton (0) && RT.anchoredPosition.x != 0) {
				ps.transform.eulerAngles = new Vector3 (0, 0, RT.anchoredPosition.x < 0 ? Vector2.Angle (RT.anchoredPosition, Vector2.up) : -Vector2.Angle (RT.anchoredPosition, Vector2.up));
				ps.AngStamina ();
			}
		}
			Pos = RT.anchoredPosition;
	}
}
