using System;
using UnityEngine;

public class LeftRightMovement : AllyComponent, IPlayerCommandListener
{
	[SerializeField]
	float moveSpeed = 0.2f;

	[SerializeField]
	DirectionsEnum movingDirection;

	[SerializeField]
	Rigidbody2D rb;

	[SerializeField]
	bool moveOnSeingEnemy = false;

	private void ChooseMovingDirection(Vector3 commandVectorValue)
	{
		var dif = transform.position.x - commandVectorValue.x;
		movingDirection = dif < 0 ? DirectionsEnum.East : DirectionsEnum.West;
	}

	public void StartMoving(Transform obj)
	{
		if (obj == null)
		{
			StopMoving(obj);
			return;
		}
		ChooseMovingDirection(obj.position);
		rb.velocity = new Vector2(movingDirection == DirectionsEnum.East ? moveSpeed : -moveSpeed, 0);
	}

	public void StartMoving(Vector3 obj)
	{
		ChooseMovingDirection(obj);
		rb.velocity = new Vector2(movingDirection == DirectionsEnum.East ? moveSpeed : -moveSpeed, 0);
	}

	public void StopMoving(Transform target)
	{
		rb.velocity = new Vector2();
	}

	protected override void SubscribeToEventsProxy()
	{
	/*	eventsProxy.OnEnemyInAttackingRange += StopMoving;
		if (moveOnSeingEnemy)
			eventsProxy.OnNoticingEnemy += StartMoving;*/
		SubscribeToCommandListener();
	}

	public void SubscribeToCommandListener()
	{
	//	eventsProxy.OnPlayerCommandSet += StartCommandExecution;
		//eventsProxy.OnPlayerCommandEnd += EndCommandExecution;
	}

	public void StartCommandExecution(Command command)
	{
		switch (command.commandType)
		{
			case CommandsEnum.GoTo:
				StartMoving(command.commandVectorValue);
				break;
			case CommandsEnum.Build:
				StartMoving(command.commandVectorValue);
				break;
		}
	}

	public void EndCommandExecution(Command command)
	{
		switch (command.commandType)
		{
			case CommandsEnum.GoTo:
				StopMoving(transform);
				break;
			case CommandsEnum.Build:
				StopMoving(transform);
				break;
		}
	}

	internal override void SubscribeToEvents()
	{
		throw new NotImplementedException();
	}

	internal override void EnableComponent()
	{
		throw new NotImplementedException();
	}

	internal override void DisableComponent()
	{
		throw new NotImplementedException();
	}
}