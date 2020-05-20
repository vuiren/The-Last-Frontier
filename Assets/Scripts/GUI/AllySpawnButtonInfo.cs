using UnityEngine;
using UnityEngine.UI;

public class AllySpawnButtonInfo : MonoBehaviour
{
	[SerializeField]
	Image allyImage;

	[SerializeField]
	Text allyName;

	[SerializeField]
	Text allyFoodCost;

	[SerializeField]
	Text allyMetalCost;

	[SerializeField]
	public AllyInfo allyInfo;

	public void SetupButton(AllyInfo allyInfo)
	{
		this.allyInfo = allyInfo;
		allyImage.sprite = allyInfo.AllyImage;
		allyName.text = allyInfo.AllyName;
		allyFoodCost.text = allyInfo.AllyCost.FoodCost.ToString();
		allyMetalCost.text = allyInfo.AllyCost.MetalCost.ToString();
	}
}
