using UnityEngine;

public class ThrowResources : MonoBehaviour
{
	public void DoThrowResources(int metalCount)
	{
		GameObject metalPrefab = Resources.Load("Prefabs/Metal", typeof(GameObject)) as GameObject;

		for (int i = 0; i < metalCount; i++)
		{
			var throwAngle = Quaternion.Euler(0, 0, Random.Range(-5, 5));
			var throwForce = Random.Range(0.1f, 0.15f);
			var metalInstance = GameObject.Instantiate(metalPrefab, transform.position, throwAngle);
			var metalRB = metalInstance.GetComponent<Rigidbody2D>();
			metalRB.AddForce(metalRB.transform.TransformDirection(Vector3.up) * throwForce, ForceMode2D.Impulse);
		}
	}
}