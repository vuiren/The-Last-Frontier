using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class SelectAlliesInCircle : MonoBehaviour
{
	#region Constants
	private const float InputSelectionRadiusModifier = 1f;
	private readonly CommandsEnum[] commands = new[] { CommandsEnum.GoTo, CommandsEnum.Attack };
	#endregion

	#region Serialized Private Fields
	[SerializeField] 
	LayerMask alliesLayer;

	[SerializeField]
	float minRadius = 0.12f;

	[SerializeField]
	float maxRadius = 0.5f;

	[SerializeField]
	[Range(0,100)]
	float radiusChangeSpeed = 3f;

	[SerializeField]
	[Range(1, 100)]
	float selectionRadiusChangeSpeed = 1.5f;

	[SerializeField]
	CommandsEnum commandType;

	[SerializeField] 
	GameObject selectionCursor;

	[ReadOnly]
	[SerializeField]
	Vector3 targetSelectionCursorScale = new Vector3(1, 1, 1);

	[ReadOnly]
	[SerializeField]
	float selectionRadius;

	[ReadOnly]
	[SerializeField] 
	List<GameObject> allies = new List<GameObject>();
	#endregion

	#region Private Fields
	Camera mainCamera;
	int commandIndex;
	#endregion

	#region MonoBehaviour CallBacks
	private void Start()
	{
		mainCamera = Camera.main;
		selectionRadius = minRadius;
	}

	private void Update()
	{
		SmoothCursorScale();
		TakeInput();
	}

	private void TakeInput()
	{
		if(Input.GetMouseButtonDown(0))
		{
			SelectAlliesInput();
		}

		if(Input.GetMouseButtonDown(1))
		{
			SendCommandInput();
		}

		ChangeSelectionRadius();
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.DrawWireSphere(transform.position, selectionRadius);
	}
	#endregion

	#region Public Methods

	#region Input
	public void SelectAlliesInput(CallbackContext callbackContext)
	{
		if (!callbackContext.performed) return;
		if (!gameObject.activeSelf) return;
		if (EventSystem.current.IsPointerOverGameObject()) return;
		DeselectSelectedAllies();
		FindAndSelectAllies();
	}

	public void SelectAlliesInput()
	{
		if (!gameObject.activeSelf) return;
		if (EventSystem.current.IsPointerOverGameObject()) return;
		DeselectSelectedAllies();
		FindAndSelectAllies();
	}

	public void SendCommandInput()
	{
		Vector3 screenMousePos = GetMousePositionOnScreen();
		SendCommandToAllies(screenMousePos);
	}

	public void SendCommandInput(CallbackContext callbackContext)
	{
		if (!callbackContext.performed) return;
		Vector3 screenMousePos = GetMousePositionOnScreen();
		SendCommandToAllies(screenMousePos);
	}

	public void ChangeSelectionRadius()
	{
		if (!gameObject.activeSelf) return;
		//if (!callbackContext.performed) return;
		var mouseScroll = Input.mouseScrollDelta; //callbackContext.ReadValue<Vector2>();
		SetSelectionRadius(mouseScroll);
		ScaleSelectionCursor();
	}


	public void ChangeSelectionRadius(CallbackContext callbackContext)
	{
		if (!gameObject.activeSelf) return;
		if (!callbackContext.performed) return;
		var mouseScroll = callbackContext.ReadValue<Vector2>();
		SetSelectionRadius(mouseScroll);
		ScaleSelectionCursor();
	}

	public void SetNextCommandInput(CallbackContext callbackContext)
	{
		if (!gameObject.activeSelf) return;
		if (!callbackContext.performed) return;

		commandIndex++;
		if (commandIndex >= commands.Length) commandIndex = 0;
		commandType = commands[commandIndex];
	}
	#endregion

	public void SetAttackCommand()
	{
		if (!gameObject.activeSelf) return;

		commandType = CommandsEnum.Attack;
	}

	public void SetGoToCommand()
	{
		if (!gameObject.activeSelf) return;

		commandType = CommandsEnum.GoTo;
	}

	public void DeselectSelectedAlliesFromGUI()
	{
		DeselectSelectedAllies();
	}
	#endregion

	#region Private Methods
	private void SendCommandToAllies(Vector3 screenMousePos)
	{
		foreach (var e in allies)
		{
			if (!e) continue;
			var commandReciever = e.GetComponentInChildren<ICommandReceiver>();
			if (commandReciever == null) continue;
			commandReciever.SendCommand(new Command(commandType, screenMousePos));
		}
	}

	private Vector3 GetMousePositionOnScreen()
	{
		var mousePos = Input.mousePosition; //Mouse.current.position.ReadValue();
		var screenMousePos = mainCamera.ScreenToWorldPoint(mousePos);
		screenMousePos.z = 0;
		return screenMousePos;
	}

	private void DeselectSelectedAllies()
	{
		foreach (var e in allies)
		{
			if (!e) continue;
			var choosable = e.GetComponentInChildren<IChoosable>();
			choosable.Unchoose();
		}
		allies = new List<GameObject>();
	}

	private void SetSelectionRadius(Vector2 mouseScroll)
	{
		selectionRadius += -mouseScroll.y * Time.deltaTime * InputSelectionRadiusModifier * selectionRadiusChangeSpeed;
		selectionRadius = Mathf.Clamp(selectionRadius, minRadius, maxRadius);
	}

	private void ScaleSelectionCursor()
	{
		var scale = selectionRadius / minRadius;
		targetSelectionCursorScale = new Vector3(scale, scale, 1);
	}

	private void FindAndSelectAllies()
	{
		var hits = Physics2D.OverlapCircleAll(transform.position, selectionRadius, alliesLayer);
		for (int i = 0; i < hits.Length; i++)
		{
			Collider2D e = hits[i];
			var choosable = e.transform.parent.GetComponentInChildren<IChoosable>();
			if (choosable == null) continue;
			if (i != hits.Length - 1)
				choosable.Choose();
			else
				choosable.ChooseLast();
			allies.Add(e.transform.parent.gameObject);
		}
	}

	private void SmoothCursorScale()
	{
		Transform selectionTransform = selectionCursor.transform;
		Vector3 lerpedVector = 
			Vector3.Lerp(selectionTransform.localScale, targetSelectionCursorScale, radiusChangeSpeed * Time.deltaTime);
		selectionTransform.localScale = lerpedVector;
	}
	#endregion
}