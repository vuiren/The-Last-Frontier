using UnityEngine;

public class MedicHealTarget : MonoBehaviour
{
	[SerializeField]
	NPCInfoHolder medicInfoHolder;

	[SerializeField]
	int healCount = 1;

	[SerializeField]
	float timeBetweenHealing = 1f;

	float curTime;


	private void Update()
	{
		var target = medicInfoHolder.AttackTarget;
		ReloadProcess();
		if (!target) return; 
		if (ReadyToHeal())
			Heal(target);
	}

	private bool ReadyToHeal()
	{
		return curTime <= 0;
	}

	private void Heal(GameObject target)
	{
		var health = target.transform.GetComponentInChildren<IHealthController>();
		if (!ShouldHealTarget(health, target)) return;
		health.TakeHeal(healCount);
		StartHealingReloading();
	}

	private void StartHealingReloading()
	{
		curTime = timeBetweenHealing;
	}

	private bool ShouldHealTarget(IHealthController healable, GameObject target)
	{
		var distanceCheck = 
			Vector2.Distance(target.transform.position, transform.position) < 
			medicInfoHolder.NPCInfo.AttackSettings.AttackStartDistance;
		return healable != null && distanceCheck && healable.HealingRequired();
	}

	private void ReloadProcess()
	{
		curTime -= Time.deltaTime;
	}
}