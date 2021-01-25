using UnityEngine;

public class AddResourceOnTrigger : MonoBehaviour
{
	[SerializeField]
	GameResources resourcesCountToAdd;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("FUCKING METAL NOTICED");
		if (!collision.gameObject.CompareTag("Ally")) return;
		var instance = PlayerResources.Instance;

		instance.AddResources(resourcesCountToAdd);
		Destroy(gameObject);
	}
}
