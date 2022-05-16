using UnityEngine;

public class MedicInfoHolder : MonoBehaviour
{
	[SerializeField]
	private GameObject healTarget;

	public GameObject HealTarget { get => healTarget; set => healTarget = value; }
}
