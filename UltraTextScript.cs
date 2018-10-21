using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UltraTextScript : MonoBehaviour {
	Text TS;
	Color tmp;
	bool show=false,hide=false;
	float speed;
	public string[] StreakText;
	private IEnumerator coroutine;
	// Use this for initialization
	void Start () {
		TS = GetComponent<Text> ();
		tmp = TS.color;
	}
	
	// Update is called once per frame
	void Update () {
		if (hide){
		tmp.a = TS.color.a - speed * Time.deltaTime;
		TS.color = tmp;
			if (TS.color.a <= 0)
				hide = false;
		}
		if (show){
			tmp.a = TS.color.a + speed * Time.deltaTime;
			TS.color = tmp;
			if (TS.color.a >= 255)
				show = false;
		}
	}
	void Show(float _speed){
		show = true;
		hide = false;
		speed = _speed;
	}
	void Hide(float _speed){
		hide = true;
		show = false;
		speed = _speed;
	}
	public void SetTextAndShow(float _speed,string txt,float ShowTime){
		Show (_speed);
		TS.text = txt;
		coroutine = WaitAndHide (ShowTime);
		StartCoroutine (coroutine);
	}
	public void SetTextAndShow(float _speed,int streak,float ShowTime){
		Show (_speed);
		switch(streak){
		case 2:
			TS.text = StreakText [0];
			break;
		case 3:	
			TS.text = StreakText[1];
			break;
		case 4:
			TS.text = StreakText [2];
			break;
		case 5:
			TS.text = StreakText [3];
			break;
		case 6:
			TS.text = StreakText [4];
			break;
		}
		coroutine = WaitAndHide (ShowTime+_speed);
		StartCoroutine (coroutine);
	}
	private IEnumerator WaitAndHide(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		Hide (speed);

	}
}
