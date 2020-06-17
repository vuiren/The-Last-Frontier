using UnityEngine;

public class OnCommandReceive : MonoBehaviour, ICommandReceiver
{
    [SerializeField]
    CommandUnityEvent onGoToCommand;

    [SerializeField]
    CommandUnityEvent onBuildCommand;

    public void ReceiveCommand(Command command)
    {
        var commandType = command.commandType;
        switch(commandType)
        {
            case CommandsEnum.GoTo:
                onGoToCommand.Invoke(command);
                break;
            case CommandsEnum.Build:
                onBuildCommand.Invoke(command);
                break;
        }
    }
}
