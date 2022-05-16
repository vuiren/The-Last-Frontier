﻿using UnityEngine;

public class MoveOutOfCharacter : MonoBehaviour, INPCInfoReader
{
	[SerializeField] 
	NPCInfoHolder npcInfoHolder;

	NPCInfo allyInfo;
	Rigidbody2D rb;
	[SerializeField]  GameObject ally;

	[SerializeField] Vector2 moveOutMovingDirection = new Vector2(1,0);
	public bool MovingOut { get; set; }
	public Rigidbody2D GetRigidbody() => rb;

	private void Start()
	{
		allyInfo = npcInfoHolder.NPCInfo;
		rb = npcInfoHolder.RigidBody;
	}

	public void SetNPCInfoHandler(NPCInfoHolder NPCInfoHolder)
	{
		this.npcInfoHolder = NPCInfoHolder;
	}
}
