using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class NPCInfoHolder : MonoBehaviour
{
	[SerializeField] private NPCInfo npcInfo;
	[SerializeField] private CreatingInfo creatingInfo;
	[SerializeField] Rigidbody2D rb;
	[SerializeField] [ReadOnly] private MovingsEnum movingDirection;
	[SerializeField] [ReadOnly] private Vector3 destinationPoint;
	[ReadOnly] [SerializeField] private GameObject attackTarget;

	[SerializeField] UnityEvent onCreation;

	private void Start()
	{
		FindAndSetAllNPCInfoReaders();
		onCreation.Invoke();
	}

	public GameObject AttackTarget { get => attackTarget; set => attackTarget = value; }

	public Rigidbody2D RigidBody { get => rb; }

	public NPCInfo NPCInfo { get => npcInfo; set => npcInfo = value; }
	public CreatingInfo CreatingInfo { get => creatingInfo; }
	public Vector3 DestinationPoint { get => destinationPoint; set => destinationPoint = value; }
	public MovingsEnum MovingDirection { get => movingDirection; set => movingDirection = value; }

	public void UpdateAttackTarget(GameObject target)
	{
		attackTarget = target;
	}

	public void LoseAttackTarget()
	{
		attackTarget = null;
	}

	[Button]
	private void FindAndSetAllNPCInfoReaders()
	{
		int i = 0;
		var npcInfoReaders = transform.GetComponentsInChildren<INPCInfoReader>();
		foreach (var e in npcInfoReaders)
		{
			i++;
			e.SetNPCInfoHandler(this);
		}
		Debug.Log(i + " NPCInfoReaders was set");
	}
}