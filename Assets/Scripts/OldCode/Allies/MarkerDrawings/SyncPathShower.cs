using UnityEngine;

public class SyncPathShower : MonoBehaviour, INPCInfoReader
{
	[SerializeField] NPCInfoHolder NPCInfoHolder;
	[SerializeField] Vector2 finishPointOffset;
	[SerializeField] LineRenderer pathLine;

	public void SetNPCInfoHandler(NPCInfoHolder NPCInfoHolder)
	{
		this.NPCInfoHolder = NPCInfoHolder;
	}

	public void SyncPath()
	{
		var destinationPoint = NPCInfoHolder.DestinationPoint;
		var offset = new Vector3(finishPointOffset.x, finishPointOffset.y);
		pathLine.SetPositions(new[] { transform.position + offset, destinationPoint + offset });
	}

	private void LateUpdate()
	{
		SyncPath();
	}
}
