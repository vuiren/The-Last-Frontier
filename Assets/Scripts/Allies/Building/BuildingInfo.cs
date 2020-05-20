using System;
using UnityEngine;

namespace Building
{
	[Serializable]
	[CreateAssetMenu(fileName = "New Building Info", menuName = "BuildingInfo", order = 52)]
	public class BuildingInfo:ScriptableObject
	{
		public string BuildingName;
		public Sprite BuildingSprite;
		public GameObject BuildingInstancePrefab;
		public GameObject BuildingInstanceExamplePrefab;
		public Cost BuildingCost;
	}
}