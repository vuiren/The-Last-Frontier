using UnityEngine;

public class ChooseRandomDirection : MonoBehaviour, INPCInfoReader
{
    [SerializeField]
    NPCInfoHolder NPCInfo;
	public void SetNPCInfoHandler(NPCInfoHolder NPCInfoHolder)
	{
        NPCInfo = NPCInfoHolder;
	}

	public void DoChooseRandomDirection()
	{
		var random = Random.Range(-1, 2);
		NPCInfo.RigidBody.velocity = new Vector2(random * NPCInfo.NPCInfo.MoveSpeed, 0);
	}
}
