using System;

public class GUIManager : Singleton<GUIManager>
{
	public Action OnGUIUpdate { get; set; }
	public UIModesEnum GUIMode { get; set; }
}
