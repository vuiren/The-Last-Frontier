using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
	[SerializeField]
	string sceneName;

	public void ChangeScene()
	{
		/*var instance = GameManager.Instance;

		instance.OnSceneChanging?.Invoke();
		instance.ResetVariables();
		SceneManager.LoadScene(sceneName);*/
	}
}
