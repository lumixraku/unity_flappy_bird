using System.Collections;
using UnityEngine;
using static System.Console;

public class Bird : MonoBehaviour {
	public Rigidbody rb;
	public float timer = 0;
	public int frameNumber = 10; // frame number one seconds
	public int frameCount = 0; //  frame counter

	public bool animation = false; // whether play the fly animation
	public bool canJump = false;

	void Start () {
		//Component.rigidbody’ is obsolete: ‘Property rigidbody has been deprecated. Use GetComponent<Rigidbody>() instead. (UnityUpgradable)’
		// this.rigidbody.velocity = new Vector3 (2, 0, 0);
		rb = GetComponent<Rigidbody> ();
		rb.velocity = new Vector3(2, 0, 0);
		// this.GetComponent<Rigidbody> ().velocity = new Vector3 (2, 0, 0);
	}

	// Update is called once per frame
	void Update () {
		//hard code here for test
		Vector3 vel  = rb.velocity;
		rb.velocity = new Vector3(1,vel.y,vel.z);


		// animation
		// if (GameManager._intance.GameState == GameManager.GAMESTATE_PLAYING) {
		timer += Time.deltaTime;
		if (timer >= 1.0f / frameNumber) {
			frameCount++;
			timer -= 1.0f / frameNumber;
			int frameIndex = frameCount % 3;
			// update material 's offset x
			// how to set the property of(x offset)  MainTex : Main Texture
			this.GetComponent<Renderer>().material.SetTextureOffset ("_MainTex", new Vector2 (0.333333f * frameIndex, 0));
			//this.renderer.material.SetTextureScale("_MainText",new Vector2(1,1));
			WriteLine (".....");
		}
		// }

		// if (GameManager._intance.GameState == GameManager.GAMESTATE_PLAYING) {
		// control jump
		if (Input.GetMouseButton (0) ) { // left mouse button down
			GetComponent<AudioSource>().Play();
			Vector3 vel2 = this.GetComponent<Rigidbody> ().velocity;
			this.GetComponent<Rigidbody> ().velocity = new Vector3 (vel2.x, 5, vel2.z);
		}
		// }
	}

	public void getLife () {
		GetComponent<Rigidbody> ().useGravity = true;
		this.GetComponent<Rigidbody> ().velocity = new Vector3 (2, 0, 0);
	}
}