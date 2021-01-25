using System;
using UnityEngine;

public class TouchTrainInput : MonoBehaviour
{
	Vector2 firstPressPos;
	Vector2 secondPressPos;
	Vector2 currentSwipe;
	float squareMagnitude;

	private void Update()
	{
		SwapInput();
	}

	private void SwapInput()
	{
		var touches = InputHelper.GetTouches();
		if (touches.Count==0)//Input.touches.Length == 0)
		{
			StopSwiping();
			return;
		}
		Touch t = touches[0];
		switch (t.phase)
		{
			case TouchPhase.Began: StartSwiping(t); break;
			case TouchPhase.Moved: SetIsSwiping(t); break;
			case TouchPhase.Stationary: StopSwiping(); break;
			case TouchPhase.Ended: StopSwiping(); break;
		}
	}

	private void StopSwiping()
	{
	/*	IsSwapping = false;
		IsSwappingLeft = false;
		IsSwappingRight = false;*/
	}

	private void SetIsSwiping(Touch t)
	{
	/*	IsSwapping = true;
		var direction = t.deltaPosition.normalized;
		SwipeSpeed = t.deltaPosition.magnitude * Time.deltaTime * 60f;
	//	syncText.SetText(SwipeSpeed.ToString());
		IsSwappingLeft = direction.x < 0;
		IsSwappingRight = direction.x > 0;*/
	}

	private void StartSwiping(Touch t)
	{
		firstPressPos = new Vector2(t.position.x, t.position.y);
	}
}
