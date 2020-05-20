using UnityEngine;
using UnityEngine.UI;

public class AttackingSliderReloadUISync : AttackingComponent
{
	[SerializeField]
	Slider slider;

	private void Update()
	{
		slider.value = 100 - (eventsProxy.CurReloadingTime / eventsProxy.TimeBetweenAttacks) * 100;
	}

	internal override void DisableComponent()
	{
		base.DisableComponent();
		slider.value = 100;
	}
}
