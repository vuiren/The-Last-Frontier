using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : Singleton<GUIManager>
{
	public Action OnGUIUpdate { get; set; }
	public UIModesEnum GUIMode { get; set; }
}
