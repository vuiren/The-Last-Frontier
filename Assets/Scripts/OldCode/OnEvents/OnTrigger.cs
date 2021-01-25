using UnityEngine;
using UnityEngine.Events;

public class OnTrigger : MonoBehaviour
{
	[SerializeField]
	UnityEvent onTrigger;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		onTrigger.Invoke();
	}
}
