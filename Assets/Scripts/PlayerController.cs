using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;
	public float jumpVelocity;
	public bool canMoveInAir  = true;
	public LayerMask playerMask;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	private float hInput = 0;
	private Rigidbody2D myBody;

	private PlayerAnimationController myAnim;
	private PlayerAttack myAttack;

	void Start() {
		myAnim = PlayerAnimationController.instance;
		myAttack = PlayerAttack.instance;
		myBody = this.GetComponent<Rigidbody2D>();
	}

	void FixedUpdate() {
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
		myAnim.UpdateIsGrounded(grounded);

#if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT || UNITY_EDITOR
		KeyboardMoving();
#endif
		Move (hInput);
	}

	private void Move(float _speed) {
		myAnim.UpdateSpeed(_speed);

		Vector2 moveVel = myBody.velocity;
		moveVel.x = _speed * this.speed;
		myBody.velocity = moveVel;
	}

	public void Jump() {
		if (grounded)
			myBody.velocity += jumpVelocity * Vector2.up;
	}

	public void TouchMoving(float horizonalInput) {
		hInput = horizonalInput;
	}

	public void KeyboardMoving() {
		hInput = Input.GetAxisRaw("Horizontal");
		if (Input.GetKeyDown(KeyCode.W)) {
			Jump();
		}
		myAttack.TryAttack();
	}
}