using UnityEngine;

public class TrackMovingDirection : MonoBehaviour, INPCInfoReader
{
	[SerializeField] NPCInfoHolder NPCInfoHolder;
	[SerializeField] float delta = 0.05f;

	public void SetNPCInfoHandler(NPCInfoHolder NPCInfoHolder)
	{
		this.NPCInfoHolder = NPCInfoHolder;
	}

	private void Update()
	{
		NPCInfoHolder.MovingDirection = UpdateMovingCondition();
	}

	private MovingsEnum UpdateMovingCondition()
	{
		var pointX = NPCInfoHolder.DestinationPoint.x;
		var positionX = transform.position.x;
		var dif = Mathf.Abs(pointX - positionX);

		if (dif <= delta)
			return MovingsEnum.Standing;

		if (pointX < positionX)
			return MovingsEnum.GoingLeft;

		if (pointX > positionX)
			return MovingsEnum.GoingRight;

		return MovingsEnum.Standing;
	}
}
