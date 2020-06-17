using UnityEngine;

public class OnTakingDamage : MonoBehaviour, IDamageable
{
	[SerializeField]
	IntUnityEvent onTakingDamage;

	public bool IsDead()
	{
		throw new System.NotImplementedException();
	}

	public void TakeDamage(int damageCount)
	{
		onTakingDamage.Invoke(damageCount);
	}
}
