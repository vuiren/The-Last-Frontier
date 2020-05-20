using UnityEngine;

public class MedicHealTarget : MedicComponent
{
	[SerializeField]
	int healCount = 1;

	[SerializeField]
	float timeBetweenHealing = 1f;

	Transform target;
	float curTime;

	internal override void SubscribeToEvents()
	{
		base.SubscribeToEvents();
		eventsProxy.OnClosestHealTargetUpdate += UpdateTarget;
	}

	private void UpdateTarget(Transform obj)
	{
		target = obj;
	}

	private void Update()
	{
		if (target == null) return; 
		if (ReadyToHeal())
			Heal();
		else
			ReloadProcess();
	}

	private bool ReadyToHeal()
	{
		return curTime <= 0;
	}

	private void Heal()
	{
		var health = target.GetComponent<HealthEventsProxy>();
		if (!health.RequiredHealing) return;
		health.OnHeal?.Invoke(healCount);
		curTime = timeBetweenHealing;
	}

	private void ReloadProcess()
	{
		curTime -= Time.deltaTime;
	}
}
