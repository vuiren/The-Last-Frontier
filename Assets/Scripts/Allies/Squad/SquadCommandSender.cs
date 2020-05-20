using System.Collections.Generic;
using UnityEngine;

public class SquadCommandSender : SquadComponent
{
	List<Transform> squad = new List<Transform>();
	internal override void SubscribeToEvents()
	{
		base.SubscribeToEvents();
		eventsProxy.OnCommandSending += SendCommand;
		eventsProxy.OnSquadListChanged += UpdateList;
	}

	private void UpdateList(List<Transform> obj)
	{
		squad = obj;
	}

	private void SendCommand(Command obj)
	{
		foreach (var e in squad)
		{
			var reciever = e.GetComponent<CommandReciever>();
			reciever.ExecuteCommand(new Command(obj.commandType, obj.commandVectorValue, obj.commandBuildingValue));
		}
	}
}
