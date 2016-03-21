using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed        = 10;
	public float jumpVelocity = 10;
	public bool canMoveInAir  = true;

	//private bool isGrounded = false;
	private float hInput    = 0;

	public LayerMask playerMask;
	private Rigidbody2D myBody;
	private Transform myTrans, tagGround;

	void Start() {
		myBody  = this.GetComponent<Rigidbody2D>();
		myTrans = this.transform;
		//tagGround = GameObject.Find(this.name + "/tag_ground").transform;
	}

	void FixedUpdate() {
		//isGrounded = Physics2D.Linecast(myTrans.position, tagGround.position, playerMask);

#if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT || UNITY_EDITOR
		KeyboardMoving();
#else
  Move (hInput);
#endif
	}

	private void Move(float horizontalInput) {
		//if (!canMoveInAir && !isGrounded)
		//	return;

		Vector2 moveVel = myBody.velocity;
		moveVel.x = horizontalInput * speed;
		myBody.velocity = moveVel;
	}

	public void Jump() {
		//if (isGrounded)
			myBody.velocity += jumpVelocity * Vector2.up;
	}

	public void TouchMoving(float horizonalInput) {
		hInput = horizonalInput;
	}

	public void KeyboardMoving() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			Jump();
		}

		if (Input.GetKey(KeyCode.D)) {
			Move(1);
		}

		if (Input.GetKey(KeyCode.A)) {
			Move(-1);
		}
	}
}