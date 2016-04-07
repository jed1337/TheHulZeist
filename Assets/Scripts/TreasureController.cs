using UnityEngine;
using System.Collections;

public class TreasureController : MonoBehaviour {

	public LayerMask player;

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.layer == player.value) {
			Debug.Log("PLAYER");
			//Go to win screen
		}
		else {
			Debug.Log(LayerMask.LayerToName(col.gameObject.layer));
		}
	}
}
