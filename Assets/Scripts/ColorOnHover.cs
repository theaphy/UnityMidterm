using UnityEngine;
/* Tint the object when hovered. */

public class ColorOnHover : MonoBehaviour {

	public Color color;
	public SpriteRenderer spriteRenderer;

	Color originalColour;

	void Start() {
		if (spriteRenderer == null) {
			spriteRenderer = GetComponent<SpriteRenderer> ();
		}
		originalColour = spriteRenderer.color;
	}

	void OnMouseEnter ()
	{
			spriteRenderer.color *= color;

	}

	void OnMouseExit()
	{
			spriteRenderer.color = originalColour;
	}

}
