using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.InputSystem.InputAction;

public class PlacementController : MonoBehaviour
{
	#region Serialized Private Fields
	[SerializeField] List<CreatingInfo> buildings;

	[SerializeField] SpriteRenderer buildingPreview;

	[SerializeField] LayerMask intersectsLayers;
	[SerializeField] Vector3 boundStartOffset;
	[SerializeField] Vector3 boundsOffSet;
	[SerializeField] bool prohibitBuildingOnCurvePosition;
	[SerializeField] bool automaticlyMoveBoundToSpriteCenter = true;

	[ReadOnly] [SerializeField] CreatingInfo building;
	[SerializeField] BoolUnityEvent onCanBuildChanged;
	[SerializeField] GameResourcesUnityEvent onBuildingChanged;
	#endregion

	int buildingIndex;
	Vector3 automatedStartOffset;
	#region MonoBehaviours Callbacks
	private void Start()
	{
		if (automaticlyMoveBoundToSpriteCenter)
			CalculateAutomaticOffSet();
		ShowBuilding();
	}

	private void Update()
	{
		ColorBuilding();
		TakeInput();
	}

	private void TakeInput()
	{
		if (Input.GetMouseButtonDown(1))
			SetNextBuilding();

		if (Input.GetMouseButtonDown(0))
			PlaceBuilingInput();
	}

	private void OnDrawGizmosSelected()
	{
		if (buildingPreview == null || buildingPreview.sprite == null) return;
		var bounds = buildingPreview.sprite.bounds;
		if(automaticlyMoveBoundToSpriteCenter)
		{
			CalculateAutomaticOffSet();
		}
		var startOffset = boundStartOffset + automatedStartOffset;
		Gizmos.DrawWireCube(transform.position + startOffset, bounds.size + boundsOffSet);
	}
	#endregion

	#region Private Methods
	private void CalculateAutomaticOffSet()
	{
		var bounds = buildingPreview.sprite.bounds;
		automatedStartOffset = new Vector3(0, bounds.extents.y, 0);
	}

	private void ColorBuilding()
	{
		var canBuild = CanBuild();
		buildingPreview.color = canBuild ? Color.green : Color.red;
		onCanBuildChanged.Invoke(canBuild);
	}

	private bool CanBuild()
	{
		var intersects = IsBuildingIntersects();
		var playerGotEnoughResources = IsPlayerGotEnoughResources();
		var buildingAllowedToBuildOnCurvedPosition = IsBuildingStandingOnFlatGround();
		return !intersects && playerGotEnoughResources && buildingAllowedToBuildOnCurvedPosition;
	}

	private bool IsBuildingStandingOnFlatGround()
	{
		var deltaConstant = 1f;
		var buildingRotationZ = transform.rotation.z;
		return buildingRotationZ >= -deltaConstant && buildingRotationZ <= deltaConstant;
	}

	private bool IsPlayerGotEnoughResources()
	{
		var instance = PlayerResources.Instance;
		var playerResources = instance.AvailableResources;
		var buildingCost = building.CreationCost;
		return playerResources.FoodCount >= buildingCost.FoodCount && playerResources.MetalCount >= buildingCost.MetalCount;
	}

	private bool IsBuildingIntersects()
	{
		var bounds = buildingPreview.sprite.bounds;
		var startOffset = boundStartOffset + automatedStartOffset;
		var hit = Physics2D.OverlapBox(transform.position + startOffset, bounds.size + boundsOffSet, 0, intersectsLayers);
		return hit;
	}

	private void ShowBuilding()
	{
		building = buildings[buildingIndex];
		buildingPreview.sprite = building.CreationImage;
		onBuildingChanged.Invoke(building.CreationCost);
	}

	private void UpdateBuildingIndex(float yDelta)
	{
		buildingIndex += (int)Mathf.Sign(yDelta);
		buildingIndex = buildingIndex > buildings.Count - 1 ? 0 : buildingIndex;
		buildingIndex = buildingIndex < 0 ? buildings.Count - 1 : buildingIndex;
	}

	private void SetNextBuildingIndex()
	{
		UpdateBuildingIndex(1);
	}

	private void SetPreviousBuildingIndex()
	{
		UpdateBuildingIndex(-1);
	}
	#endregion

	#region Public Methods
	public void PlaceBuilingInput(CallbackContext callbackContext)
	{
		if (!callbackContext.performed) return;
		if (!gameObject.activeSelf) return;
		var pointerOverUI = EventSystem.current.IsPointerOverGameObject();
		if (pointerOverUI) return;
		var canBuild = CanBuild();
		if (!canBuild) return;
		Instantiate(building.CreationPrefab, buildingPreview.transform.position, buildingPreview.transform.rotation);
		PayResourcesForCreation(building);
	}

	public void PlaceBuilingInput()
	{
		if (!gameObject.activeSelf) return;
		var pointerOverUI = EventSystem.current.IsPointerOverGameObject();
		if (pointerOverUI) return;
		var canBuild = CanBuild();
		if (!canBuild) return;
		Instantiate(building.CreationPrefab, buildingPreview.transform.position, buildingPreview.transform.rotation);
		PayResourcesForCreation(building);
	}

	private void PayResourcesForCreation(CreatingInfo building)
	{
		var instance = PlayerResources.Instance;
		instance.AddResources(-building.CreationCost.MetalCount, -building.CreationCost.FoodCount);
	}

	public void ChangeIndexInput()
	{
		if (!gameObject.activeSelf) return;
		var yDelta = Input.mouseScrollDelta.y; //callBackContext.ReadValue<Vector2>().y;
		UpdateBuildingIndex(yDelta);
		ShowBuilding();
		if (automaticlyMoveBoundToSpriteCenter)
			CalculateAutomaticOffSet();
	}

	public void SetNextBuilding()
	{
		if (!gameObject.activeSelf) return;
		SetNextBuildingIndex();
		ShowBuilding();
		if (automaticlyMoveBoundToSpriteCenter)
			CalculateAutomaticOffSet();
	}

	public void RotateBuildingInput(CallbackContext callbackContext)
	{
		if (!callbackContext.performed) return;
		if (!gameObject.activeSelf) return;
		if (!buildingPreview) return;
		buildingPreview.transform.Rotate(0, 180, 0);
	}

	public void ChangeIndexInput(CallbackContext callBackContext)
	{
		if (!gameObject.activeSelf) return;
		if (!callBackContext.performed) return;
		var yDelta = callBackContext.ReadValue<Vector2>().y;
		UpdateBuildingIndex(yDelta);
		ShowBuilding();
		if (automaticlyMoveBoundToSpriteCenter)
			CalculateAutomaticOffSet();
	}

	public void SetNextBuilding(CallbackContext callbackContext)
	{
		if (!gameObject.activeSelf) return;
		if (!callbackContext.performed) return;
		SetNextBuildingIndex();
		ShowBuilding();
		if (automaticlyMoveBoundToSpriteCenter)
			CalculateAutomaticOffSet();
	}

	public void SetPreviousBuilding(CallbackContext callbackContext)
	{
		if (!gameObject.activeSelf) return;
		if (!callbackContext.performed) return;
		SetPreviousBuildingIndex();
		ShowBuilding();
		if (automaticlyMoveBoundToSpriteCenter)
			CalculateAutomaticOffSet();
	}
	#endregion
}