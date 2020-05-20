using UnityEngine;
using UnityEngine.EventSystems;

public class ReturnToMainUIWhenNothingClicked : MonoBehaviour
{
	Camera mainCamera;

	private void Awake()
	{
		mainCamera = Camera.main;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
		{
			var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
			var hit = Physics2D.Raycast(ray.origin, ray.direction, 100);
			if (!hit)
				DoChangeUIMode();
		}
	}

	private void DoChangeUIMode()
	{
		GlobalDataTransfer.OnUIModeChange.Invoke(UIModesEnum.MainUI);
	}
}
