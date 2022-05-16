using UnityEngine;

public class FlagController : MonoBehaviour
{
	public void ScoreFlag()
	{
		Destroy(gameObject, 3f);
	}

}
