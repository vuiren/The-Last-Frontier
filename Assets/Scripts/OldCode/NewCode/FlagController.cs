using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour
{
	[Button]
	public void ScoreFlag()
	{
		Destroy(gameObject, 3f);
	}

}
