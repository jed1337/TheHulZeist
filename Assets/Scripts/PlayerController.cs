using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpHeight;
	private Rigidbody2D rigi;

	private void awake() {
	}
	
	// Use this for initialization
	void Start () {
		rigi = GetComponent<Rigidbody2D>();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
										//0 horizontal move, jump height vertical move
			rigi.velocity = new Vector2(rigi.velocity.x, jumpHeight);
		}

		if (Input.GetKey(KeyCode.D)) {
										//moveSpeed horizontal, gets current vertical velocity for the y
										//Setting the vertical move to 0 will not allow the user to
											//Jump if D is held
			rigi.velocity = new Vector2(moveSpeed, rigi.velocity.y);
		}

		if (Input.GetKey(KeyCode.A)) {
			rigi.velocity = new Vector2(-moveSpeed, rigi.velocity.y);
		}
	}
}
