using UnityEngine;

public class ShowHideUI : MonoBehaviour
{
	[SerializeField]
	float timeToMakeGUIGone = 2f;

	CanvasGroup canvasGroup;

	float curTime;

	private void Update()
	{
		if (!canvasGroup)
        {
			enabled = false;
			return;
        }

		enabled = canvasGroup.alpha > 0;

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

	public void ShowGUI(GameObject gui)
	{
		if (!canvasGroup)
			canvasGroup = gui.GetComponentInChildren<CanvasGroup>();

		//enabled = true;
		canvasGroup.alpha = 1;
		curTime = timeToMakeGUIGone;
		gui.SetActive(true);
	}
}