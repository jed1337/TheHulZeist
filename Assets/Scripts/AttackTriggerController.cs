using UnityEngine;
using System.Collections;

public class AttackTriggerController : MonoBehaviour {

	public float move;

	private Vector3 localScale;
	private Vector2 initialPosition;

	void OnTriggerEnter2D(Collider2D col) {
		this.initialPosition = transform.position;
		localScale = this.transform.localScale;
	}
}