using UnityEngine;
using System.Collections;

public class Bounce : MonoBehaviour {

	public LayerMask collisionMask;
	public Transform blade;

	private float speed = 15;
	private float rotSpeed = 800;

	void Update() {
		//Move the projectile forward
		//transform.Translate(Vector3.forward * Time.deltaTime * speed);

		//Rotate it
		//blade.Rotate(Vector3.up * Time.deltaTime * rotSpeed);

		Ray ray = new Ray(transform.position, transform.forward);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, Time.deltaTime * speed + .1f, collisionMask)){
			//Debug.Log("eow");
			Debug.Log("Hit "+collisionMask.ToString());
			Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);
			transform.Translate(reflectDir);
			//float rot = 90 - Mathf.Atan2(reflectDir.z, reflectDir.x) * Mathf.Rad2Deg;
			//transform.eulerAngles = new Vector3(0, rot, 0);
		}
	}
}
