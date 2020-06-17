using UnityEngine;

public class ChangeCommandType : MonoBehaviour
{
	[SerializeField]
	CommandsEnum commandTypeToSet;

	public void DoChangeCommandType()
	{
		var instance = GameInfoSingleton.Instance;
		instance.OnCommandTypeChange?.Invoke(commandTypeToSet);
	}
}
