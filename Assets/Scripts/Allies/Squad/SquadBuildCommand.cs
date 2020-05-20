using UnityEngine;
using UnityEngine.EventSystems;
using Building;

public class SquadBuildCommand : SquadComponent
{
	[SerializeField]
	BuildingInfo buildingInfo;

	[SerializeField]
	LayerMask buildingLayer;

	GameObject buildingExampleInstance;
	Camera mainCamera;

	internal override void SubscribeToEvents()
	{
		base.SubscribeToEvents();
		eventsProxy.OnCommandTypeChanged += (CommandsEnum x) => enabled = x == CommandsEnum.Build;
		eventsProxy.OnClearSquad += () => enabled = false;
		GlobalDataTransfer.OnBuildingInfoChange += SetBuildingToBuild;
	}

	private void Start()
	{
		mainCamera = Camera.main;
		SetPrefabExample();
	}

	private void SetPrefabExample()
	{
		if (buildingExampleInstance)
			Destroy(buildingExampleInstance);
		if (buildingInfo == null) return;
		buildingExampleInstance = Instantiate(buildingInfo.BuildingInstanceExamplePrefab);
		buildingExampleInstance.SetActive(false);
	}

	private void Update()
	{
		ShowPrefabExample();
		MovePrefabExample();
		if(Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject())
		{
			TryPlacePrefab();
		}
	}

	private void TryPlacePrefab()
	{
		if (buildingInfo == null || buildingInfo.BuildingCost.MetalCost > GlobalDataTransfer.MetalCount)
		{
			return;
		}
		var box = buildingExampleInstance.GetComponent<Collider2D>().bounds;
		var center = box.center;
		var extents = box.extents;
		var hit = Physics2D.OverlapArea(new Vector2(center.x - extents.x, center.y + extents.y), new Vector2(center.x + extents.x, center.y - extents.y), buildingLayer);
		if (!hit)
		{
			eventsProxy.OnCommandSending?.Invoke(new Command(CommandsEnum.Build, buildingExampleInstance.transform.position, buildingInfo));
			enabled = false;
			eventsProxy.OnCommandTypeChanged?.Invoke(CommandsEnum.GoTo);
		}
	}

	private void MovePrefabExample()
	{
		if (!buildingExampleInstance) return;
		var pos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
		pos.z = 0; pos.y = 0;
		buildingExampleInstance.transform.position = pos;
	}

	private void ShowPrefabExample()
	{
		if (buildingExampleInstance)
			buildingExampleInstance.SetActive(true);
	}

	private void StopShowingExample()
	{
		if (buildingExampleInstance)
			buildingExampleInstance.SetActive(false);
		buildingInfo = null;
	}

	internal override void DisableComponent()
	{
		base.DisableComponent();
		StopShowingExample();
	}

	internal override void EnableComponent()
	{
		base.EnableComponent();
		ShowPrefabExample();
	}

	public void SetBuildingToBuild(BuildingInfo buildingInfo)
	{
		this.buildingInfo = buildingInfo;
		SetPrefabExample();
	}
}
