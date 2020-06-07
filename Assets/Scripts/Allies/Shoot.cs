using UnityEngine;

public class Shoot : AllyComponent
{
	[SerializeField]
	SpriteRenderer spriteRenderer;

	[SerializeField]
	GameObject bullet;

	[SerializeField]
	Transform leftSpawnPoint;

	[SerializeField]
	Transform rightSpawnPoint;

	protected override void SubscribeToEventsProxy()
	{
		eventsProxy.OnAttackHit += SpawnBullet;
	}

	internal override void DisableComponent()
	{
		throw new System.NotImplementedException();
	}

	internal override void EnableComponent()
	{
		throw new System.NotImplementedException();
	}

	internal override void SubscribeToEvents()
	{
		throw new System.NotImplementedException();
	}

	private void SpawnBullet(int obj)
	{
		var spawnPoint = !spriteRenderer.flipX ? rightSpawnPoint : leftSpawnPoint;
		Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
	}
}
