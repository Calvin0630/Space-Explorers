using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour {
    public int Damage;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Friendly") {
            col.GetComponent<PlayerShip>().Health -= Damage;
        }
        Destroy(gameObject);
    }
}
