using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {
    List<Enemy> FirstList;
    public Vector3[] FirstPath;
    public Enemy Enemy;

	public float speed;

    // Use this for initialization
	void Start () {
	    FirstList = new List<Enemy>();
        //goes from top right to left middle
        StartCoroutine(SpawnCoroutine1(FirstPath[0], FirstList));
	}

	// Update is called once per frame
	void Update () {        
                foreach (Enemy obj in FirstList) {
                    obj.transform.position = Vector3.MoveTowards(obj.transform.position, FirstPath[obj.GetDestination()], speed);
                    if (obj.transform.position == FirstPath[obj.GetDestination()] && (obj.GetDestination() < FirstPath.Length )) {
                        obj.IncrementDesination();
                        if (obj.GetDestination() == FirstPath.Length) {
                            FirstList.Remove(obj);
                            Destroy(obj);
                    }
                }
                }
	}

    IEnumerator SpawnCoroutine1(Vector3 Location, List<Enemy> list) {
        int Count = 0;
        for (int i = 0; i < 4; i++) {
            yield return new WaitForSeconds(1);
            Enemy clone = (Enemy)Instantiate(Enemy, Location, Quaternion.identity);
            list.Add(clone);
            Count++;
            yield return new WaitForSeconds(1);
        }
    }
    /*
    IEnumerator MovingCoroutine1(Vector3[] array, List<Enemy> list) {
        for (int i = 1; i < array.Length; i++) {
            foreach (Enemy obj in list) {
                obj.transform.position = Vector3.MoveTowards(obj.transform.position, FirstPath[1], speed);
            }
            
        }
    }*/
}

