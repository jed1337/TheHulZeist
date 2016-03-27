using UnityEngine;
using System.Collections;
using System.Linq;

public class ProjectileController : MonoBehaviour {
	public float rotationSpeed;
	public int damageToGive;

	private string owner;
	private string hostileTo;

	private string colOtherLayer;
	private string thisLayer;

	//For debugging
	//private string collissionOtherName;

	void Start() {
		thisLayer = LayerMask.LayerToName(gameObject.layer);
	}

	void OnCollisionEnter2D(Collision2D col) {
		colOtherLayer = LayerMask.LayerToName(col.gameObject.layer);
		//collissionOtherName = colOther.gameObject.name;

		//If the contact is with a hostility
		if (colOtherLayer == hostileTo) {
			//DebugLogContact();
			bool destroyHostility = true;
			if (colOtherLayer == ConstantNames.PLAYER) {
				string col0Name = col.contacts[0].collider.name;
				bool deflected = col0Name == ConstantNames.ATTACK_TRIGGER;
				DebugCheckIfDeflected(col0Name);

				if (deflected) {	//Swap owner and hostile to
					string temp = owner;
					owner = hostileTo;
					hostileTo = temp;

					destroyHostility = false;
				}
			}
			if (destroyHostility) {
				Destroy(col.gameObject);
			}
		}
	}

	private static void DebugCheckIfDeflected(string col0Name) {
		if (col0Name == ConstantNames.ATTACK_TRIGGER) {
			Debug.Log("Blocked");
		}
		else {
			Debug.Log("HIT PLAYER " + col0Name);
		}
	}

	private void DebugLogContact() {
		Debug.Log("HIT from " + owner + " against " + hostileTo);
	}

	public void SetOwner(int ownerLayer) {
		SetOwner(LayerMask.LayerToName(ownerLayer));
	}

	public void SetOwner(string ownerLayer) {
		owner = ownerLayer;
	}

	public void SetHostileTo(int hostileLayer) {
		SetHostileTo(LayerMask.LayerToName(hostileLayer));
	}

	public void SetHostileTo(string hostileLayer) {
		hostileTo = hostileLayer;
	}
}
