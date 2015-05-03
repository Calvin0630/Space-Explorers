using UnityEngine;
using System.Collections;

public class StraightShooter : Enemy {

	protected override void ActiveUpdate() {
		base.ActiveUpdate ();
		if (ShotCounter == 0) {
			GameObject clone = (GameObject)Instantiate(EnemyProjectile, transform.position, Quaternion.identity);
			//sets velocity to shoot at the player plus a random vector
			clone.GetComponent<Rigidbody2D>().velocity = SpeedOfBullet * Vector3.down;
		}
	}
}
