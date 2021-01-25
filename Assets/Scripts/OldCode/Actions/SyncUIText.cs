using UnityEngine;
using UnityEngine.UI;

public class SyncUIText: MonoBehaviour
{
    public void DoSyncText(Text text, int intText)
	{
		text.text = intText.ToString();
	}
}
