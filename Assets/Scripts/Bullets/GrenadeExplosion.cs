using System.Collections;
using UnityEngine;

public class GrenadeExplosion : MonoBehaviour
{
	[SerializeField]
	GameObject explosionPrefab;

	[SerializeField]
	float existingTime = 2.5f;

	[SerializeField]
	float damageRadius;

	[SerializeField]
	LayerMask damagingLayers;

	[SerializeField]
	int damageCount = 2;

	private void Start()
	{
		StartCoroutine(TimeBeforeExplosionRoutine());
	}

	private IEnumerator TimeBeforeExplosionRoutine()
	{
		while (true)
		{
			if (existingTime > 0)
				existingTime -= 1;
			else
				Explode();
			yield return new WaitForSeconds(1);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (!collision.gameObject.CompareTag("Enemy")) return;
		Explode();
	}

	private void Explode()
	{
		Destroy(Instantiate(explosionPrefab, transform.position, transform.rotation), 0.2f);
		var pt = Physics2D.OverlapCircleAll(transform.position, damageRadius, damagingLayers);
		foreach(var e in pt)
		{
			Debug.Log(e.name);
			e.GetComponent<HealthEventsProxy>().OnTakingDamage?.Invoke(damageCount);
		}
		Destroy(gameObject);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.DrawWireSphere(transform.position, damageRadius);
	}
}
