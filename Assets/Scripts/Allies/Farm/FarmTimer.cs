using UnityEngine;

public class FarmTimer : FarmComponent
{
	[SerializeField]
	float timeBetweenGeneration = 2f;

	float curTime;

	private void Update()
	{
		if (!ReadyToGenerate())
		{
			ReloadProcess();
		}
		else
		{
			Generate();
		}
	}

	private void Generate()
	{
		curTime = timeBetweenGeneration;
		eventsProxy.OnResourceTimer?.Invoke();
	}

	private void ReloadProcess()
	{
		curTime -= Time.deltaTime;
	}

	private bool ReadyToGenerate()
	{
		return curTime <= 0;

	}
}