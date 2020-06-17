using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGlobalData : MonoBehaviour
{
	private void Awake()
	{
		var instance = GameInfoSingleton.Instance;
		instance.ResetVariables();
	}
}
