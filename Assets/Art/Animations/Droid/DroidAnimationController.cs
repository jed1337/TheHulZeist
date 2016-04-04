using UnityEngine;
using System.Collections;

public class DroidAnimationController : AbstractAnimationController {
	//public class DroidAnimationController : MonoBehaviour{
	public static DroidAnimationController instance;
	//protected Animator animator;

	void Awake() {
		instance = this;
	}

	// Use this for initialization
	void Start () {
		animator = this.gameObject.GetComponent<Animator>();
	}

	public void UpdateSpeed(float currentSpeed) {
		animator.SetFloat("speed", currentSpeed);
	}
}
