using UnityEngine;
using System.Collections;

public class EdgeColider : MonoBehaviour {

	public bool hLeft,hRight,hTop,hBottom;
	private Frame frame;

	void Awake() {
		frame = GameObject.Find("Frame").GetComponent<Frame>();
	}

	void OnTriggerEnter2D(Collider2D c) {
		print ("Triggered: "+this);
		if (c.gameObject.Equals(frame.TopCube)) {
				hTop = true;
		}
		if (c.gameObject.Equals(frame.BottomCube)) {
			hBottom = true;
		}
		if (c.gameObject.Equals(frame.LeftCube)) {
			hLeft = true;
		}
		if (c.gameObject.Equals(frame.RightCube)) {
			hRight = true;
		}

	}

	void OnTriggerExit2D(Collider2D c) {
		if (c.gameObject.Equals(frame.TopCube)) {
			hTop = false;
		}
		if (c.gameObject.Equals(frame.BottomCube)) {
			hBottom = false;
		}
		if (c.gameObject.Equals(frame.LeftCube)) {
			hLeft = false;
		}
		if (c.gameObject.Equals(frame.RightCube)) {
			hRight = false;
		}
		
	}
}
