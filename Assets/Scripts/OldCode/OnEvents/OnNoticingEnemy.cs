using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class OnNoticingEnemy : MonoBehaviour
{
	[SerializeField]
	GameObjectUnityEvent onNoticingEnemy;

	[SerializeField]
	UnityEvent onLosingEnemy;

	[ReadOnly]
	[SerializeField]
	GameObject previousEnemy;

	public void UpdateTarget(GameObject target)
	{
		if(previousEnemy != null && target == null)
		{
			onLosingEnemy.Invoke();
		}
		else
		{
			if (previousEnemy == target) return;
			onNoticingEnemy.Invoke(target);
		}
		previousEnemy = target;
	}
}
