using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {
    List<Enemy> FirstList;
    public Vector3[] FirstPath;
    public Enemy Enemy;
    Enemy obj;

    public float speed;

    // Use this for initialization
    void Start() {
        FirstList = new List<Enemy>();
        //goes from top right to left middle
        StartCoroutine(SpawnCoroutine1(FirstPath[0], FirstList, 5, 1));
    }

    // Update is called once per frame
    void Update() {
        MoveMethod1(FirstList, FirstPath);
    }

    IEnumerator SpawnCoroutine1(Vector3 Location, List<Enemy> list, int NumberOfEnemies, float Delay) {
        int Count = 0;
        for (int i = 0; i < NumberOfEnemies; i++) {
            yield return new WaitForSeconds(Delay);
            Enemy clone = (Enemy)Instantiate(Enemy, Location, Quaternion.identity);
            list.Add(clone);
            Count++;
            yield return new WaitForSeconds(1);
        }
    }

    //A method that moves a list of enemy in single file along a path, must be put in update function
    void MoveMethod1(List<Enemy> List, Vector3[] Path) {
        for (int i = 0; i < List.Count; i++) {
            obj = List[i];
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, Path[obj.GetDestination()], speed);
            if (obj.transform.position == Path[obj.GetDestination()] && (obj.GetDestination() < Path.Length)) {
                obj.IncrementDesination();
                if (obj.GetDestination() == Path.Length) {
                    obj.SetDestination(0);
                }
            }
        }
    }
}

