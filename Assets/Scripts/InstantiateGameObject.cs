using UnityEngine;

public class InstantiateGameObject : MonoBehaviour
{
	[SerializeField]
	Transform instantiatePoint;

	[SerializeField]
	GameObject objectToInstantiate;

	public void DoInstantiate()
	{
		Instantiate(objectToInstantiate, instantiatePoint.position, instantiatePoint.rotation);
	}
}
