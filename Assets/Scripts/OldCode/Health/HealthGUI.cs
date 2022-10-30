using Base;
using Cysharp.Threading.Tasks;
using Services;
using TMPro;
using UnityEngine;
using Zenject;

public class HealthGUI : ActorComponent
{
    [SerializeField] private GameObject healthGUI;
    [SerializeField] private TextMeshProUGUI healthText;
    private IHealthService _healthService;
    
    [Inject]
    public void Construct(IHealthService healthService)
    {
        _healthService = healthService;
        _healthService.OnHealthChanged(UpdateUI);
        _healthService.OnHealthChanged(x => ShowGUI(x));
        
        healthGUI.SetActive(false);
    }

    private void UpdateUI(int actorId)
    {
        if(_actor.id != actorId) return;

        var health = _healthService.GetHealth(actorId);
        healthText.text = health.ToString();
    }
    
    private async UniTask ShowGUI(int actorId)
    {
        if(_actor.id != actorId) return;
        
        healthGUI.SetActive(true);
        await UniTask.Delay(3000);
        healthGUI.SetActive(false);
    }
}
