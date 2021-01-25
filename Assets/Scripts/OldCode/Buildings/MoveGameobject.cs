using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class MoveGameobject : MonoBehaviour
{
	[SerializeField]
	Transform objectToMove;

	[SerializeField]
	Vector2 moveOffset;

	public void DoMoveGameObject(CallbackContext callbackContext)
	{
		if (!callbackContext.performed) return;
		if (!gameObject.activeSelf) return;
		var mouseScroll = callbackContext.ReadValue<Vector2>();
		var sign = Mathf.Sign(mouseScroll.y);
		objectToMove.Translate(sign < 0 ? moveOffset : -moveOffset);
	}
}
