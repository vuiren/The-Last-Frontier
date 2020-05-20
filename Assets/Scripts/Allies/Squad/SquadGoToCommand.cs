using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SquadGoToCommand : SquadComponent
{
	Camera mainCamera;

	List<Transform> squad = new List<Transform>();

	private void Start()
	{
		mainCamera = Camera.main;
	}

	internal override void SubscribeToEvents()
	{
		base.SubscribeToEvents();
		eventsProxy.OnSquadListChanged += UpdateList;
		eventsProxy.OnCommandTypeChanged += (CommandsEnum x) => enabled = x == CommandsEnum.GoTo;
	}

	private void UpdateList(List<Transform> obj)
	{
		squad = obj;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject())
			SendCommand();
	}

	public void SendCommand()
	{
		var reachPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
		reachPos.y = 0; reachPos.z = 0;
		eventsProxy.OnCommandSending?.Invoke(new Command(CommandsEnum.GoTo, reachPos));
	}
}
