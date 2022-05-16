using System.Collections.Generic;
using UnityEngine;

public class KeepOneObjectActive : MonoBehaviour
{
	[SerializeField] Transform root;

	[SerializeField] List<GameObject> forceThisObjectsToKeepActive;

	public void DisactivateAllButOne(GameObject objectToKeepActive)
	{
		for (int i = 0; i < root.childCount; i++)
		{
			var child = root.GetChild(i);
			child.gameObject.SetActive(false);
		}
		objectToKeepActive.SetActive(true);

		foreach (var e in forceThisObjectsToKeepActive)
			e.SetActive(true);
	}
}
