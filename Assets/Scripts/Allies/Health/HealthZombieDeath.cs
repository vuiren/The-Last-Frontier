using UnityEngine;

public class HealthZombieDeath : HealthComponent
{
	[SerializeField]
	Cost resourcesCountToSpawn;

	[SerializeField]
	GameObject foodResource;

	[SerializeField]
	GameObject moneyResource;

	[SerializeField]
	float throwForce = 0.1f;

	internal override void SubscribeToEvents()
	{
		base.SubscribeToEvents();
		eventsProxy.OnDeath += DoDestroy;
	}

	private void DoDestroy()
	{
		for (int i = 0; i < resourcesCountToSpawn.FoodCost; i++)
		{
			var randomRotation = Random.Range(0, 180);
			var a = Instantiate(foodResource, transform.position, Quaternion.Euler(0, 0, randomRotation));
			a.GetComponent<Rigidbody2D>().AddForce(transform.up * throwForce, ForceMode2D.Impulse);
		}

		for (int i = 0; i < resourcesCountToSpawn.MetalCost; i++)
		{
			var randomRotation = Random.Range(0, 10);
			var a = Instantiate(moneyResource, transform.position, Quaternion.Euler(0, 0, randomRotation));
			a.GetComponent<Rigidbody2D>().AddForce(transform.up * throwForce, ForceMode2D.Impulse);
		}
		Destroy(gameObject);
	}
}
