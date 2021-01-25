using Sirenix.OdinInspector;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class OnEmptyPlaceClicked : MonoBehaviour
{
	[ReadOnly] [SerializeField] Camera mainCamera;
	[SerializeField] LayerMask ignoreLayers;

	[SerializeField] UnityEvent onEmptyPlaceClick;

	private void Awake()
	{
		mainCamera = Camera.main;
	}

	private void Update()
	{
		TakeInput();
	}

	private void TakeInput()
	{
		if(Input.GetMouseButtonDown(0))
		{
			CheckMousePos();
		}
	}

	public void CheckMousePos()
	{
		if (!gameObject.activeSelf) return;
		bool v = EventSystem.current.IsPointerOverGameObject();
		if (v) return;
		var mousePos = Input.mousePosition; //Mouse.current.position.ReadValue();

		var ray = mainCamera.ScreenPointToRay(mousePos);
		var hit = Physics2D.Raycast(ray.origin, ray.direction, 100, ignoreLayers);
		if (!hit)
			CallEvent();
	}

	public void CheckMousePos(CallbackContext callbackContext)
	{
		if (!callbackContext.performed) return;
		if (!gameObject.activeSelf) return;
		bool v = EventSystem.current.IsPointerOverGameObject();
		if (v) return;
		var mousePos = Mouse.current.position.ReadValue();

		var ray = mainCamera.ScreenPointToRay(mousePos);
		var hit = Physics2D.Raycast(ray.origin, ray.direction, 100, ignoreLayers);
		if (!hit)
			CallEvent();
	}

	private void CallEvent()
	{
		onEmptyPlaceClick.Invoke();
	}
}
