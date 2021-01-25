public class AllyHealthController : HealthCrontroller
{
    ChangePlayerResources changePlayerResources;

    protected override void AddComponents()
    {
        base.AddComponents();
        changePlayerResources = gameObject.AddComponent<ChangePlayerResources>();
    }

    protected override void SubscribeToEvents()
    {
        base.SubscribeToEvents();
        onPreDeath += () => changePlayerResources.StopUsingPlayerResources(NPCInfoHolder);
    }
}
