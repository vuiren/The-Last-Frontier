using UnityEngine;
using UnityEngine.Events;

public class OnVisible : MonoBehaviour
{
	[SerializeField]
	UnityEvent onBecameVisible;

	[SerializeField]
	UnityEvent onBecameInvisible;

	private void OnBecameInvisible()
	{
		onBecameInvisible.Invoke();
	}

	private void OnBecameVisible()
	{
		onBecameVisible.Invoke();
	}
}
