using UnityEngine;

public class GameObjectShower : MonoBehaviour
{
	[SerializeField]
	GameObject gameObjectToShow;

	public void HideGameObject()
	{
		gameObjectToShow.SetActive(false);
	}

	public void ShowGameObject()
	{
		gameObjectToShow.SetActive(true);
	}
}
