using UnityEngine;
using System.Collections;

public class BossAI : MonoBehaviour {

	public float pathwidth;
	public float pathheight;
	public float inc;
	bool right;
	public float x,y;
	Vector3 initialpostion;
	public float BossHP;
	public float BossMHP;
	
	// Use this for initialization
	void Start () {
		right = true;
		initialpostion = transform.position;
		x = 0;
		BossHP = BossMHP;
	}
	
	// Update is called once per frame
	void Update () {
		y = Mathf.Sin (x);
		if (right) {
			transform.position = initialpostion + new Vector3 (pathwidth * x, pathheight * y ,0);
		}
		else {
			transform.position = initialpostion + new Vector3 (pathwidth * x, -pathheight * y,0);
		}
		x += inc;
		if (Mathf.Abs(x) > 2 * Mathf.PI) {
			inc = -inc;
			right=!right;
		}
	}
}
