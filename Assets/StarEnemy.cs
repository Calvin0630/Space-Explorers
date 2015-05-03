using UnityEngine;
using System.Collections;

public class StarEnemy : Enemy {
    public float StarShotDelay;

    void Start() {

    }

    // Update is called once per frame
    void Update() {
        
    }
    
    void FixedUpdate() {
        //Debug.Log(Time.time);
        if (Time.time % StarShotDelay == 0) {
            for (int i = -1; i < 2; i++) {
                for (int j = -1; j < 2; j++) {
                    if (i == 0 && j == 0) j++;
                    GameObject clone = (GameObject)Instantiate(EnemyProjectile, transform.position, Quaternion.identity);
                    //sets velocity to shoot in all 8 directions
                    clone.GetComponent<Rigidbody2D>().velocity = SpeedOfBullet * new Vector3(i, j, 0);
                }
            }
        }
    }
}
