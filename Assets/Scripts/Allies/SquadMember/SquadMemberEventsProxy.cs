using System;
using UnityEngine;

public class SquadMemberEventsProxy : MonoBehaviour
{
	public Action OnMemberChoosed { get; set; }
	public Action OnMemberUnchoosed { get; set; }
}
