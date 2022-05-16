using UnityEngine;

[CreateAssetMenu(fileName = "New Creating Info", menuName = "Add Creating Info", order = 52)]
public class CreatingInfo : ScriptableObject
{
	[SerializeField] private string creationName;

	[SerializeField] private GameObject creationPrefab;

	[SerializeField]
	private Sprite creationImage;

	[SerializeField] private GameResources creationCost;

	[SerializeField] private GameResources destroyingCost = new GameResources(1, 0);

	public string CreationName => creationName;
	public Sprite CreationImage => creationImage;
	public GameObject CreationPrefab => creationPrefab;
	public GameResources CreationCost => creationCost;
	public GameResources DestroyingCost => destroyingCost;
}