using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SquadAdder : SquadComponent
{
	[SerializeField]
	bool registerAllies;
	[SerializeField]
	LayerMask squadLayer;

	Camera mainCamera;
	bool formSquad = true;
	bool holdingAdding;
	List<Transform> squad;

	internal override void SubscribeToEvents()
	{
		base.SubscribeToEvents();
		eventsProxy.OnSquadListChanged += UpdateSquad;
	}

	private void UpdateSquad(List<Transform> obj)
	{
		squad = obj;
	}

	public void ToggleFormSquad(bool toggle)
	{
		formSquad = toggle;
	}

	private void Start()
	{
		mainCamera = Camera.main;
	}

	private void Update()
	{
		if (!registerAllies) return;
		if (holdingAdding && Input.GetMouseButtonUp(0))
		{
			holdingAdding = false;
			return;
		}

		bool pointerNotOverUI = !EventSystem.current.IsPointerOverGameObject();
		if (pointerNotOverUI)
		{
			if (Input.GetMouseButtonDown(0))
			{
				AddAlly();
				return;
			}

			/*if (Input.GetMouseButton(0))
			{
				holdingAdding = true;
				AddAlly();
			}*/
		}
	}

	public void ClearSquad()
	{
		eventsProxy.OnClearSquad?.Invoke();
	}

	private void AddAlly()
	{
		var mousePos = mainCamera.ScreenPointToRay(Input.mousePosition);
		var hit = Physics2D.Raycast(mousePos.origin, mousePos.direction, 100, squadLayer);
		if (hit)
		{
			Transform hitTransform = hit.transform;
			if (formSquad)
			{
				if (holdingAdding)
				{
					if (!squad.Contains(hitTransform))
						eventsProxy.OnAllyAdd?.Invoke(hitTransform);
				}
				else
					eventsProxy.OnAllyAdd?.Invoke(hitTransform);
			}
			else
			{
				eventsProxy.OnClearSquad?.Invoke();
				eventsProxy.OnAllyAdd?.Invoke(hitTransform);
			}
		}
		else
		{
		/*	if (holdingAdding) return;
			eventsProxy.OnClearSquad?.Invoke();*/
		}
	}
}