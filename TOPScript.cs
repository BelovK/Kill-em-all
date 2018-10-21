using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class TOPScript : MonoBehaviour {
	ScrollRect SV;
	public GameObject panel;
	public ScorePanelScript[] tops;
	public string way;
	UI UI;
	string[] files;
	string[] NewText= new string[1];
	// Use this for initialization
	void Start () {
		UI = GameObject.Find ("Canvas").GetComponent<UI> ();
		SV = gameObject.GetComponent<ScrollRect> ();
		way = Application.persistentDataPath + "/Scores";
		LoadTop ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	//Создание файла
	public void CreateNewTop(string Name){
		way = Application.persistentDataPath + "/Scores";
		if(!Directory.Exists(way))
			Directory.CreateDirectory(way);
		if(!File.Exists(way+System.DateTime.Now.ToString())){
			string[] txt = new string[1];
			txt[0] = UI.Kills.txt.text.ToString () + "%" + Name + "%" + System.DateTime.Now;
			string TxtDate;
			TxtDate = System.DateTime.Now.ToString();
			TxtDate = TxtDate.Replace (' ', '_');
			TxtDate = TxtDate.Replace ('/', '$');
			TxtDate = TxtDate.Replace (':', '@');
			File.WriteAllLines(way+"/"+TxtDate+".ini",txt);
		}
	}
	//Чтение из папки scores и создание таблицы
	public void LoadTop(){
		files = Directory.GetFiles (way);
		tops = new ScorePanelScript[files.Length];
		for (int i = 0; i < files.Length; i++) {
			string txt = File.ReadAllText (files [i]);
			if(tops[i]==null)
				Create (txt, i);
		}
	}
	//Создание новой строки
	public void NewLoad(){
		files = Directory.GetFiles (way);
		tops = new ScorePanelScript[files.Length];
		string txt = File.ReadAllText (files [files.Length-1]);
		if(tops[files.Length-1]==null)
			Create (txt);
	}
	//Функция чтения из файла и создания строк при запуске игры
	void Create(string Txt, int j){
		string Kills="",Name="",Date="";
		int count = 0;
		for (int i = 0; i < Txt.Length; i++) {
			if (Txt [i] == '\r')
				break;
			if (Txt [i] == '%') {
				count++;
				continue;
			}
			if (count == 0) {
				Kills += Txt [i];
			}
			if (count == 1) {
				Name += Txt [i];
			}
			if (count == 2) {
				Date += Txt [i];
			}
		}
		var pan = (GameObject)Instantiate (panel, Vector3.zero,Quaternion.identity);
		DateTime SD;
		System.DateTime.TryParse (Date,out SD);
		pan.GetComponent<ScorePanelScript> ().SetSettings(int.Parse(Kills), Name, SD);
		pan.transform.SetParent (SV.content.transform);
		pan.transform.localScale = new Vector3 (1, 1, 1);
		pan.GetComponent<RectTransform> ().localPosition= new Vector3 (244.5f, -40 * (j + 1), 0);
		pan.GetComponent<RectTransform> ().sizeDelta = new Vector2 (488, 40);
		tops [j] = pan.GetComponent<ScorePanelScript>();
		tops [j].SetStrings ();
	}
	//Функция чтения из файла и создания строк при добавлении нового счёта
	void Create(string Txt){
		string Kills="",Name="",Date="";
		int count = 0;
		for (int i = 0; i < Txt.Length; i++) {
			if (Txt [i] == '\r')
				break;
			if (Txt [i] == '%') {
				count++;
				continue;
			}
			if (count == 0) {
				Kills += Txt [i];
			}
			if (count == 1) {
				Name += Txt [i];
			}
			if (count == 2) {
				Date += Txt [i];
			}
		}
		var pan = (GameObject)Instantiate (panel, Vector3.zero,Quaternion.identity);
		DateTime SD;
		System.DateTime.TryParse (Date,out SD);
		pan.GetComponent<ScorePanelScript> ().SetSettings(int.Parse(Kills), Name, SD);
		pan.transform.SetParent (SV.content.transform);
		pan.transform.localScale = new Vector3 (1, 1, 1);
		pan.GetComponent<RectTransform> ().localPosition= new Vector3 (244.5f, -40 * (tops.Length), 0);
		pan.GetComponent<RectTransform> ().sizeDelta = new Vector2 (488, 40);
		tops = new ScorePanelScript[tops.Length + 1];
		tops [tops.Length - 1] = pan.GetComponent<ScorePanelScript>();
		tops [tops.Length - 1].SetStrings ();
	}
}
