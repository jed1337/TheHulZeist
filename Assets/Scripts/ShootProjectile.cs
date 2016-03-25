using UnityEngine;
using System.Collections;

public class ShootProjectile : MonoBehaviour {
	public float playerRange;
	public float fireRate;

	public GameObject projectile;
	public PlayerController player;
	public Transform launchPoint;

	private float shotCounter;

	void Start () {
		player = FindObjectOfType<PlayerController>();
		shotCounter = fireRate;
	}

	void Update() {
		shotCounter -= Time.deltaTime;

		Vector3 playerPosition = player.transform.position;
		Vector3 projectilePosition = transform.position;

		Vector3 start = new Vector3(projectilePosition.x - playerRange, projectilePosition.y, projectilePosition.z);
		Vector3 end = new Vector3(projectilePosition.x + playerRange, projectilePosition.y, projectilePosition.z);
		Debug.DrawLine(start, end, Color.magenta);

		//Only fire if the enemy has reloaded
		if (shotCounter < 0 && transform.localScale.x > 0) {
			//If the player is within range, fire at him.
			if (( playerPosition.x < projectilePosition.x	//Fire at the left
				&& playerPosition.x > projectilePosition.x - playerRange)
				||
				(	playerPosition.x > projectilePosition.x	//Fire at the right
				&& playerPosition.x < projectilePosition.x + playerRange)) {

				Instantiate(projectile, launchPoint.position, launchPoint.rotation);
			}
			shotCounter = fireRate;
		}
	}
}
