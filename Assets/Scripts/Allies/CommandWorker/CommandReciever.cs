public class CommandReciever : CommandWorkerComponent
{	
	public void ExecuteCommand(Command command)
	{
		switch(command.commandType)
		{
			case CommandsEnum.GoTo:
				eventsProxy.OnGoToCommand?.Invoke(command);
				break;
			case CommandsEnum.Build:
				eventsProxy.OnBuildCommand?.Invoke(command);
				break;
			/*case CommandsEnum.Idle:
				eventsProxy.OnCommandEnd?.Invoke();
				break;*/
		}
	}
}
