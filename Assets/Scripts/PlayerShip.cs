using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerShip : EdgeColider {
    public float SpeedOfMotion;
    float CurrentSpeedY;
    public float SpeedOfBullet;
	public Text gameOver;
    float Count; //the counter for the timer
    float ShotDelay;
    Vector3 MousePos;
    Vector3 PlayerToMouse;
    public GameObject Projectile;
    public static Vector3 PlayerPos;
    Rigidbody2D RBody;
    public int Health;
    public int PeakScore;
    // Use this for initialization
	void Start () {
        ShotDelay = 10;
        RBody = gameObject.GetComponent<Rigidbody2D>();
        Count = 0;
        PeakScore = Health;
	}
  
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Score: "+PeakScore+" Health: "+Health);
        PlayerPos = transform.position;

		if (Input.GetKey(("w")) && !hTop) {
            transform.position += SpeedOfMotion * Vector3.up;
            //RBody.velocity = SpeedOfBullet * Vector3.up;
            
        }
		if (Input.GetKey(("a")) && !hLeft) {
            transform.position += SpeedOfMotion * Vector3.left;
            //RBody.velocity = SpeedOfBullet * Vector3.left;
        }
		if (Input.GetKey(("s")) && !hBottom) {
            transform.position += SpeedOfMotion * Vector3.down; 
            //RBody.velocity = SpeedOfBullet * Vector3.right;       
        }
		if (Input.GetKey(("d")) && !hRight) {
            transform.position += SpeedOfMotion * Vector3.right; 
            //RBody.velocity = SpeedOfBullet * Vector3.down;
        }
        CurrentSpeedY = RBody.velocity.y;

        if (Health <= 0) Destroy(gameObject);
	}



    void FixedUpdate() {
        Count++;
        //control to shoot with mouse
        if (Input.GetMouseButton(0)) {
            if (Count > ShotDelay) {
                Count = 0;
                GameObject clone = (GameObject)Instantiate(Projectile, transform.position, Quaternion.identity);
                MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                PlayerToMouse = MousePos - transform.position;
                PlayerToMouse = new Vector3(PlayerToMouse.x, PlayerToMouse.y, 0);
                clone.GetComponent<Rigidbody2D>().velocity = SpeedOfBullet * GetUnitVector(PlayerToMouse) + new Vector3(0, CurrentSpeedY, 0);
            }
        }

        //control to shoot with space
        if (Input.GetKey(KeyCode.Space)) {
            if (Count > ShotDelay) {
                Count = 0;
                //shoot stuff
                GameObject clone = (GameObject)Instantiate(Projectile, transform.position, Quaternion.identity);
                clone.GetComponent<Rigidbody2D>().velocity = SpeedOfBullet * Vector3.up + new Vector3(0, CurrentSpeedY, 0);
            }
        }
    }

    Vector3 GetUnitVector(Vector3 v) {
        float r = Mathf.Sqrt(v.x * v.x + v.y * v.y);
        return v / r;
    }

    public void RemoveHealth(int damage) {
        Health -= damage;
    }

    public int GetHealth() {
        return this.Health;
    }
}
