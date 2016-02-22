using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;	// Reference to the player object we'll follow, (don't forget to set it in the editor)

	private Vector3 offset;		// Vector to offset the camera from the player, which we'll do in code

	// Use this for initialization
	void Start () {
		// What is the difference in the camera position vs. the player's position?
		offset = transform.position - player.transform.position;
	}
	
	// LateUpdate is called once per frame, after all Update calls have been made, (so we know player has moved)
	void LateUpdate () {
		// Set the camera's position so it follows the player
		transform.position = player.transform.position + offset;
	}
}
