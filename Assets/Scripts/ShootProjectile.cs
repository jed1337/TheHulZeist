using UnityEngine;
using System.Collections;

public class ShootProjectile : MonoBehaviour {
	public float playerRange;
	public float fireRate;
	public float bulletLife = 3;

	public GameObject projectile;
	public PlayerController player;
	public Transform launchPoint;

	private float shotCounter;

	private Vector3 pPosition;
	private Vector3 lPosition;

	void Start () {
		player = FindObjectOfType<PlayerController>();
		shotCounter = fireRate;
	}

	void Update() {
		shotCounter -= Time.deltaTime;

		Vector3 playerPosition = player.transform.position;
		Vector3 projPosition = transform.position;


		Vector3 start = new Vector3(projPosition.x - playerRange, projPosition.y, projPosition.z);
		Vector3 end = new Vector3(projPosition.x + playerRange, projPosition.y, projPosition.z);
		Debug.DrawLine(start, end, Color.magenta);

		//Only fire if the enemy has reloaded
		if (shotCounter < 0 && transform.localScale.x > 0) {
			//If the player is within range, fire at him.
			if (( playerPosition.x < projPosition.x	//Fire at the left
				&& playerPosition.x > projPosition.x - playerRange)
				||
				(playerPosition.x > projPosition.x  //Fire at the right
				&& playerPosition.x < projPosition.x + playerRange)
				){

				//cloneProjectile.GetComponent<Rigidbody2D>().velocity = (playerPosition.toVector2() - launchPoint.position.toVector2());


				//Instantiate(projectile, launchPoint.position, launchPoint.rotation);
				GameObject cloneProjectile = (GameObject)Instantiate(projectile, launchPoint.position, launchPoint.rotation);
				cloneProjectile.GetComponent<Rigidbody2D>().velocity = (playerPosition - launchPoint.position);

				pPosition = playerPosition;
				lPosition = launchPoint.position;
			}
			shotCounter = fireRate;
		}
	}
}
