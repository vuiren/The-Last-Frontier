using UnityEngine;

public class CameraZooming : MonoBehaviour
{
	[SerializeField] Camera mainCamera;
	[Header("Zoom Setting")]
	[SerializeField] float minSize;
	[SerializeField] float maxSize;
	[SerializeField] float zoomChangeSpeed = 1f;
	[SerializeField] [Range(0, 10)] float zoomSpeed = 3f;

	float targetOrthographicSize;
	bool zoomActive;

	private void Start()
	{
		targetOrthographicSize = mainCamera.orthographicSize;
		zoomActive = true;
	}

	private void Update()
	{
		if (!zoomActive) return;
		SmoothZoom();
		TakeInput();
	}

	private void TakeInput()
	{
		if (!zoomActive) return;
		if (!enabled) return;
		var mouseScroll = Input.mouseScrollDelta; //callbackContext.ReadValue<Vector2>();
		targetOrthographicSize += -mouseScroll.y * Time.deltaTime * zoomChangeSpeed;
		targetOrthographicSize = Mathf.Clamp(targetOrthographicSize, minSize, maxSize);
	}

	private void SmoothZoom()
	{
		mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, targetOrthographicSize, zoomSpeed * Time.unscaledDeltaTime);
	}

	/*public void ChangeOrthographicSizeInput(CallbackContext callbackContext)
	{
		if (!zoomActive) return;
		if (!enabled) return;
		var mouseScroll = callbackContext.ReadValue<Vector2>();
		targetOrthographicSize += -mouseScroll.y * Time.deltaTime * 0.03f;
		targetOrthographicSize = Mathf.Clamp(targetOrthographicSize, minSize, maxSize);
	}*/
}
