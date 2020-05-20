using UnityEngine;

public class AttackStarter : MonoBehaviour
{
	AttackingMovingToTarget GoToBasic;

	private void Awake()
	{
		GoToBasic = GetComponent<AttackingMovingToTarget>();
	}

	public void StartAttack()
	{
		var comms = GetComponents<AttackingComponent>();
		GoToBasic.enabled = !GoToBasic.enabled;
		foreach(var e in comms)
		{
			e.enabled = !e.enabled;
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
			StartAttack();
	}
}
