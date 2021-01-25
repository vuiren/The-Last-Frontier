using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.InputSystem.InputAction;

public class AllySpawnerController : MonoBehaviour
{
	#region Serialized Private Fields
	[SerializeField] List<CreatingInfo> allies;

	[ReadOnly] [SerializeField] CreatingInfo ally;
	[ReadOnly] [SerializeField] CasarmController casarm;
	[ReadOnly] [SerializeField] int allyIndex;

	[SerializeField] BoolUnityEvent onCanCreateChanged;
	[SerializeField] CreatingInfoUnityEvent onChoosedAllyChanged;
	#endregion

	#region MonoBehaviour Callbacks
	private void Start()
	{
		ShowBuilding();
	}

	private void Update()
	{
		TakeInput();
	}

	private void TakeInput()
	{
		if (Input.GetMouseButtonDown(1))
			SetNextBuilding();
	}
	#endregion

	#region Private Methods
	private void PayResourcesForCreation()
	{
		var cost = ally.CreationCost;
		var instance = PlayerResources.Instance;
		instance.AddResources(-cost.MetalCount, -cost.FoodCount);
	}

	private void CanSpawnCheck()
	{
		var canBuild = CanCreate();
		onCanCreateChanged.Invoke(canBuild);
	}

	private bool CanCreate()
	{
		var playerGotEnoughResources = IsPlayerGotEnoughResources();
		return playerGotEnoughResources;
	}

	private bool IsPlayerGotEnoughResources()
	{
		var instance = PlayerResources.Instance;
		var playerResources = instance.AvailableResources;
		var buildingCost = ally.CreationCost;
		return playerResources.FoodCount >= buildingCost.FoodCount && playerResources.MetalCount >= buildingCost.MetalCount;
	}

	private void UpdateBuildingIndex(float yDelta)
	{
		allyIndex += (int)Mathf.Sign(yDelta);
		allyIndex = allyIndex > allies.Count - 1 ? 0 : allyIndex;
		allyIndex = allyIndex < 0 ? allies.Count - 1 : allyIndex;
	}


	private void SetNextBuildingIndex()
	{
		UpdateBuildingIndex(1);
	}

	private void SetPreviousBuildingIndex()
	{
		UpdateBuildingIndex(-1);
	}

	private void ShowBuilding()
	{
		ally = allies[allyIndex];
		onChoosedAllyChanged?.Invoke(ally);
		CanSpawnCheck();
	}

	#endregion

	#region Public Methods

	public void SpawnAlly()
	{
		if (!gameObject.activeSelf) return;
		var canCreate = CanCreate();
		if (!canCreate) return;
		casarm.SpawnAlly(ally);
		PayResourcesForCreation();
	}

	public void ChangeIndex(CallbackContext callBackContext)
	{
		if (!gameObject.activeSelf) return;
		if (!callBackContext.performed) return;
		var yDelta = callBackContext.ReadValue<Vector2>().y;
		UpdateBuildingIndex(yDelta);
		ShowBuilding();
	}

	public void SetCasarmController(CasarmController casarmController)
	{
		this.casarm = casarmController;
	}

	public void ChangeIndexInput(CallbackContext callBackContext)
	{
		if (!gameObject.activeSelf) return;
		if (!callBackContext.performed) return;
		var yDelta = callBackContext.ReadValue<Vector2>().y;
		UpdateBuildingIndex(yDelta);
		ShowBuilding();
	}

	public void SetNextBuilding(CallbackContext callbackContext)
	{
		if (!gameObject.activeSelf) return;
		if (!callbackContext.performed) return;
		SetNextBuildingIndex();
		ShowBuilding();
	}
	public void SetNextBuilding()
	{
		if (!gameObject.activeSelf) return;
		SetNextBuildingIndex();
		ShowBuilding();
	}

	public void SetPreviousBuilding(CallbackContext callbackContext)
	{
		if (!gameObject.activeSelf) return;
		if (!callbackContext.performed) return;
		SetPreviousBuildingIndex();
		ShowBuilding();
	}
	#endregion
}
