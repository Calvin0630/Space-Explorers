using UnityEngine;
using System.Collections;

public class StarEnemy : Enemy {
    public float StarShotDelay;
    
    protected override void ActiveUpdate() {
		base.ActiveUpdate ();
		if (ShotCounter == 0) {
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
