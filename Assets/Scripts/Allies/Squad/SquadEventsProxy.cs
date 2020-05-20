using System;
using System.Collections.Generic;
using UnityEngine;

public class SquadEventsProxy : MonoBehaviour
{
	public Action<Transform> OnAllyAdd { get; set; }
	public Action<Transform> OnAllyRemove { get; set; }
	public Action OnClearSquad { get; set; }
	public Action<List<Transform>> OnSquadListChanged { get; set; }
	public Action<CommandsEnum> OnCommandTypeChanged { get; set; }
	public Action<Command> OnCommandSending { get; set; }
}
