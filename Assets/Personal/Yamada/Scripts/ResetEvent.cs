using System;
using UnityEngine;

/// <summary>
///         ステージのリセットイベントクラス
/// </summary>
public static class ResetEvent
{
    public static event Action OnStageReset;

   　/// <summary>
    ///         リセットイベント発火
    /// </summary>
    public static void RaiseStageReset()
    {
        OnStageReset?.Invoke();
        Debug.Log("ステージリセットイベント発火！");
    }
}
