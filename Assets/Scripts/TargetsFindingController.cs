using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetsFindingController : WarriorComponent
{
    [SerializeField]
    LayerMask targetsLayer;

    [SerializeField]
    float radius = 1;

    [SerializeField]
    float updateTime = 1f;

    Transform closestTarget;

    void Start()
    {
        StartCoroutine(TargetsSearchingRoutine());
    }

    IEnumerator TargetsSearchingRoutine()
    {
        while (true)
        {
            var pt = Physics2D.OverlapBoxAll(transform.position, new Vector2(radius, radius), 0, targetsLayer);
            if (pt.Length > 0)
            {
                closestTarget = GetClosestEnemy(pt, transform);
                var target = closestTarget.GetComponent<ITarget>();
                target.OnDestroyed += RemoveTarget;
                eventsProxy.OnNoticingEnemy?.Invoke(closestTarget);
            }
            yield return new WaitForSeconds(updateTime);
        }
    }

    private void RemoveTarget(Transform obj)
    {
        if (this == null || obj == null || transform == null) return;
        eventsProxy.OnEnemyDeath?.Invoke();
       // eventsProxy.OnEnemyOutOfAttackingRange?.Invoke();
    }

    Transform GetClosestEnemy(Collider2D[] enemies, Transform fromThis)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = fromThis.position;
        foreach (var potentialTarget in enemies)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget.transform;
            }
        }
        return bestTarget;
    }

    protected override void SubscribeToEventsProxy()
    {
    }

    internal override void EnableComponent()
    {
        throw new System.NotImplementedException();
    }

    internal override void DisableComponent()
    {
        throw new System.NotImplementedException();
    }
}