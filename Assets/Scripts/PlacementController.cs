using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementController : MonoBehaviour
{
	[SerializeField]
	GameObject buildingPrefab;

	[SerializeField]
	GameObject buildingExamplePrefab;

	[SerializeField]
	bool active;

	GameObject buidlingExampleInstance;
	Camera mainCamera;

	private void Awake()
	{
		mainCamera = Camera.main;
		buidlingExampleInstance = Instantiate(buildingExamplePrefab);
		buidlingExampleInstance.SetActive(false);
	}

	private void Update()
	{
		if(!active)
		{
			StopShowingExample();
			return;
		}

		ShowPrefabExample();
		MovePrefabExample();
	}

	private void MovePrefabExample()
	{
		var pos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
		pos.z = 0; pos.y = 0;
		buidlingExampleInstance.transform.position = pos;
	}

	private void ShowPrefabExample()
	{
		buidlingExampleInstance.SetActive(true);
	}

	private void StopShowingExample()
	{
		buidlingExampleInstance.SetActive(false);
	}
}
