using UnityEngine;

public class FollowCursor : MonoBehaviour
{
	//[SerializeField]
	Camera mainCamera;

	#region Serialized Private Fields
	[SerializeField]
	GameObject cursor;

	[SerializeField]
	bool horizontally;

	[SerializeField]
	bool vertically;
	#endregion

	#region MonoBehaviours Callbacks
	void Start()
	{
		mainCamera = Camera.main;
	}

	void Update()
	{
		Vector3 screenMousePos = GetScreenMousePosition();
		UpdateCursorPosition(screenMousePos);
	}

	#endregion

	#region Private Methods
	private void UpdateCursorPosition(Vector3 screenMousePos)
	{
		var cursorPosition = cursor.transform.position;
		var x = horizontally ? screenMousePos.x : cursorPosition.x;
		var y = vertically ? screenMousePos.y : cursorPosition.y;
		var newCursorPosition = new Vector3(x, y, screenMousePos.z);
		cursor.transform.position = newCursorPosition;
	}

	private Vector3 GetScreenMousePosition()
	{
		var mousePos = Input.mousePosition; //Mouse.current.position.ReadValue();
		var screenMousePos = mainCamera.ScreenToWorldPoint(mousePos);
		screenMousePos.z = 0;
		return screenMousePos;
	}
	#endregion
}