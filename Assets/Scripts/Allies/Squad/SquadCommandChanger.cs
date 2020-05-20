﻿using Sirenix.OdinInspector;

public class SquadCommandChanger : SquadComponent
{
	internal override void SubscribeToEvents()
	{
		base.SubscribeToEvents();
		GlobalDataTransfer.OnCommandTypeChange += (x) => eventsProxy.OnCommandTypeChanged?.Invoke(x);
		eventsProxy.OnClearSquad += () => eventsProxy.OnCommandTypeChanged?.Invoke(CommandsEnum.GoTo);
	}
}