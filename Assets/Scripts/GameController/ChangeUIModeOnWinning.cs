using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeUIModeOnWinning : MonoBehaviour
{
    private void Awake()
    {
        GlobalDataTransfer.OnGameWinning += () => GlobalDataTransfer.OnUIModeChange?.Invoke(UIModesEnum.WinningUI);
    }

}
