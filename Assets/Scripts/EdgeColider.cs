using UnityEngine;
using System.Collections;

public class EdgeColider : MonoBehaviour {

	public bool hLeft,hRight,hTop,hBottom;
	public Frame frame;

		void OnCollisionEnter2D(Collision2D c) {
		print ("Collision");
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

	void OnCollisionExit2D(Collision2D c) {
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
