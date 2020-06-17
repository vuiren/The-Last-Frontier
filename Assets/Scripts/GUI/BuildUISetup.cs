using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildUISetup : MonoBehaviour
{
	[SerializeField]
	List<Building.BuildingInfo> buildingInfos = new List<Building.BuildingInfo>();

	[SerializeField]
	ChangeUIMode changeUIMode;

	[SerializeField]
	Transform buttonsParent;

	private void Awake()
	{
		for (int i = 0; i < buildingInfos.Count; i++)
		{
			var info = buildingInfos[i];
			var child = buttonsParent.GetChild(i);
			child.gameObject.SetActive(true);
			var buttonInfo = child.GetComponent<BuildButtonInfo>();
			buttonInfo.SetupButton(info);
			Button button = child.GetComponent<Button>();
			button.onClick.AddListener(() => DoChangeBuilding(info));
			button.onClick.AddListener(changeUIMode.DoChangeUIMode);
		}
	}

	private void DoChangeBuilding(Building.BuildingInfo buildingInfo)
	{
		var instance = GameInfoSingleton.Instance;
		instance.OnBuildingInfoChange?.Invoke(buildingInfo);
	}
}