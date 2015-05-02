using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    float ScreenSize;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Hostile") Destroy(col.gameObject);
        Destroy(gameObject);
    }
}
