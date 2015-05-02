using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {
    List<GameObject> list;
    Vector3[] FirstPast;
    public GameObject Enemy;
    // Use this for initialization
	void Start () {
	    list = new List<GameObject>();
        //goes from top right to left middle
        FirstPast = new Vector3[] { new Vector3(5, 12, 0), new Vector3(-12, 0, 0) };
	}
	
	// Update is called once per frame
	void Update () {
        foreach (GameObject obj in list) {
            obj.GetComponent<Rigidbody2D>().velocity = Vector3.right + Vector3.down;
        }
	}

    // spawns an enemy per second for 5 seconds at a location
    void Spawn1(Vector3 Location) {
        int Count = 0;
        if (Time.time % 1 < .01f && Count <= 5) {
            GameObject clone = (GameObject)Instantiate(Enemy, Location, Quaternion.identity);
            list.Add(clone);
        }
    }
}
