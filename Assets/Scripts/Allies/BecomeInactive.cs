public class BecomeInactive : WarriorComponent
{
	protected override void SubscribeToEventsProxy()
	{
		eventsProxy.OnDeath += DoBecameInactive;
	}

	internal override void DisableComponent()
	{
		throw new System.NotImplementedException();
	}

	internal override void EnableComponent()
	{
		throw new System.NotImplementedException();
	}

	private void DoBecameInactive()
	{
		gameObject.SetActive(false);
	}
}
