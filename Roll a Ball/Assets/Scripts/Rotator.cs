using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		// This is a non-physics update, so Update() is fine.
		// This updates the object's current rotation with a value adjusted for the framerate using deltaTime.
		Vector3 rotation = new Vector3 (15, 30, 45) * Time.deltaTime;
		transform.Rotate (rotation);
	}
}
