using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float damage;
    float ScreenSize;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Hostile") Destroy(col.gameObject);
		if (col.gameObject.tag == "Boss")
			col.gameObject.GetComponents<BossAI>()[0].BossHP -= damage;
        Destroy(gameObject);
    }
}
