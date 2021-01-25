using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepByTravel : MonoBehaviour, INPCInfoReader
{
    [SerializeField] NPCInfoHolder npcInfoHolder;

    [SerializeField] float distanceBetweenSteps = 1.8f;

    [SerializeField] AudioSource audioSource;

    [SerializeField] float minVolume = 0.3f;
    [SerializeField] float maxVolume = 0.5f;

    [SerializeField] List<AudioClip> footSteps;

    float stepCycleProgress;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = npcInfoHolder.RigidBody;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = rb.velocity.magnitude;
    //    if (isGrounded)
     {
            // Advance the step cycle only if the character is grounded.
            AdvanceStepCycle(speed * Time.deltaTime);
        }

    }

    void AdvanceStepCycle(float increment)
    {
        stepCycleProgress += increment;

        if (stepCycleProgress > distanceBetweenSteps)
        {
            stepCycleProgress = 0f;
            PlayFootstep();
        }
    }

    void PlayFootstep()
    {
        var randomIndex = Random.Range(0, footSteps.Count - 1);
        AudioClip randomFootstep = footSteps[randomIndex];
        float randomVolume = Random.Range(minVolume, maxVolume);

        if (randomFootstep)
        {
            audioSource.PlayOneShot(randomFootstep, randomVolume);
        }
    }

	public void SetNPCInfoHandler(NPCInfoHolder NPCInfoHolder)
	{
        this.npcInfoHolder = NPCInfoHolder;
	}
}
