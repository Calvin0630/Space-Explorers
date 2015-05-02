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
	public bool Boss;
	public float BossHP=500f;
	public float BossMHP=500f;
	float BossRHP;
	float timer = 0.0f;
	void OnGUI () {
		if (Survival == true) {
			timer += Time.deltaTime;
			int Second = (int)Mathf.Floor (timer % 60);
			int Minute = (int)Mathf.Floor (timer / 60);
			//string Sec = Second.ToString ();
			//string Min = Minute.ToString ();
			string Tine = string.Format ("{0:00}:{1:00}", Minute, Second);
			GUI.Box (new Rect (10, 10, 100, 50), Tine);
		}
		if (Boss == true) {
			BossRHP = BossHP / BossMHP;
			
			//draw the filled-in part:
			BarF.rectTransform.anchorMax=new Vector2(BossRHP,1.0f);
			
//			GUI.EndGroup ();
		}
	}
}