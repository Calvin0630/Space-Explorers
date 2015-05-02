using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public float ShotDelay;
    public float SpeedOfBullet;
    public GameObject EnemyProjectile;
    int Destination;
    public float ShotAccuracy; //higher is less accurate
    Vector3 PlayerPos;
	// Use this for initialization
	void Start () {
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
            clone.GetComponent<Rigidbody2D>().velocity = SpeedOfBullet * (GetUnitVector(PlayerPos-transform.position)) +
                new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0) * ShotAccuracy;
        }
    }
    Vector3 GetUnitVector(Vector3 v) {
        float r = Mathf.Sqrt(v.x * v.x + v.y * v.y);
        return v / r;
    }

    public int GetDestination() {
        return Destination;
    }
    public void SetDestination(int NewDestination) {
        Destination = NewDestination;
    }
    public void IncrementDesination() {
        Destination++;
    }
}
