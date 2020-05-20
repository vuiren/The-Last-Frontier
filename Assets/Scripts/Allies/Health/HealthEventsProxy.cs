using System;
using UnityEngine;

public class HealthEventsProxy : MonoBehaviour
{
	public Action<int> OnTakingDamage { get; set; }
	public Action<int> OnHeal { get; set; }
	public Action<int> OnHealthChanged { get; set; }
	public Action OnDeath { get; set; }
	public bool RequiredHealing { get; set; }
}
