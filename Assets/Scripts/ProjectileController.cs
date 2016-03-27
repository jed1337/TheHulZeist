using UnityEngine;
using System.Collections;
using System.Linq;

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

	void OnCollisionEnter2D(Collision2D colOther) {
		colOtherLayer = LayerMask.LayerToName(colOther.gameObject.layer);
		collissionOtherName = colOther.gameObject.name;

		//Ignore collission if with another projectile (thislayer), terrain, and the owner
		string[] ignoreCol = new string[]{ thisLayer, ConstantNames.TERRAIN, owner};
		if (!ignoreCol.Contains(colOtherLayer)) {

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
