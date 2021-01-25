using UnityEngine;

public class SyncAttackDistance : MonoBehaviour, INPCInfoReader
{
	[SerializeField] NPCInfoHolder NPCInfoHolder;
	[SerializeField] GameObject circleMarker;

	private void Start()
	{
		DoSyncAttackDistance();
	}

	private void DoSyncAttackDistance()
	{
		circleMarker.transform.localScale *= NPCInfoHolder.NPCInfo.AttackSettings.AttackStartDistance;
	}

	public void SetNPCInfoHandler(NPCInfoHolder NPCInfoHolder)
	{
		this.NPCInfoHolder = NPCInfoHolder;
	}
}
