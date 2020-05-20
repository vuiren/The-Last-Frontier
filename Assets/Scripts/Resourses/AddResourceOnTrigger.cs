using UnityEngine;

public class AddResourceOnTrigger : MonoBehaviour
{
	[SerializeField]
	Cost resorceCountAdd;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!collision.gameObject.CompareTag("Ally")) return;
		GlobalDataTransfer.MetalCount += resorceCountAdd.MetalCost;
		Destroy(gameObject);
	}
}
