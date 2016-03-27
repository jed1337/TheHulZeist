using UnityEngine;
using System.Collections;

public class ShootProjectile : MonoBehaviour {
	public float playerRange;
	public float projectileSpeed;
	public float fireRate;
	public float projectileLife = 3;

	public GameObject projectile;
	public PlayerController player;
	public Transform launchPoint;

	private float shotCounter;

	//For debugging
	private Vector3 pPosition;
	private Vector3 lPosition;
	private Vector3 force;
	private bool hitTerrain = false;

	void Start () {
		player = FindObjectOfType<PlayerController>();
		shotCounter = fireRate;
	}

	void Update() {
		shotCounter -= Time.deltaTime;

		Vector3 playerPos = player.transform.position;
		Vector3 enemyPos = transform.position;

		Vector3 start = new Vector3(enemyPos.x - playerRange, enemyPos.y, enemyPos.z);
		Vector3 end = new Vector3(enemyPos.x + playerRange, enemyPos.y, enemyPos.z);
		Debug.DrawLine(start, end, Color.magenta);
		Debug.DrawLine(launchPoint.position, playerPos, Color.red);
		hitTerrain = Physics2D.Linecast(launchPoint.position, playerPos, 1 << LayerMask.NameToLayer("Terrain"));

		//Only fire if the enemy has reloaded
		if (shotCounter < 0 && transform.localScale.x > 0) {
			//If the player is within range, fire at him.
			if (( playerPos.x < enemyPos.x	//Fire at the left
				&& playerPos.x > enemyPos.x - playerRange)
				||
				(playerPos.x > enemyPos.x		//Fire at the right
				&& playerPos.x < enemyPos.x + playerRange)
				) {

				CloneProjectile(playerPos);
				{//For debugging
					pPosition = playerPos;
					lPosition = launchPoint.position;
				}
			}
			shotCounter = fireRate;
		}
	}

	//Shoot projectile
	private void CloneProjectile(Vector3 playerPos) {
		GameObject cloneProjectile = Instantiate(projectile, launchPoint.position, launchPoint.rotation) as GameObject;
		ProjectileController pc = cloneProjectile.GetComponent(typeof(ProjectileController)) as ProjectileController;

		force = (playerPos - launchPoint.position).normalized* projectileSpeed;	//For debugging
		cloneProjectile.GetComponent<Rigidbody2D>().AddForce(force);
		pc.SetOwner(gameObject.layer);
		pc.SetHostileTo(ConstantNames.PLAYER);
		Destroy(cloneProjectile, projectileLife);
	}
}
