using UnityEngine;
using System.Collections;

public class ShootProjectile : MonoBehaviour {
	public float playerRange;
	public GameObject projectile;
	public PlayerController player;
	public Transform launchPoint;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();		
	}

	// Update is called once per frame
	void Update() {
		Vector3 playerPosition = player.transform.position;
		Vector3 projectilePosition = transform.position;

		Vector3 start = new Vector3(projectilePosition.x - playerRange, projectilePosition.y, projectilePosition.z);
		Vector3 end = new Vector3(projectilePosition.x + playerRange, projectilePosition.y, projectilePosition.z);
		Debug.DrawLine(start, end, Color.magenta);

		//If the player is within range, fire at him.
		if((transform.localScale.x > 0
			&& playerPosition.x < projectilePosition.x
			&& playerPosition.x > projectilePosition.x - playerRange)
			||
			(transform.localScale.x > 0
			&& playerPosition.x > projectilePosition.x
			&& playerPosition.x < projectilePosition.x + playerRange)){

			Instantiate(projectile, launchPoint.position, launchPoint.rotation);
		}
	}
}
