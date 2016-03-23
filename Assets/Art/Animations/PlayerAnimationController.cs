using UnityEngine;
using System.Collections;

public class PlayerAnimationController : MonoBehaviour {

	public static PlayerAnimationController instance;

	private Transform mytrans;
	private Animator myAnim;

	//Used to flip the character depending on its position
	private Vector3 artScaleCache; 


	void Start () {
		mytrans = this.transform;
		myAnim = this.gameObject.GetComponent<Animator>();
		instance = this;

		artScaleCache = mytrans.localScale;
	
	}

	public void FlipArt(float currentSpeed) {
		if((currentSpeed<0 && artScaleCache.x == 1) || //Going left and facing right
			(currentSpeed>0 && artScaleCache.x == -1))  //Going right and facing left
		{
			artScaleCache.x *= -1;
			mytrans.localScale = artScaleCache;

		}
	}

	public void UpdateSpeed(float currentSpeed) {
		myAnim.SetFloat("speed", currentSpeed);
		FlipArt(currentSpeed);
	}

	public void UpdateIsGrounded(bool isGrounded) {
		myAnim.SetBool("isGrounded", isGrounded);
	}

	
	void Update () {
	}
}
