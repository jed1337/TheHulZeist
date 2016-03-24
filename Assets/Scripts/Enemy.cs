using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public LayerMask enemyMask;
	public float speed = 1;
	public bool isDebugMode = true;

	private Color PINK = new Color(253, 192, 203, 90);
	private Rigidbody2D myBody;
	private Transform myTrans;
	private float myWidth, myHeight;

	void Start() {
		myTrans = this.transform;
		myBody = this.GetComponent<Rigidbody2D>();

		SpriteRenderer mySprite = this.GetComponent<SpriteRenderer>();
		myWidth = mySprite.bounds.extents.x;
		myHeight = mySprite.bounds.extents.y;
	}

	void FixedUpdate() {
		//Use this position to cast the isGrounded/isBlocked lines from
		Vector2 lineCastPos = myTrans.position.toVector2() - myTrans.right.toVector2() * myWidth + Vector2.down * myHeight;

		//Check to see if there's ground in front of us before moving forward
		
		//Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);
		bool isGrounded = CheckBounds(lineCastPos, lineCastPos + Vector2.down, enemyMask);

		//Check to see if there's a wall in front of us before moving forward
		bool isBlocked = CheckBounds(lineCastPos, lineCastPos - myTrans.right.toVector2() * .05f, enemyMask);

		//If theres no ground, turn around. Or if I hit a wall, turn around
		if (!isGrounded || isBlocked) {
			Vector3 currRot = myTrans.eulerAngles;
			currRot.y += 180;
			myTrans.eulerAngles = currRot;
		}

		//Always move forward
		Vector2 myVel = myBody.velocity;
		myVel.x = -myTrans.right.x * speed;
		myBody.velocity = myVel;
	}

	bool CheckBounds(Vector2 start, Vector2 end, LayerMask mask) {
		if (isDebugMode) {
			Debug.DrawLine(start, end, PINK);
		}
		return Physics2D.Linecast(start, end, mask);
	}
}