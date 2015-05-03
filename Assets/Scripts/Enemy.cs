using UnityEngine;
using System.Collections;

public class Enemy : EdgeColider {
    public int ShotDelay;
    public float SpeedOfBullet;
	protected int ShotCounter;
	protected const float BaseVelocity = 0.05f;
	public bool active;
    public GameObject EnemyProjectile;
    int Destination;
    public float ShotAccuracy; //higher is less accurate
    protected Vector3 PlayerPos;

	// Use this for initialization
	void Start () {

		// dirty fab hack
		this.gameObject.GetComponent<Rigidbody2D> ().isKinematic = true;
		this.gameObject.GetComponent<CircleCollider2D>().isTrigger = true;

		active = false;
        PlayerPos = PlayerShip.PlayerPos;
    }
	
	// Update is dispatched to active/inactive states
	void Update () {
		ShotCounter = (ShotCounter + 1) % ShotDelay;
		if (hTop)
			active = true;

		if (hBottom) {
			Destroy (this.gameObject);
			return;
		}
		if (active) {
			ActiveUpdate ();
		} else {
			InactiveUpdate ();
		}
	}

	protected virtual void InactiveUpdate() {
		this.transform.position += BaseVelocity * Vector3.down;
	}

	protected virtual void ActiveUpdate () {
        PlayerPos = PlayerShip.PlayerPos;
        
	}




    public Vector3 GetUnitVector(Vector3 v) {
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
