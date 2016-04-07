using UnityEngine;
using System.Collections;

// @NOTE the attached sprite's position should be "top left" or the children will not align properly
// Strech out the image as you need in the sprite render, the following script will auto-correct it when rendered in the game
[RequireComponent(typeof(SpriteRenderer))]

// Generates a nice set of repeated sprites inside a streched sprite renderer
// @NOTE Vertical only, you can easily expand this to horizontal with a little tweaking
public class RepeatSpriteBoundary : MonoBehaviour {
	SpriteRenderer spriteRenderer;

	void Awake() {
		// Get the current sprite with an unscaled size
		spriteRenderer = GetComponentInParent<SpriteRenderer>();
		Vector2 spriteSize = new Vector2(spriteRenderer.bounds.size.x / transform.localScale.x, spriteRenderer.bounds.size.y / transform.localScale.y);

		// Generate a child prefab of the sprite renderer
		GameObject childPrefab = new GameObject();
		SpriteRenderer childSprite = childPrefab.AddComponent<SpriteRenderer>();
		childPrefab.transform.position = transform.position;
		childSprite.sprite = spriteRenderer.sprite;

		// Loop through and spit out repeated tiles
		GameObject child;
		//for (int i = 1; i< (int)Mathf.Round(spriteRenderer.bounds.size.x); i++) {
		for (int i = 1; i< 10; i++) {
			child = Instantiate(childPrefab) as GameObject;
			child.transform.position = transform.position + (new Vector3(spriteSize.x, 0, 0) * i*3);
			child.transform.parent = transform;
		}

		// Set the parent last on the prefab to prevent transform displacement
		childPrefab.transform.parent = transform;

		// Disable the currently existing sprite component since its now a repeated image
		spriteRenderer.enabled = false;
	}
}