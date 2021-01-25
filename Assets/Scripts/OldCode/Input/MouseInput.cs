﻿using UnityEngine;
using UnityEngine.Events;

public class MouseInput : MonoBehaviour
{
    [SerializeField]
    UnityEvent onLMBDown;

    [SerializeField]
    UnityEvent onRMBDown;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
		{
            onLMBDown.Invoke();
		}

        if(Input.GetMouseButtonDown(1))
		{
            onRMBDown.Invoke();
		}
    }
}
