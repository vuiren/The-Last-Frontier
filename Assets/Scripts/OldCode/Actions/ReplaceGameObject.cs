using UnityEngine;

public class ReplaceGameObject: MonoBehaviour
{
	public void DoReplaceGameObject(GameObject objectToBeReplaced, GameObject objectToReplaceWith)
	{
		var toBeReplacedTransform = objectToBeReplaced.transform;
		if (objectToReplaceWith)
			GameObject.Instantiate(objectToReplaceWith, toBeReplacedTransform.position, toBeReplacedTransform.rotation);
		GameObject.Destroy(objectToBeReplaced);
	}
}