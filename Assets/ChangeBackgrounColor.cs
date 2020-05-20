using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackgrounColor : MonoBehaviour
{
	[SerializeField]
	Camera mainCamera;
	[SerializeField]
	Color colorToSet;

	public void DoIt()
	{
		mainCamera.backgroundColor = colorToSet;
	}
}
