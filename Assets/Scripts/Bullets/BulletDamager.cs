using UnityEngine;

public class BulletDamager : MonoBehaviour
{
	[SerializeField]
	int damageCount = 1;
	private void OnCollisionEnter2D(Collision2D collision)
	{
		var health = collision.transform.GetComponent<HealthEventsProxy>();
		if(health == null)
		{
			Destroy(gameObject);
			return;
		}
		health.OnTakingDamage?.Invoke(damageCount);
		Destroy(gameObject);
	}
}
