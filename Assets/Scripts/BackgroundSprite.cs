using UnityEngine;
using System.Collections;

public class BackgroundSprite : MonoBehaviour {
	public float scrollRate;
	private Frame frame;
	public float Offset;

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<Rigidbody2D> ().velocity = scrollRate * Vector3.down;
		frame = GameObject.Find("Frame").GetComponent<Frame>();

	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y <  Offset * frame.BottomCube.transform.position.y) {
			transform.position = Offset * frame.TopCube.transform.position;
		}
	}
}
