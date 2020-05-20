using System;
using UnityEngine;

internal interface ITargetsSearcher
{
	Action OnTargetsListChanged { get; set; }
	Transform GetClosestTarget();
}