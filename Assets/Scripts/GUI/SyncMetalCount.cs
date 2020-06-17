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
		var instance = GameInfoSingleton.Instance;
		instance.OnMetalCountChanged += UpdateMetalCount;
		UpdateMetalCount(instance.MetalCount);
	}

	private void UpdateMetalCount(int obj)
	{
		text.text = startText + " " + obj.ToString();
	}
}
