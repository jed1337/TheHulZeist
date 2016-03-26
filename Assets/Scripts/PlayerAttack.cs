using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	public static PlayerAttack instance;

	public Collider2D attackTrigger;

	private bool attacking = false;
	private float attackTimer = 0;
	private float attackCd = 0.3f;

	private PlayerAnimationController anim;
	void Awake() {
		instance = this;
		attackTrigger.enabled = false;
		anim = PlayerAnimationController.instance;
	}

	public void TryAttack() {
		if(Input.GetKey(KeyCode.Space) && !attacking) {
			attacking = true;
			attackTimer = attackCd;


			attackTrigger.enabled = true;
		}
		if (attacking) {
			if (attackTimer > 0) {
				attackTimer -= Time.deltaTime;
			}
			else {
				attacking = false;
				attackTrigger.enabled = false;

			}
		}
		anim.UpdateIsAttacking(attacking);
	}
}
