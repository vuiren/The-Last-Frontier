using UnityEngine;
using UnityEngine.UI;

public class SyncMetalCountUI : MonoBehaviour
{
	[SerializeField]
	Text text;

	string startText;

	public void UpdateMetalCount(GameResources gameResources)
	{
		text.text = startText + " " + gameResources.MetalCount.ToString();
	}
}
