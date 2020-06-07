using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CameraPhysicsSwipe : MonoBehaviour//BaseController<PlayerConfiguration>
{
    Rigidbody rb;
    bool isSwipingLeft;
    bool isSwipingRight;
    float moveSpeed;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void SetIsSwiping(Touch t)
    {
        var direction = t.deltaPosition.normalized;
        moveSpeed = t.deltaPosition.magnitude * Time.deltaTime;
        isSwipingLeft = direction.x < 0;
        isSwipingRight = direction.x > 0;
    }

    private void Update()
    {
        SwapInput();
        if (isSwipingLeft || isSwipingRight)
            MoveCamera(!isSwipingRight);
    }

    private void SwapInput()
    {
        var touches = InputHelper.GetTouches();
        if (touches.Count == 0)
        {
            StopSwiping();
            return;
        }
        Touch t = touches[0];
        switch (t.phase)
        {
            case TouchPhase.Moved: SetIsSwiping(t); break;
            case TouchPhase.Stationary: StopSwiping(); break;
            case TouchPhase.Ended: StopSwiping(); break;
        }
    }

    private void StopSwiping()
    {
        isSwipingLeft = false;
        isSwipingRight = false;
    }

    private void MoveCamera(bool moveRight)
    {
        var moveVector = moveRight ? new Vector2(moveSpeed, 0) : new Vector2(-moveSpeed, 0);
        rb.AddForce(moveVector, ForceMode.Impulse);
    }
}