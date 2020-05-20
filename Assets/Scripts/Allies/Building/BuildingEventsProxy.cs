using Building;
using System;
using UnityEngine;

public class BuildingEventsProxy : MonoBehaviour
{
	public Action OnReachingBuildingPlace { get; set; }
	public Action<BuildingInfo> OnBuildingToBuildSet { get; set; }
	public Action<Vector3> OnBuildingPlaceSetting { get; set; }
	public Action EndBuilding { get; set; }
}
