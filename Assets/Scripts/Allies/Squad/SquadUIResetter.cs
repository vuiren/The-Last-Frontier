using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadUIResetter : SquadComponent
{
	internal override void SubscribeToEvents()
	{
		base.SubscribeToEvents();
		//eventsProxy.OnClearSquad += () => GlobalDataTransfer.OnUIModeChange?.Invoke(UIModesEnum.MainUI);
	}
}
