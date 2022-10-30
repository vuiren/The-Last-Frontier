using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildUISetup : MonoBehaviour
{
	[SerializeField]
	List<BuildingCreatingInfo> buildingsInfos = new List<BuildingCreatingInfo>();

	[SerializeField]
	Transform buttonsParent;

	[SerializeField]
	ChangeUIMode changeUIMode;

	private void Awake()
	{
		SetupButtions();
	}

	private void SetupButtions()
	{
		for (int i = 0; i < buildingsInfos.Count; i++)
		{
			var info = buildingsInfos[i];
			var child = buttonsParent.GetChild(i);
			child.gameObject.SetActive(true);
			var buttonInfo = child.GetComponent<SpawnButtonInfo>();
			buttonInfo.SetupButton(info);
			Button button = child.GetComponent<Button>();
			button.onClick.AddListener(() => DoChangeBuilding(info));
			button.onClick.AddListener(changeUIMode.DoChangeUIMode);
		}
	}

	private void DoChangeBuilding(BuildingCreatingInfo creatingInfo)
	{
		/*var instance = GameManager.Instance;
		instance.onBuildingCreation?.Invoke(creatingInfo);*/
	}
}
