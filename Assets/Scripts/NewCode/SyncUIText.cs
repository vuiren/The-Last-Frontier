using UnityEngine;
using UnityEngine.UI;

public class SyncUIText : MonoBehaviour
{
	[SerializeField]
	Text textToSync;

	public void DoSyncText(int intText)
	{
		textToSync.text = intText.ToString();
	}
}
