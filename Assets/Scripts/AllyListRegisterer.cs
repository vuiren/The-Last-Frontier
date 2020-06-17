using UnityEngine;

public class AllyListRegisterer : MonoBehaviour
{
	private void OnEnable()
	{
		var instance = GameInfoSingleton.Instance;
		instance.AddAlly(gameObject);
	}

	private void OnDisable()
	{
		var instance = GameInfoSingleton.Instance;
		if (!instance) return;
		instance.RemoveAlly(gameObject);
	}

	private void OnDestroy()
	{
		var instance = GameInfoSingleton.Instance;
		if (!instance) return;
		instance.RemoveAlly(gameObject);
	}
}
