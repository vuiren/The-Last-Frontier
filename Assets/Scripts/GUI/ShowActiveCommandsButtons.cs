using System.Collections.Generic;
using UnityEngine;

public class ShowActiveCommandsButtons : MonoBehaviour
{
	[SerializeField]
	GameObject GoToButton;

	[SerializeField]
	GameObject BuildButton;

	private void Awake()
	{
		GlobalDataTransfer.OnSquadListChanger += ShowButtons;
	}

	public void ShowButtons(List<Transform> squad)
	{
		HideAllButtons();
		var availableCommands = GetAvailableCommands(squad);
		foreach(var command in availableCommands)
		{
			switch(command)
			{
				case CommandsEnum.GoTo:
					GoToButton.SetActive(true);
					break;
				case CommandsEnum.Build:
					BuildButton.SetActive(true);
					break;
			}
		}
	}

	private void HideAllButtons()
	{
		GoToButton.SetActive(false);
		BuildButton.SetActive(false);
	}

	private List<CommandsEnum> GetAvailableCommands(List<Transform> squad)
	{
		var result = new List<CommandsEnum>();
		foreach (var e in squad)
		{
			var comms = e.GetComponent<AllyInfoHolder>().allyInfo.AvailableCommand;
			if (comms.Count > result.Count)
			{
				result = comms;
			}
		}
		return result;
	}
}
