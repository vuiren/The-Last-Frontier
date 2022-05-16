using UnityEngine;

public class SetStartResourceCount : MonoBehaviour
{
	[SerializeField] GameResources startGameResources;

	private void Awake()
	{
		PlayerResources.Instance.AvailableResources = startGameResources;
	}
}