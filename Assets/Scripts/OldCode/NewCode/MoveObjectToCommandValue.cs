using UnityEngine;

public class MoveObjectToCommandValue : MonoBehaviour
{
	[SerializeField]
	GameObject objectToMove;

	public void DoMove(Command command)
	{
		objectToMove.transform.position = command.CommandVectorValue;
	}
}
