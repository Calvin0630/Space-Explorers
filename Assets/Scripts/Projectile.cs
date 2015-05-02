using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    float ScreenSize;
	// Use this for initialization
	public bool belongsToPlayer;
	void Start () {
		belongsToPlayer = false;
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnCollisionEnter2D(Collision2D collision) {
        Destroy(gameObject);
    }
}
