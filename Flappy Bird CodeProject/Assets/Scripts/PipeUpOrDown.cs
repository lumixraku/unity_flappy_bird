using System.Collections;
using UnityEngine;

public class PipeUpOrDown : MonoBehaviour {
	public AudioSource hitMusic;
	public AudioSource dieMusic;
	void OnCollisionEnter (Collision other) {
		// GetComponent<AudioSource> ().Play ();
		hitMusic.Play ();
		dieMusic.Play ();
		print ("OnCollisionEnter Hit!!");
		if (other.gameObject.tag == "Player") {
			GameManager._intance.GameState = GameManager.GAMESTATE_END;
		}
	}

}