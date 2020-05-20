using System.Collections.Generic;
using UnityEngine;

public class SquadKeeper : SquadComponent
{
	[SerializeField]
	List<Transform> squad = new List<Transform>();

	internal override void SubscribeToEvents()
	{
		base.SubscribeToEvents();
		eventsProxy.OnAllyAdd += AddAlly;
		eventsProxy.OnAllyRemove += RemoveAlly;
		eventsProxy.OnClearSquad += ClearSquad;
		GlobalDataTransfer.OnAllyDeath += RemoveAlly;
	}

	private void RemoveAlly(Transform obj)
	{
		if (!squad.Contains(obj)) return;
		obj.GetComponent<SquadMemberEventsProxy>().OnMemberUnchoosed?.Invoke();
		squad.Remove(obj);
		eventsProxy.OnSquadListChanged?.Invoke(squad);
		GlobalDataTransfer.OnSquadListChanger?.Invoke(squad);
	}

	private void AddAlly(Transform obj)
	{
		if (squad.Contains(obj))
		{
			RemoveAlly(obj);
			return;
		}
		squad.Add(obj);
		obj.GetComponent<SquadMemberEventsProxy>().OnMemberChoosed?.Invoke();
		eventsProxy.OnSquadListChanged?.Invoke(squad);
		GlobalDataTransfer.OnSquadListChanger?.Invoke(squad);
	}

	public void ClearSquad()
	{
		while (squad.Count > 0)
		{
			Transform e = squad[0];
			RemoveAlly(e);
		}
		//	eventsProxy.OnCommandTypeChanged?.Invoke(CommandsEnum.Idle);
	}
}
