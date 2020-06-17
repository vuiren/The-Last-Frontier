using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllySpawnUISetup : MonoBehaviour
{
	[SerializeField]
	List<AllyInfo> alliesInfos = new List<AllyInfo>();

	[SerializeField]
	Transform buttonsParent;

	[SerializeField]
	ChangeUIMode changeUIMode;

	private void Awake()
	{
		for (int i = 0; i < alliesInfos.Count; i++)
		{
			var info = alliesInfos[i];
			var child = buttonsParent.GetChild(i);
			child.gameObject.SetActive(true);
			var buttonInfo = child.GetComponent<AllySpawnButtonInfo>();
			buttonInfo.SetupButton(info);
			Button button = child.GetComponent<Button>();
			button.onClick.AddListener(() => DoChangeBuilding(info));
			button.onClick.AddListener(changeUIMode.DoChangeUIMode);
		}
	}

	private void DoChangeBuilding(AllyInfo allyInfo)
	{
		var instance = GameInfoSingleton.Instance;
		if (instance.ActiveCasarm == null) return;
		instance.ActiveCasarm.Spawn(allyInfo);
	}
}
