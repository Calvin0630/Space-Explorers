using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    float ShotDelay;
    float SpeedOfBullet;
    public GameObject EnemyProjectile;
    Vector3 PlayerPos;
	// Use this for initialization
	void Start () {
        ShotDelay = .5f;
        SpeedOfBullet = 15;
        PlayerPos = PlayerShip.PlayerPos;
    }
	
	// Update is called once per frame
	void Update () {
        PlayerPos = PlayerShip.PlayerPos;
        
	}
    void FixedUpdate() {
        //Debug.Log(Time.time);
        if (Time.time % ShotDelay == 0) {
            GameObject clone = (GameObject)Instantiate(EnemyProjectile, transform.position, Quaternion.identity);
            //sets velocity to shoot at the player plus a random vector
            clone.GetComponent<Rigidbody>().velocity = SpeedOfBullet * (GetUnitVector(PlayerPos-transform.position)) +
                new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
        }
    }
    Vector3 GetUnitVector(Vector3 v) {
        float r = Mathf.Sqrt(v.x * v.x + v.y * v.y);
        return v / r;
    }
}
