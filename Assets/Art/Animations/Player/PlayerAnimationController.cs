using UnityEngine;
using System.Collections;

public class PlayerAnimationController : AbstractAnimationController {
	public static PlayerAnimationController instance;

	void Awake() {
		instance = this;
	}

	void Start () {
		animator = this.gameObject.GetComponentInChildren<Animator>();
	}

	public void UpdateIsGrounded(bool isGrounded) {
		animator.SetBool("isGrounded", isGrounded);
	}
}
