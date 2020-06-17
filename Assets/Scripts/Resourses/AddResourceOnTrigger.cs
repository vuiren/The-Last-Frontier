using UnityEngine;

public class AddResourceOnTrigger : MonoBehaviour
{
	[SerializeField]
	Cost resorceCountAdd;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!collision.gameObject.CompareTag("Ally")) return;
		var instance = GameInfoSingleton.Instance;

		instance.MetalCount += resorceCountAdd.MetalCost;
		Destroy(gameObject);
	}
}
