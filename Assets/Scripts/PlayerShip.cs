using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerShip : MonoBehaviour {
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
	// Use this for initialization
	void Start () {
        ShotDelay = 10;
        RBody = gameObject.GetComponent<Rigidbody2D>();
        Count = 0;
	}
    
	void OnCollisionEnter2D(Collision2D c) {
		//gameOver.gameObject.SetActive(true);
		//Object.Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        PlayerPos = transform.position;

        if (Input.GetKey(("w"))) {
            transform.position += SpeedOfMotion * Vector3.up;
            //RBody.velocity = SpeedOfBullet * Vector3.up;
            
        }
        if (Input.GetKey(("a"))) {
            transform.position += SpeedOfMotion * Vector3.left;
            //RBody.velocity = SpeedOfBullet * Vector3.left;
        }
        if (Input.GetKey(("s"))) {
            transform.position += SpeedOfMotion * Vector3.down; 
            //RBody.velocity = SpeedOfBullet * Vector3.right;       
        }
        if (Input.GetKey(("d"))) {
            transform.position += SpeedOfMotion * Vector3.right; 
            //RBody.velocity = SpeedOfBullet * Vector3.down;
        }
        CurrentSpeedY = RBody.velocity.y;

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
}
