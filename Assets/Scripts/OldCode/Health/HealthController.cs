using System;
using Base;
using Services;
using UnityEngine;
using Zenject;

public abstract class HealthCrontroller : ActorComponent, IHealthController
{
    protected Action onPreDeath;
    protected Action onDeath;
    
    protected ReplaceGameObject replaceGameObject;
    protected ThrowResources throwResources;
    
    private NPCInfoHolder NPCInfoHolder;
    private IHealthService _healthService;

    [Inject]
    public void Construct(IActorsService actorsService, IHealthService healthService)
    {
        Debug.Log("Check");
        var actor = actorsService.GetActor(_actor.id);
        Debug.Log(actor);
        NPCInfoHolder = actor.GetComponentInChildren<NPCInfoHolder>();
        _healthService = healthService;
        
        var healthCount = NPCInfoHolder.NPCInfo.HealthCount;
        _healthService.ChangeHealth(_actor.id, healthCount);
    }

    protected override void Awake()
    {
        base.Awake();
        AddComponents();
        SubscribeToEvents();
    }

    protected virtual void SubscribeToEvents()
    {
        onPreDeath += () => throwResources.DoThrowResources(NPCInfoHolder.CreatingInfo.DestroyingCost.MetalCount);

        onDeath += () =>
            replaceGameObject.DoReplaceGameObject(NPCInfoHolder.gameObject, NPCInfoHolder.NPCInfo.DestroyedPrefab);
    }

    protected virtual void AddComponents()
    {
        replaceGameObject = gameObject.AddComponent<ReplaceGameObject>();
        throwResources = gameObject.AddComponent<ThrowResources>();
    }

    public void TakeDamage(int damageCount)
    {
        var healthCount = _healthService.GetHealth(_actor.id);
        healthCount -= damageCount;
        _healthService.ChangeHealth(_actor.id, healthCount);
        if (healthCount <= 0)
        {
            onPreDeath?.Invoke();
            onDeath?.Invoke();
        }
    }

    public void TakeHeal(int healCount)
    {
        var healthCount = _healthService.GetHealth(_actor.id);
        healthCount += healCount;
        _healthService.ChangeHealth(_actor.id, healthCount);
    }

    private void DamageSelf()
    {
        TakeDamage(1);
    }

    public bool HealingRequired() =>
        _healthService.GetHealth(_actor.id) < NPCInfoHolder.NPCInfo.HealthCount; // maxHealthCount;
}