using System;
using System.Collections;
using UnityEngine;

/// <summary>
///         プレイヤーの移動クラス
/// </summary>
public class PlayerMover : CharacterMoverBase
{
    public event Action<DirectionType> OnMoveStarted;
    public event Action OnMoveFinished;

    /// <summary>
    ///         プレイヤー移動開始！
    /// </summary>
    /// <param name="dir"></param>
    /// <param name="step"></param>
    public void Move(DirectionType dir, int step)
    {
        if (IsMoving) return;

        OnMoveStarted?.Invoke(dir);
        StartMove(dir, step);
    }

    protected override void HandleMoveFinished()
    {
        OnMoveFinished?.Invoke();
    }
}
