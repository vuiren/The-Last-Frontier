using UnityEngine;

public class ShowHideUI : MonoBehaviour
{
	[SerializeField]
	float timeToMakeGUIGone = 2f;

	[SerializeField]
	GameObject GUI;

	[SerializeField]
	CanvasGroup canvasGroup;

	float curTime;

	private void Update()
	{
		if (ReadyToFade())
			canvasGroup.alpha -= Time.deltaTime;
		else
			Reload();
	}

	private void Reload()
	{
		curTime -= Time.deltaTime;
	}

	private bool ReadyToFade()
	{
		return curTime <= 0;
	}

	public void ShowGUI()
	{
		canvasGroup.alpha = 1;
		curTime = timeToMakeGUIGone;
		GUI.SetActive(true);
	}
}
