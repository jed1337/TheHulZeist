using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	public static PlayerAttack instance;

	public Collider2D attackTrigger;
	public float attackCd = 0.3f;

	private bool attacking = true;
	private float attackTimer = 0;

	private PlayerAnimationController myAnim;

	void Awake() {
		instance = this;
		attackTrigger.enabled = false;
	}

	void Start() {
		myAnim = PlayerAnimationController.instance;
	}

	void FixedUpdate() {
		if (attacking) {
			if (attackTimer > 0) {
				attackTimer -= Time.deltaTime;
			}
			else {
				attacking = false;
				attackTrigger.enabled = false;

			}
			myAnim.UpdateIsAttacking(attacking);
		}
	}

	public void TryAttack() {
		if (!attacking) {

			attacking = true;
			attackTimer = attackCd;


			attackTrigger.enabled = true;
		}
	}
}
