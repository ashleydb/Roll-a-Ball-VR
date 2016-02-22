using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Text countText;	// Reference to a UI element to output the score to
	public Rigidbody rb;	// Reference to the physics component of this object
	public float speed;		// Public so we can set this in the inspector in the Unity Editor. 10 is good.
	private int count;		// Score for number of pick-ups collected
	public Button playAgainButton;	// Reference to a UI element so the player can reset the game
	private Vector3 moveTowardsPosition; // Position that could be passed in from Gaze, Touch, Mouse to move the player towards
	private bool shouldMove;

	// Called on first frame this script is active, (i.e. first frame of game)
	void Start() {
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		shouldMove = false;
	}

	// Happens just before Physics calculations
	void FixedUpdate() {
		// If we got input from clicks, taps or cardboard, move towards it. Otherwise, see if there is keyboard/gamepad input.
		if (shouldMove) {
			// Get a vector from the player position to the point passed in
			Vector3 movement = moveTowardsPosition - gameObject.transform.position;

			// Multiply the input vector by the object's speed, then apply that result as a force to the object to move it
			rb.AddForce (movement * speed);

			// Don't do this every frame, only when we've been sent a new position, (e.g. OnClick)
			shouldMove = false;
		} else {
			// Get device independent input, e.g. keyboard keys
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");

			// Make a vector based on that input
			Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);

			// Multiply the input vector by the object's speed, then apply that result as a force to the object to move it
			rb.AddForce (movement * speed);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pick Up")) {
			// If we roll into a pick-up, hide it
			other.gameObject.SetActive (false);
			// Increment our score and update the UI
			count++;
			SetCountText ();
		}
	}

	void SetCountText() {
		if (count == 0) {
			countText.text = "Tap ground to move";
		} else if (count == 12) {
			countText.text = "You Win!";
			playAgainButton.gameObject.SetActive (true);
		} else {
			countText.text = "Count: " + count.ToString ();
		}
	}

	public void SetMoveTowardsPoint(Vector3 worldPosition) {
		moveTowardsPosition = worldPosition;
		shouldMove = true;
	}
}
