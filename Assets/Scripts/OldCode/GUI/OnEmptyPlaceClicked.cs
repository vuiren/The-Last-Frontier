using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class OnEmptyPlaceClicked : MonoBehaviour
{ 
	[SerializeField] Camera mainCamera;
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

/*	public void CheckMousePos()
	{
		if (!gameObject.activeSelf) return;
		bool v = EventSystem.current.IsPointerOverGameObject();
		if (v) return;
		var mousePos = Mouse.current.position.ReadValue();

		var ray = mainCamera.ScreenPointToRay(mousePos);
		var hit = Physics2D.Raycast(ray.origin, ray.direction, 100, ignoreLayers);
		if (!hit)
			CallEvent();
	}*/

	private void CallEvent()
	{
		onEmptyPlaceClick.Invoke();
	}
}
