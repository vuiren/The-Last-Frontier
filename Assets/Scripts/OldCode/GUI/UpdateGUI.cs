using UnityEngine;

public class UpdateGUI : MonoBehaviour
{ 
	public void DoUpdateGUI()
	{
		var instance = GUIManager.Instance;
		instance.OnGUIUpdate?.Invoke();
	}
}
