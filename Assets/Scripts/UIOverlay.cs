using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIOverlay : MonoBehaviour {

	public Vector2 pos = new Vector2(10,25);
	public Vector2 size = new Vector2(500,20);
	public Image BarE;
	public Image BarF;
	public bool Survival;
	public bool BossMode;
	public BossAI boss;
    GameObject Player;


	float BossRHP;
	float timer = 0.0f;
    void Start() {
        Player = GameObject.FindWithTag("Friendly");
        Debug.Log(Player.GetComponent<Transform>().position);
        
    }


	void OnGUI () {
		/*if (Survival == true) {
			timer += Time.deltaTime;
			int Second = (int)Mathf.Floor (timer % 60);
			int Minute = (int)Mathf.Floor (timer / 60);
			//string Sec = Second.ToString ();
			//string Min = Minute.ToString ();
			string Tine = string.Format ("{0:00}:{1:00}", Minute, Second);
			GUI.Box (new Rect (10, 10, 100, 50), Tine);
		}*/
		if (BossMode == true) {
			BossRHP = boss.BossHP / boss.BossMHP;
			
			//draw the filled-in part:
			BarF.rectTransform.anchorMax=new Vector2(BossRHP,1.0f);
			
//			GUI.EndGroup ();
		}

        
	}

    void Update() {
        GameObject.Find("HealthText").GetComponent<Text>().text = "Health: " + Player.GetComponent<PlayerShip>().Health;
        GameObject.Find("MaxScoreText").GetComponent<Text>().text = "Score: " + Player.GetComponent<PlayerShip>().PeakScore;
    }

    
	void Awake() {
		Application.targetFrameRate = 300;
	}
}