using UnityEngine;
using System.Collections;

public class BossAI : MonoBehaviour {

	public float pathwidth;
	public float pathheight;
	public float inc;
	bool right;
	public float XPos,YPos;
	Vector3 initialpostion;
	public float BossHP;
	public float BossMHP;
	public float[] BossHPList;
	//public float SpeedOfBullet;
	//public GameObject EnemyProjectile;
	public int formNumber;
	public UIOverlay overlay;


	// Use this for initialization
	void Start () {
		right = true;
		initialpostion = transform.position;
		XPos = 0;
		BossHP = BossMHP = BossHPList[0];
		overlay.BossMode = true;
	}

	void Death() {
		if (BossHP <= 0) {
			print("Boss form defeated");
			formNumber++;
			if (formNumber > BossHPList.Length) {
				Destroy(this.gameObject);
				overlay.BossMode=false;
			}
			else {
				BossHP = BossMHP = BossHPList[formNumber];
			}
		}
	}

	// Update is called once per frame
	void Update () {
		Death ();
		Movement();
		switch (formNumber) {
		case 0:
			firstForm();
			break;
		case 1:
			secondForm();
			break;
		default:
			break;
		}
	}




	void Movement()
	{
		YPos = Mathf.Sin (XPos);
		if (right) {
			transform.position = initialpostion + new Vector3 (pathwidth * XPos, pathheight * YPos, 0);
		}
		else {
			transform.position = initialpostion + new Vector3 (pathwidth * XPos, -pathheight * YPos, 0);
		}
		XPos += inc;
		if (Mathf.Abs (XPos) > 2 * Mathf.PI) {
			inc = -inc;
			right = !right;
		}
	}

	void firstForm() {
		int rand = (int)(Random.value * 10);
		switch (rand) {
		case 0:
			CrossBlast();
			break;
		default:
			break;
		}
	}


	void secondForm() {
		Cannon ();
	}

	void Cannon() {
		GameObject clone = (GameObject)Instantiate(EnemyProjectile, transform.position, Quaternion.identity);
		clone.GetComponent<Rigidbody2D>().velocity = SpeedOfBullet * Vector3.down;
	}

	void CrossBlast() {
		//Shooting
		for (int x=-1; x < 2; x+=2) {
			for (int y=-1; y < 2; y+=2) {
				GameObject clone = (GameObject)Instantiate(EnemyProjectile, transform.position, Quaternion.identity);
				clone.GetComponent<Rigidbody2D>().velocity = SpeedOfBullet * new Vector3(x,y,0);

			}
		}

	}
}
