using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class SpawnButtonInfo : MonoBehaviour
{
	[SerializeField]
	Image allyImage;

	[SerializeField]
	Text allyName;

	[SerializeField]
	Text allyFoodCost;

	[SerializeField]
	Text allyMetalCost;

	[ReadOnly]
	[SerializeField]
	public CreatingInfo allyInfo;

	public void SetupButton(CreatingInfo allyInfo)
	{
		this.allyInfo = allyInfo;
		allyImage.sprite = allyInfo.CreationImage;
		allyName.text = allyInfo.CreationName;
		allyFoodCost.text = allyInfo.CreationCost.FoodCount.ToString();
		allyMetalCost.text = allyInfo.CreationCost.MetalCount.ToString();
	}
}
