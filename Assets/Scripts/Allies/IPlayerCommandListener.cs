public interface IPlayerCommandListener
{
	void SubscribeToCommandListener();
	void StartCommandExecution(Command command);
	void EndCommandExecution(Command command);
}
