using UnityEngine;

[CreateAssetMenu(fileName = "New NPC", menuName = "NPC/Create New NPC", order = 54)]
public class NPCInfo : ScriptableObject
{
	[SerializeField] private Sprite npcImage;

	[SerializeField] private int healthCount = 3;

	[SerializeField] private float moveSpeed = 1;

	[SerializeField] AttackSettings attackSettings;

	[SerializeField] private GameObject destroyedPrefab;

	public float MoveSpeed { get => moveSpeed; }
	public int HealthCount { get => healthCount; }
	public float TimeBetweenAttacks { get => attackSettings.TimeBetweenAttacks; }
	public Sprite NPCImage { get => npcImage; }
	public int DamageCount { get => attackSettings.DamageCount; }
	public AudioClip AttackSound { get => attackSettings.AttackSound; }
	public GameObject DestroyedPrefab { get => destroyedPrefab; }
	public AttackSettings AttackSettings => attackSettings;
}