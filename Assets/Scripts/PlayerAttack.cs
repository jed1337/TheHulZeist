﻿using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	public static PlayerAttack instance;

	public Collider2D attackTrigger;

	private bool attacking = true;
	private float attackTimer = 0;
	private float attackCd = 0.3f;

	private PlayerAnimationController anim;

	void Awake() {
		instance = this;
		//attackTrigger.enabled = false;
	}

	void Start() {
		anim = PlayerAnimationController.instance;
	}

	void FixedUpdate() {
		//	if (attacking) {
		//		if (attackTimer > 0) {
		//			attackTimer -= Time.deltaTime;
		//		}
		//		else {
		//			attacking = false;
		//			attackTrigger.enabled = false;

		//		}
		//		anim.UpdateIsAttacking(attacking);
		//	}
	}

	public void TryAttack() {
		//	if (!attacking) {

		//		attacking = true;
		//		attackTimer = attackCd;


		//		attackTrigger.enabled = true;
	}
}
