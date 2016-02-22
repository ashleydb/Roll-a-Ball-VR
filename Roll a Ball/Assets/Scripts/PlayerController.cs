using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Text countText;	// Reference to a UI element to output the score to
	public Rigidbody rb;	// Reference to the physics component of this object
	public float speed;		// Public so we can set this in the inspector in the Unity Editor. 10 is good.
	private int count;		// Score for number of pick-ups collected

	// Called on first frame this script is active, (i.e. first frame of game)
	void Start() {
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
	}

	// Happens just before Physics calculations
	void FixedUpdate () {
		// Get device independent input, e.g. keyboard keys
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		// Make a vector based on that input
		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);

		// Multiply the input vector by the object's speed, then apply that result as a force to the object to move it
		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pick Up")) {
			// If we roll into a pick-up, hide it
			other.gameObject.SetActive (false);
			// Increment our score and update the UI
			count++;
			SetCountText ();
		}
		// TODO: Check for collisions with "Wall" and play a bonk sound?
	}

	void SetCountText () {
		if (count == 12)
			countText.text = "You Win!";
		else
			countText.text = "Count: " + count.ToString ();
	}
}
