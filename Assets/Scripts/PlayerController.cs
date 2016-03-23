using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;
	public float jumpVelocity;
	public bool canMoveInAir  = true;

	private bool isGrounded = false;
	private float hInput    = 0;

	public LayerMask playerMask;

	private Rigidbody2D myBody;
	private Transform myTrans;

	private PlayerAnimationController myAnim;


	void Start() {
		myAnim = PlayerAnimationController.instance;

		myBody  = this.GetComponent<Rigidbody2D>();
		myTrans = this.transform;
		//tagGround = GameObject.Find(this.name + "/tag_ground").transform;
	}

	void FixedUpdate() {
		isGrounded = myBody.velocity.y < 0.01;

		myAnim.UpdateIsGrounded(isGrounded);

	#if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT || UNITY_EDITOR
			KeyboardMoving();
	#endif
	  Move (hInput);
	}

	private void Move(float _speed) {
		//if (!canMoveInAir && !isGrounded)
		//	return;
		myAnim.UpdateSpeed(_speed);
		Vector2 moveVel = myBody.velocity;
		moveVel.x = _speed * this.speed;
		myBody.velocity = moveVel;
	}

	public void Jump() {
		if (isGrounded)
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