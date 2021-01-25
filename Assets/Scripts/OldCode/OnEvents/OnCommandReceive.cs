using UnityEngine;

public class OnCommandReceive : MonoBehaviour, ICommandReceiver
{
    [SerializeField]
    CommandUnityEvent onGoToCommand;

    [SerializeField]
    CommandUnityEvent onAttackCommand;

    [SerializeField]
    CommandUnityEvent onSpeadCommand;

    public void SendCommand(Command command)
    {
        var commandType = command.CommandType;
        switch(commandType)
		{
            case CommandsEnum.Attack:
                onAttackCommand.Invoke(command);
                break;
            case CommandsEnum.GoTo:
                onGoToCommand.Invoke(command);
                break;
            case CommandsEnum.Spread:
                onSpeadCommand.Invoke(command);
                break;
		}
    }
}
