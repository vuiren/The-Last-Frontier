using UnityEngine;

public class SplatterBloodOnCollision : MonoBehaviour
{
	[SerializeField]
	GameObject bloodSplatterPrefab;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		foreach(var e in collision.contacts)
		{
			var pos = e.point;
			Instantiate(bloodSplatterPrefab, new Vector3(pos.x, pos.y), bloodSplatterPrefab.transform.rotation, transform);
		}
	}
}
