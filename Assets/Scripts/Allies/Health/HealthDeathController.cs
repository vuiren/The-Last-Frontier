public class HealthDeathController : HealthComponent
{
	internal override void SubscribeToEvents()
	{
		base.SubscribeToEvents();
		eventsProxy.OnDeath += Die;
	}

	private void Die()
	{
		gameObject.SetActive(false);
	}
}
