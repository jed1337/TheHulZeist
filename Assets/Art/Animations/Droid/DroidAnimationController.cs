using UnityEngine;
using System.Collections;

public class DroidAnimationController : AbstractAnimationController {
	void Start () {
		animator = this.gameObject.GetComponent<Animator>();
	}

	public void UpdateSpeed(float currentSpeed) {
		animator.SetFloat("speed", currentSpeed);
	}
}
