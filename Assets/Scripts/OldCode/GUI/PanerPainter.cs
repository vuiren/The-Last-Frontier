using UnityEngine;
using UnityEngine.UI;

public class PanerPainter : MonoBehaviour
{
	[SerializeField] Image panelImage;
	[SerializeField] Color canBuildColor;
	[SerializeField] Color cantBuildColor;

	public void UpdatePanel(bool canBuild)
	{
		panelImage.color = canBuild ? canBuildColor : cantBuildColor;
	}
}
