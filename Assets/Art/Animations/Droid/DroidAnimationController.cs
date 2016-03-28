using UnityEngine;
using System.Collections;

public class DroidAnimationController : AbstractAnimationController{
	//public static DroidAnimationController instance;

	//private Transform mytrans;
	//private Animator myAnim;

	void Awake() {
		instance = this;
	}

	// Use this for initialization
	void Start () {
		myAnim = this.gameObject.GetComponent<Animator>();
	}
}
