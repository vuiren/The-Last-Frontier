using System;
using UnityEngine;

public class AllySpawnerEventsProxy : MonoBehaviour
{
	public Action<AllyInfo> OnSpawning { get; set; }
}
