using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class HealthCrontroller : MonoBehaviour, IHealthController, INPCInfoReader
{
	[SerializeField] protected NPCInfoHolder NPCInfoHolder;
	[SerializeField] protected int healthCount;

	[Header("UI")]

	[SerializeField]
	protected GameObject healthGUI;

	protected Action<int> onHealthChanged;
	protected Action onPreDeath;
	protected Action onDeath;


    protected SyncUIText syncUIText;
	protected ReplaceGameObject replaceGameObject;
	protected ShowHideUI showHideUI;
	protected ThrowResources throwResources;

	protected void Awake()
    {
        AddComponents();
        SubscribeToEvents();
    }

    protected virtual void SubscribeToEvents()
    {
        var healthText = healthGUI.GetComponentInChildren<Text>();

        onHealthChanged += (x) => syncUIText.DoSyncText(healthText, x);
        onHealthChanged += (x) => showHideUI.ShowGUI(healthGUI);

        onPreDeath += () => throwResources.DoThrowResources(NPCInfoHolder.CreatingInfo.DestroyingCost.MetalCount);

        onDeath += () => replaceGameObject.DoReplaceGameObject(NPCInfoHolder.gameObject, NPCInfoHolder.NPCInfo.DestroyedPrefab);
    }

    protected virtual void AddComponents()
    {
        syncUIText = gameObject.AddComponent<SyncUIText>();
        replaceGameObject = gameObject.AddComponent<ReplaceGameObject>();
        showHideUI = gameObject.AddComponent<ShowHideUI>();
        throwResources = gameObject.AddComponent<ThrowResources>();
    }

	public void TakeDamage(int damageCount)
	{
		healthCount -= damageCount;
		onHealthChanged.Invoke(healthCount);
		if (healthCount <= 0)
		{
			onPreDeath?.Invoke();
			onDeath?.Invoke();
		}
	}

	public void TakeHeal(int healCount)
	{
		healthCount += healCount;
		onHealthChanged?.Invoke(healthCount);
	}

    private void DamageSelf()
    {
		TakeDamage(1);
	}

	public bool HealingRequired() => healthCount < NPCInfoHolder.NPCInfo.HealthCount;// maxHealthCount;

	public void SetNPCInfoHandler(NPCInfoHolder NPCInfoHolder)
	{
		this.NPCInfoHolder = NPCInfoHolder;
		healthCount = NPCInfoHolder.NPCInfo.HealthCount;
		onHealthChanged.Invoke(healthCount);
	}
}
