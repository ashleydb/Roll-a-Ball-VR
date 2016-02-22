using UnityEngine;
using System.Collections;

public class GameplayMenu : MonoBehaviour {
	// Reset the game and start again
	public void PlayAgain () {
		UnityEngine.SceneManagement.SceneManager.LoadScene ("MiniGame");
	}
}
