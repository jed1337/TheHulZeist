using UnityEngine;
using System.Collections;

public class PlayerAnimationController : AbstractAnimationController {
	protected Transform mytrans;

	//Used to flip the character depending on its position
	protected Vector3 artScaleCache;

	void Start () {
		animator = this.gameObject.GetComponentInChildren<Animator>();
		mytrans = this.transform;
		artScaleCache = mytrans.localScale;
	}

	public void FlipArt(float currentSpeed) {
		if ((currentSpeed < 0 && artScaleCache.x == 1) || //Going left and facing right
			(currentSpeed > 0 && artScaleCache.x == -1))  //Going right and facing left
		{
			artScaleCache.x *= -1;
			mytrans.localScale = artScaleCache;

		}
	}

	public new void UpdateSpeed(float currentSpeed) {
		base.UpdateSpeed(currentSpeed);
		FlipArt(currentSpeed);
	}

	public void UpdateIsGrounded(bool isGrounded) {
		animator.SetBool("isGrounded", isGrounded);
	}

	public void UpdateVertSpeed(float vertSpeed) {
		animator.SetFloat("vertSpeed", vertSpeed);
	}
}
