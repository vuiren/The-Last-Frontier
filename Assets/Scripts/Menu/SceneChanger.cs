using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
	[SerializeField]
	string sceneName;

	public void ChangeScene()
	{
		GlobalDataTransfer.OnSceneChanging?.Invoke();
		GlobalDataTransfer.ResetVariables();
		SceneManager.LoadScene(sceneName);
	}
}
