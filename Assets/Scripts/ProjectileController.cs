using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {
	public float rotationSpeed;
	public int damageToGive;
	public string owner;

	private string colOtherLayer;
	private string thisLayer;

	//For debugging
	private string collissionOtherName;

	void Start() {
		thisLayer = LayerMask.LayerToName(gameObject.layer);
	}

	void OnCollisionEnter2D(Collision2D col) {
		colOtherLayer = LayerMask.LayerToName(col.gameObject.layer);
		collissionOtherName = col.gameObject.name;

		print(collissionOtherName);

		//If the collission is not with another projectile (same layer), and it isn't with the terrain
		if(colOtherLayer!=thisLayer && colOtherLayer != ConstantNames.TERRAIN) {
			Debug.Log("Test");

			//if(colOtherLayer == ConstantNames.PLAYER) {
			//	Debug.Log("Hit player");
			//}
			//for (int i = 0; i < col.contacts.Length; i++) {
			//	Debug.Log(i+" Collided with: "+col.contacts[i].collider.name);
			//	if(col.contacts[i].collider.name == ConstantNames.ATTACK_TRIGGER) {
			//		Debug.Log("Hit trigger");
			//	}
			//}
		}
	}

	public void SetOwner(int ownerLayer) {
		SetOwner(LayerMask.LayerToName(ownerLayer));
	}

	public void SetOwner(string ownerLayer) {
		owner = ownerLayer;
	}
}
