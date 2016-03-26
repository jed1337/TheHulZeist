using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {
	public float rotationSpeed;
	public int damageToGive;

	//public PlayerController player;
	//public GameObject impactEffect;

	//private Rigidbody2D rBody;
	//private Vector3 velocity;

	//// Use this for initialization
	//void Start () {
	//	player = FindObjectOfType<PlayerController>();
	//	rBody = GetComponent<Rigidbody2D>();

	//	//If the player is to the left of the projectile, instead of setting the
	//	//speed of the projectile to go to the right, it goes to the left
	//	if (player.transform.position.x < transform.position.x) {
	//		speed *= -1;
	//		rotationSpeed *= -1;
	//	}

	//	//rBody.AddForce(new Vector2(speed, rBody.velocity.y));
	//}

	// Update is called once per frame
	//void FixedUpdate () {
	//	rBody.velocity = new Vector2(speed, rBody.velocity.y);
	//	rBody.angularVelocity = rotationSpeed;		
	//}

	//void OnTriggerEnter2D(Collider2D other) {
	//	//print(other.gameObject.layer == LayerMask.NameToLayer("Terrain"));
	//	Rigidbody2D rBody = this.GetComponent<Rigidbody2D>();
	//	velocity = rBody.velocity;
	//	rBody.velocity = Quaternion.AngleAxis(180, rBody.position) * transform.forward * 1;
	//}
}
