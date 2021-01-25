using UnityEngine;
using UnityEngine.Events;

public class OnChoosing : MonoBehaviour, IChoosable
{
    [SerializeField]
    UnityEvent onChoosing;

    [SerializeField]
    UnityEvent onChoosingLast;

    [SerializeField]
    UnityEvent onUnChoosing;

    public void Choose()
    {
        onChoosing.Invoke();
    }

	public void ChooseLast()
	{
        onChoosingLast.Invoke();
	}

	public void Unchoose()
    {
        onUnChoosing.Invoke();
    }
}
