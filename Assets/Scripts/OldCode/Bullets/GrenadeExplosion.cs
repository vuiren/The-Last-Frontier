using UnityEngine;

public class GrenadeExplosion : MonoBehaviour, IProjectile
{
	[SerializeField]
	GameObject explosionPrefab;

	[SerializeField]
	float damageRadius;

	[SerializeField]
	LayerMask damagingLayers;

	[SerializeField]
	float grenadeLiveTime = 0.4f;

	[SerializeField]
	int damageCount = 2;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (!collision.gameObject.CompareTag("Enemy")) return;
		Explode();
	}

	public void Explode()
	{
		Destroy(Instantiate(explosionPrefab, transform.position, transform.rotation), grenadeLiveTime);
		var pt = Physics2D.OverlapCircleAll(transform.position, damageRadius, damagingLayers);
		foreach(var e in pt)
		{
			if (e.transform.parent != null)
			{
				var parent = e.transform.parent;
				var damagable = parent.GetComponentInChildren<IHealthController>();
				if (damagable != null)
				{
					damagable.TakeDamage(damageCount);
				}
			}
			else
			{
				e.GetComponentInChildren<IHealthController>().TakeDamage(damageCount);
				var damagable = e.GetComponentInChildren<IHealthController>();
				if (damagable != null)
				{
					damagable.TakeDamage(damageCount);
				}
			}
		}
		Destroy(gameObject);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.DrawWireSphere(transform.position, damageRadius);
	}

	public void SetDamageCount(int damageCount)
	{
		this.damageCount = damageCount;
	}
}
