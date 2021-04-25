using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class OnClick : MonoBehaviour
{
	[SerializeField] UnityEvent onClick;
	[SerializeField] UnityEvent onClickOutside;
	[SerializeField] Collider2D clickCollider;
	[SerializeField] [ReadOnly] Camera mainCamera;

	private void Start()
	{
		mainCamera = Camera.main;
	}

	public void Click()
	{
		onClick.Invoke();
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
			ClickHandler();
	}

	public void ClickHandler()
	{
		Vector3 screenMousePos = GetMousePosition();
		var bounds = clickCollider.bounds;
		var intersects = bounds.Contains(screenMousePos);
		if (intersects)
		{
			Click();
		}
		else
		{
			onClickOutside.Invoke();
		}
	}

	private Vector3 GetMousePosition()
	{
		var mousePos = Input.mousePosition;//Mouse.current.position.ReadValue();
		var screenMousePos = mainCamera.ScreenToWorldPoint(mousePos);
		screenMousePos.z = 0;
		return screenMousePos;
	}
}