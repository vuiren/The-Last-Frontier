using UnityEngine;

public class MoveGameobject : MonoBehaviour
{
	[SerializeField]
	Transform objectToMove;

	[SerializeField]
	Vector2 moveOffset;

	public void DoMoveGameObject()
	{
		//if (!callbackContext.performed) return;
	//	if (!gameObject.activeSelf) return;
	//	var mouseScroll = //callbackContext.ReadValue<Vector2>();
		//var sign = Mathf.Sign(mouseScroll.y);
		//objectToMove.Translate(sign < 0 ? moveOffset : -moveOffset);
	}
}
