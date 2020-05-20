using UnityEngine;

public class ChangeCommandType : MonoBehaviour
{
	[SerializeField]
	CommandsEnum commandTypeToSet;

	public void DoChangeCommandType()
	{
		GlobalDataTransfer.OnCommandTypeChange?.Invoke(commandTypeToSet);
	}
}
