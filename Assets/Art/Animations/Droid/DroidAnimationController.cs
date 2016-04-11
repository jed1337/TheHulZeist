using UnityEngine;
using System.Collections;

public class DroidAnimationController : AbstractAnimationController {
	void Start () {
		animator = this.gameObject.GetComponent<Animator>();
	}


}
