using UnityEngine;
using System.Collections;

public abstract class AbstractAnimationController : MonoBehaviour {
	protected Animator animator;

	//public void UpdateSpeed(float currentSpeed) {
	//	animator.SetFloat("speed", currentSpeed);
	//}

	public void UpdateIsAttacking(bool isAttacking) {
		animator.SetBool("isAttacking", isAttacking);
	}

	public void UpdateIsDestroyed(bool isDestroyed) {
		animator.SetBool("isDestroyed", isDestroyed);

		//StartCoroutine(Die());
		Destroy(gameObject);
	}

	private IEnumerator Die() {
		yield return new WaitForSeconds(0.5f);
	}
}
