using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {
    List<GameObject> FirstList;
    Vector3[] FirstPath;
    public GameObject Enemy;
    // Use this for initialization
	void Start () {
	    FirstList = new List<GameObject>();
        //goes from top right to left middle
        FirstPath = new Vector3[] { new Vector3(12, 5, 0), new Vector3(-12, 0, 0) };
	}
	
	// Update is called once per frame
	void Update () {
        Spawn1(new Vector3(12, 5));
        foreach (GameObject obj in FirstList) {
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, FirstPath[1], .1f);
        }
	}

    // spawns an enemy per second for 5 seconds at a location
    void Spawn1(Vector3 Location) {
        int Count = 0;
        if (Time.time % 1 < .01f && Count <= 5) {
            GameObject clone = (GameObject)Instantiate(Enemy, Location, Quaternion.identity);
            FirstList.Add(clone);
        }
    }
}
