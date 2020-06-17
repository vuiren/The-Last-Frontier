using UnityEngine;

public class MedicHealTarget : MonoBehaviour, ITargetUpdateReceiver
{
	[SerializeField]
	int healCount = 1;

	[SerializeField]
	float timeBetweenHealing = 1f;

	GameObject target;
	float curTime;

	public void UpdateTarget(GameObject obj)
	{
		target = obj;
	}

	private void Update()
	{
		ReloadProcess();
		if (!target) return; 
		if (ReadyToHeal())
			Heal();
	}

	private bool ReadyToHeal()
	{
		return curTime <= 0;
	}

	private void Heal()
	{
		var health = target.GetComponent<IHealable>();
		if (!ShouldHealTarget(health)) return;
		health.Heal(healCount);
		StartHealingReloading();
	}

	private void StartHealingReloading()
	{
		curTime = timeBetweenHealing;
	}

	private bool ShouldHealTarget(IHealable healable)
	{
		return healable != null && healable.HealingRequired();
	}

	private void ReloadProcess()
	{
		curTime -= Time.deltaTime;
	}
}
