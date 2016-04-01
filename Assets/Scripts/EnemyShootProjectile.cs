using UnityEngine;
using System.Collections;

public class EnemyShootProjectile : MonoBehaviour {
	public float playerRange;
	public float projectileSpeed;
	public float fireRate;
	public float projectileLife = 3;

	public GameObject projectile;
	public PlayerController player;
	public Transform launchPoint;

	private float shotCounter;

	private Vector3 force;
	private bool hitTerrain = false;

	private DroidAnimationController myAnim;

	//For debugging
	private Vector3 playerPos;
	private Vector3 enemyPos;
	private Vector3 launchPos;

	void Start () {
		player = FindObjectOfType<PlayerController>();
		shotCounter = fireRate;
		myAnim = DroidAnimationController.instance;
	}

	void FixedUpdate() {
			
		try{
			shotCounter -= Time.deltaTime;

			playerPos = player.transform.position;
			enemyPos = transform.position;
			launchPos = launchPoint.position;

			DebugDrawProjectilePath(playerPos, enemyPos);

			hitTerrain = Physics2D.Linecast(launchPoint.position, playerPos, 1 << LayerMask.NameToLayer("Terrain"));

			//Only fire if there is no terrain in the way and if has reloaded and if the player is in range
			if (!hitTerrain && shotCounter < 0 && transform.localScale.x > 0) {
				if ((playerPos.x < enemyPos.x //Fire at the left
					&& playerPos.x > enemyPos.x - playerRange)
					||
					(playerPos.x > enemyPos.x  //Fire at the right
					&& playerPos.x < enemyPos.x + playerRange)
					) {

					//Flip enemy if the player is behind it
					if (atMiddle(playerPos, enemyPos, launchPos)) {
						TransformUtils.FlipArt(transform);
					}
					myAnim.UpdateIsAttacking(true);
					CloneProjectile(playerPos);
				}
				shotCounter = fireRate;
			}else if (shotCounter > 0) {
				myAnim.UpdateIsAttacking(false);
			}
		}
		catch(MissingReferenceException){
		}
	}

	private bool atMiddle(Vector3 start, Vector3 middle, Vector3 end) {
		return ((start.x < middle.x && middle.x < end.x)
				||(start.x > middle.x && middle.x > end.x));
	}

	private void DebugDrawProjectilePath(Vector3 playerPos, Vector3 enemyPos) {
		Vector3 start = new Vector3(enemyPos.x - playerRange, enemyPos.y, enemyPos.z);
		Vector3 end = new Vector3(enemyPos.x + playerRange, enemyPos.y, enemyPos.z);
		Debug.DrawLine(start, end, Color.magenta);

		Color targetInSight = hitTerrain ? Color.red : Color.green;
		Debug.DrawLine(launchPoint.position, playerPos, targetInSight);
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
