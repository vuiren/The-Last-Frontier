using System;
using UnityEngine;

public class DrawRadius : MonoBehaviour
{
	[SerializeField]
	float radius;

	[SerializeField]
	Texture texture;

	private void OnGUI()
	{
		var rect = new Rect(transform.position.x - radius, transform.position.y, radius * 2, 0.05f);
		var guiContent = new GUIContent(texture);
		GUI.Box(rect, guiContent);
	}
}
