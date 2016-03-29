using UnityEngine;
using System.Collections;

public abstract class AbstractAnimationController : MonoBehaviour {
	protected Animator animator;

	public void UpdateSpeed(float currentSpeed) {
		animator.SetFloat("speed", currentSpeed);
	}

	public void UpdateIsAttacking(bool isAttacking) {
		animator.SetBool("isAttacking", isAttacking);
	}
}
