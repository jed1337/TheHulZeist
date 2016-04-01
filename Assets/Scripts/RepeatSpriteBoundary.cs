using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class RepeatSpriteBoundary : MonoBehaviour {
	SpriteRenderer spriteRenderer;
	void Awake() {

		spriteRenderer = GetComponent<SpriteRenderer>();
		if (!SpritePivotAlignment.GetSpriteAlignment(gameObject).Equals(SpriteAlignment.TopRight)) {
			Debug.LogError("You forgot change the sprite pivot to Top Right.");
		}
		Vector2 spriteSize = new Vector2(spriteRenderer.bounds.size.x / transform.localScale.x, spriteRenderer.bounds.size.y / transform.localScale.y);

		GameObject childPrefab = new GameObject();

		SpriteRenderer childSprite = childPrefab.AddComponent<SpriteRenderer>();
		childPrefab.transform.position = transform.position;
		childSprite.sprite = spriteRenderer.sprite;

		GameObject child;
		for (int i = 0, h = (int)Mathf.Round(spriteRenderer.bounds.size.y); i * spriteSize.y < h; i++) {
			for (int j = 0, w = (int)Mathf.Round(spriteRenderer.bounds.size.x); j * spriteSize.x < w; j++) {
				child = Instantiate(childPrefab) as GameObject;
				child.transform.position = transform.position - (new Vector3(spriteSize.x * j, spriteSize.y * i, 0));
				child.transform.parent = transform;
			}
		}

		Destroy(childPrefab);
		spriteRenderer.enabled = false;

	}
}