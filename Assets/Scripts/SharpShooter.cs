using UnityEngine;
using System.Collections;

public class SharpShooter : Enemy {


	protected override void ActiveUpdate() {

		if (ShotCounter == 0) {
			print ("Shooting");
			GameObject clone = (GameObject)Instantiate(EnemyProjectile, transform.position, Quaternion.identity);
			//sets velocity to shoot at the player plus a random vector
			clone.GetComponent<Rigidbody2D>().velocity = SpeedOfBullet * (GetUnitVector(PlayerPos-transform.position)) +
				new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0) * ShotAccuracy;
		}
	}
}
