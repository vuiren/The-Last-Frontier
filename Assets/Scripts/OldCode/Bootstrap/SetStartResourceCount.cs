using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartResourceCount : MonoBehaviour
{
	[SerializeField] GameResources startGameResources;

	private void Awake()
	{
		PlayerResources.Instance.AvailableResources = startGameResources;
	}
}