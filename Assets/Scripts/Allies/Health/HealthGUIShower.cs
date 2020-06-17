using UnityEngine;

public class HealthGUIShower : HealthComponent
{
	[SerializeField]
	float timeToMakeGUIGone = 2f;

	[SerializeField]
	GameObject GUI;

	[SerializeField]
	CanvasGroup canvasGroup;

	float curTime;
	bool startFade;

	internal override void SubscribeToEvents()
	{
		base.SubscribeToEvents();
		eventsProxy.OnHealthChanged += ShowGUI;
	}

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

	private void ShowGUI(int obj)
	{
		canvasGroup.alpha = 1;
		curTime = timeToMakeGUIGone;
		GUI.SetActive(true);
	}
}
