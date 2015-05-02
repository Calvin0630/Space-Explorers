using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {
    List<GameObject> FirstList;
    public Vector3[] FirstPath;
    public GameObject Enemy;

	public float speed;

    // Use this for initialization
	void Start () {
	    FirstList = new List<GameObject>();
        //goes from top right to left middle
		FirstPath = new Vector3[] { new Vector3 (10, 5, 0), new Vector3(-10, 0, 0) };
        StartCoroutine(MyCoroutine(FirstPath[0], FirstList));
	}

	// Update is called once per frame
	void Update () {
        foreach (GameObject obj in FirstList) {
			obj.transform.position = Vector3.MoveTowards (obj.transform.position, FirstPath [1], speed);
            
			
        }
	}

    IEnumerator MyCoroutine(Vector3 Location, List<GameObject> list) {
        int Count = 0;
        for (int i = 0; i < 4; i++) {
            yield return new WaitForSeconds(1);
            GameObject clone = (GameObject)Instantiate(Enemy, Location, Quaternion.identity);
            list.Add(clone);
            Count++;
            yield return new WaitForSeconds(1);
        }
    }
    /*
    // spawns an enemy per second for 5 seconds at a location
    void Spawn1(Vector3 Location, List<GameObject> list) {
        int Count = 0;
        while (Count<5) {
            if (Time.time % 1 == 0) {
                GameObject clone = (GameObject)Instantiate(Enemy, Location, Quaternion.identity);
                list.Add(clone);
                Count++;
                Debug.Log(Time.time);
            }
        }
    }*/
}
