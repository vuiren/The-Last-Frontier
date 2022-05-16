using UnityEngine;

public class BulletDestroyer : MonoBehaviour
{
	[SerializeField]
	float existTime = 2f;

	private void Awake()
	{
		Destroy(gameObject, existTime);
	}
}
