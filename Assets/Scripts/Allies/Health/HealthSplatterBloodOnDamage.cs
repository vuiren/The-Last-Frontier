using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSplatterBloodOnDamage : HealthComponent
{
	[SerializeField]
	GameObject bloodSplatterPrefab;

	[SerializeField]
	ParticleSystem particleSystem;

	internal override void SubscribeToEvents()
	{
		base.SubscribeToEvents();
		eventsProxy.OnTakingDamage += SplatterBlood;
	}

	private void SplatterBlood(int obj)
	{
	//	particleSystem.Play();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		foreach(var e in collision.contacts)
		{
			var pos = e.point;
			Instantiate(bloodSplatterPrefab, new Vector3(pos.x, pos.y), bloodSplatterPrefab.transform.rotation, transform);
		}
	}
}
