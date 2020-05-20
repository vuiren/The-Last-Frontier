using System;
using UnityEngine;

public class MedicEventsProxy : MonoBehaviour
{
	public Action<Transform> OnClosestHealTargetUpdate { get; set; }
	public Action OnHealTargetGone { get; set; }
}
