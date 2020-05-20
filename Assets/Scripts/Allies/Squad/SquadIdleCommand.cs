using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SquadIdleCommand : SquadComponent
{
	List<Transform> squad = new List<Transform>();

	internal override void SubscribeToEvents()
	{
		base.SubscribeToEvents();
		eventsProxy.OnSquadListChanged += UpdateList;
		//eventsProxy.OnCommandTypeChanged += (CommandsEnum x) => enabled = x == CommandsEnum.Idle;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
		{
			SendCommand();
		}
	}

	private void SendCommand()
	{
	//	eventsProxy.OnCommandSending?.Invoke(new Command(CommandsEnum.Idle, new Vector3()));
	}

	private void UpdateList(List<Transform> obj) => squad = obj;


}
