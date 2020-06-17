using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeUIModeOnWinning : MonoBehaviour
{
    private void Awake()
    {
        var instance = GameInfoSingleton.Instance;

        instance.OnGameWinning += () => instance.GUIMode = UIModesEnum.WinningUI;// ?.Invoke(UIModesEnum.WinningUI);
    }

    private void OnDestroy()
    {
        var instance = GameInfoSingleton.Instance;
        if (!instance) return;
        instance.OnGameWinning -= () => instance.GUIMode = UIModesEnum.WinningUI;// ?.Invoke(UIModesEnum.WinningUI);
    }
}
