using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.SceneManagement;

public class ProjectileController : MonoBehaviour {
    public AudioSource deflect;
	public float rotationSpeed;
	public int damageToGive;
	public bool inDebugMode = false;
	public bool isPlayerImmortal = false;

	private string owner;
	private string hostileTo;

	private string colOtherLayer;

	//For debugging
	//private string collissionOtherName;

	void OnCollisionEnter2D(Collision2D col) {
		colOtherLayer = LayerMask.LayerToName(col.gameObject.layer);

		//If the contact is with a hostility
		if (colOtherLayer == hostileTo) {
			if(col.gameObject.GetComponent<AbstractAnimationController>()== null) {
				throw new System.MissingMemberException("Abstract Animation Controller missing in " + col.gameObject.name);
			}

			bool destroyHostility = true;
			if (colOtherLayer == ConstantNames.PLAYER) {
				string col0Name = col.contacts[0].collider.name;
				bool deflected = col0Name == ConstantNames.ATTACK_TRIGGER;
				//DebugCheckIfDeflected(col0Name);

				if (deflected) {  //Swap owner and hostile to
                    deflect.Play();
					Debug.Log("Deflected");
					string temp = owner;
					owner = hostileTo;
					hostileTo = temp;

					destroyHostility = false;
					GetComponent<ParticleSystem>().startColor = Color.red;
				} else if (!isPlayerImmortal){
					Destroy (col.gameObject);
					SceneManager.LoadScene ("Game Over");
				}
				if (inDebugMode || isPlayerImmortal) {
					destroyHostility = false;
				}
			}
			if (destroyHostility) {
				DebugLogContact();
				if (!inDebugMode) {
					col.gameObject.GetComponent<AbstractAnimationController>().UpdateIsDestroyed(true);
					Destroy(col.gameObject);
				}
				Destroy(gameObject);	//Destroy the projectile
			}

		}
	}

	private static void DebugCheckIfDeflected(string col0Name) {
		if (col0Name == ConstantNames.ATTACK_TRIGGER) {
			Debug.Log("DEFLECTED");
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
