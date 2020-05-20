using UnityEngine;

public class BuildingTurner : MonoBehaviour
{
	[SerializeField]
	bool update;

	[SerializeField]
	SpriteRenderer spriteRenderer;

	private void Awake()
	{
		if (!enabled) return;
		Turn();
		if (!update)
			enabled = false;
	}

	private void Update()
	{
		Turn();
	}

	private void Turn()
	{
		var pos = transform.position;
		spriteRenderer.flipX = pos.x > 0;
	}
}
