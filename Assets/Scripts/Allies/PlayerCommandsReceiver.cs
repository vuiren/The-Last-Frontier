public class PlayerCommandsReceiver : AllyComponent
{
    protected override void SubscribeToEventsProxy()
    {
    }

    public void SetCommand(Command command)
    {
    //    eventsProxy.OnPlayerCommandSet?.Invoke(command);
    }

    internal override void SubscribeToEvents()
    {
        throw new System.NotImplementedException();
    }

    internal override void EnableComponent()
    {
        throw new System.NotImplementedException();
    }

    internal override void DisableComponent()
    {
        throw new System.NotImplementedException();
    }
}
