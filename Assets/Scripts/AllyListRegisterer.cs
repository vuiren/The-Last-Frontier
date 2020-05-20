using UnityEngine;

public class AllyListRegisterer : MonoBehaviour
{
	private void OnEnable()
	{
		GlobalDataTransfer.AddAlly(gameObject);
	}

	private void OnDisable()
	{
		GlobalDataTransfer.RemoveAlly(gameObject);
	}

	private void OnDestroy()
	{
		GlobalDataTransfer.RemoveAlly(gameObject);
	}
}
