using UnityEngine;
using System.Collections;

public class DroidAnimationController : AbstractAnimationController{
	public static DroidAnimationController instance;

	void Awake() {
		instance = this;
	}

	// Use this for initialization
	void Start () {
		animator = this.gameObject.GetComponent<Animator>();
	}
}
