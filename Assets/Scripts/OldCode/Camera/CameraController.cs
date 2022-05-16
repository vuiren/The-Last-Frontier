using UnityEngine;

public class CameraController : MonoBehaviour
{
	#region Serialized Private Fields
	[SerializeField] Camera mainCamera;
	[SerializeField] float moveSpeed = 1f;
	#endregion
	Vector2 inputVector;

	private void Update()
	{
		CameraMovement();
		InputTake();
	}

	private void InputTake()
	{
		var horizontal = Input.GetAxis("Horizontal");
		var vertical = Input.GetAxis("Vertical");

		inputVector = new Vector2(horizontal, vertical);
	}

	private void CameraMovement()
	{
		var horizontal = Vector2.right * inputVector.x;
		var vertical = Vector2.up * inputVector.y;
		var movingDirectionVector = horizontal + vertical;
		Vector2 moveVector = movingDirectionVector * moveSpeed * Time.unscaledDeltaTime;
		transform.Translate(moveVector);
	}



	public void TakeInput()
	{
      /*  if(callbackContext.performed)
		{
            inputVector = callbackContext.ReadValue<Vector2>();
		}
        if (callbackContext.canceled)
            inputVector = new Vector2();*/
	}
}
