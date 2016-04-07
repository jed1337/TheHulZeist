using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;
	public float jumpVelocity;
	public bool canMoveInAir  = true;
	public LayerMask playerMask;

	public float groundCheckRadius;
	public LayerMask whatIsGround;
	public Transform groundCheck;

	private bool grounded;
	private float hInput = 0;
	private Rigidbody2D myBody;

	private PlayerAnimationController animationController;
	private PlayerAttack myAttack;

	void Start() {
		myAttack = PlayerAttack.instance;
		animationController = this.GetComponent<PlayerAnimationController>();
		myBody = this.GetComponent<Rigidbody2D>();
	}

	void Update() {
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
		animationController.UpdateVertSpeed(myBody.velocity.y);
		animationController.UpdateIsGrounded(grounded);

#if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT || UNITY_EDITOR
		KeyboardMoving();
#endif
		Move(hInput);
	}

	private void Move(float speed) {
		animationController.UpdateSpeed(speed);
		Vector2 moveVel = myBody.velocity;
		moveVel.x = speed * this.speed;
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
		if (Input.GetKey(KeyCode.Space)) {
			myAttack.TryAttack();
		}
	}
}