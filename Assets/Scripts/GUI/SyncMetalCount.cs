using UnityEngine;
using UnityEngine.UI;

public class SyncMetalCount : MonoBehaviour
{
	[SerializeField]
	Text text;

	string startText;

	private void Awake()
	{
		//startText = text.text;
		GlobalDataTransfer.OnMetalCountChanged += UpdateMetalCount;
		UpdateMetalCount(GlobalDataTransfer.MetalCount);
	}

	private void UpdateMetalCount(int obj)
	{
		text.text = startText + " " + obj.ToString();
	}
}
