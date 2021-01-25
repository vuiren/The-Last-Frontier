using Sirenix.OdinInspector;
using UnityEngine;

public class MedicInfoHolder : MonoBehaviour
{
	[ReadOnly]
	[SerializeField]
	private GameObject healTarget;

	public GameObject HealTarget { get => healTarget; set => healTarget = value; }
}
