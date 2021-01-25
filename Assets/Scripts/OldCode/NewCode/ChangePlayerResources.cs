using UnityEngine;

public class ChangePlayerResources : MonoBehaviour
{
	public void UsePlayerResouces(NPCInfoHolder infoHolder)
	{
		var instance = PlayerResources.Instance;
		instance.CreatingResourcesChange(infoHolder.CreatingInfo);
	}

	public void StopUsingPlayerResources(NPCInfoHolder infoHolder)
	{
		var instance = PlayerResources.Instance;
		instance.DestroyingResourcesChange(infoHolder.CreatingInfo);
	}
}
