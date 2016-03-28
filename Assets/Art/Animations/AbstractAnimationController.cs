using UnityEngine;
using System.Collections;

public abstract class AbstractAnimationController : MonoBehaviour {

	protected Transform mytrans;
	protected Animator animator;

	//Used to flip the character depending on its position
	protected Vector3 artScaleCache;

	// Use this for initialization
	void Start() {
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

	public void UpdateSpeed(float currentSpeed) {
		animator.SetFloat("speed", currentSpeed);
		FlipArt(currentSpeed);
	}

	public void UpdateIsAttacking(bool isAttacking) {
		animator.SetBool("isAttacking", isAttacking);
	}
}
