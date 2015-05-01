using UnityEngine;
using System.Collections;

public class Frame : MonoBehaviour {
    Vector3 ScreenSize;
	// Use this for initialization
	void Start () {
        ScreenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        Debug.Log(ScreenSize.x + "   " + ScreenSize.y);
        Vector3 Right = new Vector3(ScreenSize.x, 0, 0);
        Vector3 Left = -Right;
        Vector3 Top = new Vector3(0, ScreenSize.y, 0);
        Vector3 Bottom = -Top;

        GameObject LeftCube = (GameObject)Instantiate(Projectile, transform.position, Quaternion.identity);
        GameObject RightCube = (GameObject)Instantiate(Projectile, transform.position, Quaternion.identity);
        GameObject TopCube = (GameObject)Instantiate(Projectile, transform.position, Quaternion.identity);
        GameObject BottomCube = (GameObject)Instantiate(Projectile, transform.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(ScreenSize.x + "   " + ScreenSize.y);
	}
}
