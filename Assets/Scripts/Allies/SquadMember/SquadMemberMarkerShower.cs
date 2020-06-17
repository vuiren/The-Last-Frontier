using UnityEngine;

public class SquadMemberMarkerShower : MonoBehaviour
{
	[SerializeField]
	GameObject marker;

	public void HideMarker()
	{
		marker.SetActive(false);
	}

	public void ShowMarker()
	{
		marker.SetActive(true);
	}
}
