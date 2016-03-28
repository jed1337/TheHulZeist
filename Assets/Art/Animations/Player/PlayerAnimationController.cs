using UnityEngine;
using System.Collections;

public class PlayerAnimationController : AbstractAnimationController {
	//public static PlayerAnimationController instance;

	void Awake() {
		instance = this;
	}

	void Start () {
		myAnim = this.gameObject.GetComponentInChildren<Animator>();
	}
}
