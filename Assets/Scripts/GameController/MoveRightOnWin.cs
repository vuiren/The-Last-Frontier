﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveRightOnWin : MonoBehaviour
{
	Rigidbody2D rb;
	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		GlobalDataTransfer.OnGameWinning += Move;
	}

	private void Move()
	{
	}
}