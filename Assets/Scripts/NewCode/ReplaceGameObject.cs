using UnityEngine;

public class ReplaceGameObject : MonoBehaviour
{
	[SerializeField]
	GameObject objectToBeReplaced;

	[SerializeField]
	GameObject objectToBeReplacedBy;

	public void DoReplaceGameObject()
	{
		var toBeReplacedTransform = objectToBeReplaced.transform;
		if (objectToBeReplacedBy)
			Instantiate(objectToBeReplacedBy, toBeReplacedTransform.position, toBeReplacedTransform.rotation);
		Destroy(objectToBeReplaced);
	}
}