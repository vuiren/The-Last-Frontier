using UnityEngine;

public class AttackingPlaySoundOnAttack : AttackingComponent
{
	[SerializeField]
	AudioSource audioSource;

	internal override void SubscribeToEvents()
	{
		base.SubscribeToEvents();
		eventsProxy.OnEnemyHit += PlaySound;
	}

	private void PlaySound()
	{
		if (!audioSource.isPlaying)
			audioSource.Play();
	}
}
