using UnityEngine;
using UnityEngine.UI;

public class CommandButtonActive : MonoBehaviour
{
	[SerializeField]
	CommandsEnum commandType;

	[SerializeField]
	Button button;

	private void Awake()
	{
		var instance = GameInfoSingleton.Instance;
		instance.OnCommandTypeChange += ChooseActivity;
		ChooseActivity(CommandsEnum.GoTo);
	}

	private void ChooseActivity(CommandsEnum obj)
	{
		button.interactable = obj != commandType;
	}
}
