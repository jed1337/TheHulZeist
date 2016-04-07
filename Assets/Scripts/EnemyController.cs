using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	public LayerMask enemyMask;
	public float speed = 1;
	public bool isDebugMode = true;

	private Rigidbody2D myBody;
	private float myWidth;

	private Transform myTrans;
	private DroidAnimationController myAnim;
	void Start() {
		myTrans = this.transform;
		myBody = this.GetComponent<Rigidbody2D>();
		myWidth  = this.GetComponent<SpriteRenderer>().bounds.extents.x;
		myAnim = this.GetComponent<DroidAnimationController>();
	}

	void Update() {
		//Use this position to cast the isGrounded/isBlocked lines from
		Vector2 lineCastPos = myTrans.position - myTrans.right * myWidth;

		//Check to see if there's ground in front of us before moving forward
		bool isGrounded = CheckBounds(lineCastPos, lineCastPos + Vector2.down * 5, enemyMask);

		//Check to see if there's a wall in front of us before moving forward
		bool isBlocked = CheckBounds(lineCastPos, lineCastPos - myTrans.right.toVector2(), enemyMask);

		//If theres no ground, turn around. Or if I hit a wall, turn around
		if (!isGrounded || isBlocked) {
			TransformUtils.FlipArt(myTrans);
		}

		//Always move forward
		Vector2 myVel = myBody.velocity;
		myVel.x = -myTrans.right.x * speed;
		myBody.velocity = myVel;

		myAnim.UpdateSpeed(myBody.velocity.x);
	}


	bool CheckBounds(Vector2 start, Vector2 end, LayerMask mask) {
		if (isDebugMode) {
			Debug.DrawLine(start, end, Color.green);
		}
		return Physics2D.Linecast(start, end, mask);
	}
}