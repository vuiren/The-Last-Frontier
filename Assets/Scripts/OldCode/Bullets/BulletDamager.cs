using UnityEngine;

public class BulletDamager : MonoBehaviour, IProjectile
{
	[SerializeField]
	GameObject objectToDestronOnCollision;

	[SerializeField]
	int damageCount = 1;

	public void SetDamageCount(int damageCount)
	{
		this.damageCount = damageCount;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		var health = collision.transform.GetComponentInChildren<IHealthController>();
		if(health == null)
		{
			Destroy(gameObject);
			return;
		}
		health.TakeDamage(damageCount);//.Invoke(damageCount);
		Destroy(objectToDestronOnCollision);
	}
}
