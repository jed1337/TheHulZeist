using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {
	public float rotationSpeed;
	public float speed;
	public int damageToGive;

	public PlayerController player;
	public GameObject impactEffect;

	private Rigidbody2D myRigidBody2D;
	private Vector3 velocity;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
		myRigidBody2D = GetComponent<Rigidbody2D>();

		//If the player is to the left of the projectile, instead of setting the
		//speed of the projectile to go to the right, it goes to the left
		if (player.transform.position.x < transform.position.x) {
			speed *= -1;
			rotationSpeed *= -1;
		}
	}

	// Update is called once per frame
	void Update () {
		myRigidBody2D.velocity = new Vector2(speed, myRigidBody2D.velocity.y);
		myRigidBody2D.angularVelocity = rotationSpeed;		
	}

	//void OnTriggerEnter2D(Collider2D other) {
	//	//print(other.gameObject.layer == LayerMask.NameToLayer("Terrain"));
	//	Rigidbody2D rBody = this.GetComponent<Rigidbody2D>();
	//	velocity = rBody.velocity;
	//	rBody.velocity = Quaternion.AngleAxis(180, rBody.position) * transform.forward * 1;
	//}
}
