using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float BossDamage;
    public int ScorePerKill;
    float ScreenSize;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Hostile") {
            Destroy(col.gameObject);
            GameObject player = GameObject.FindWithTag("Friendly");
            player.GetComponent<PlayerShip>().Health += ScorePerKill;
            player.GetComponent<PlayerShip>().PeakScore += ScorePerKill;
        }
		if (col.gameObject.tag == "Boss") {
			print("Boss hit!");
			col.gameObject.GetComponents<BossAI> () [0].BossHP -= BossDamage;
		}
        Destroy(gameObject);
    }
}
