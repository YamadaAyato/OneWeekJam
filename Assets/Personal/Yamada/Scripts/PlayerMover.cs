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

    [SerializeField] private WalkEffect _walkEffect;
    [SerializeField] private Vector3 _walkOffset;

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
        SpawnEffect(dir);

    }

    protected override void HandleMoveFinished()
    {
        OnMoveFinished?.Invoke();
    }

    /// <summary>
    ///         Effect再生用
    /// </summary>
    private void SpawnEffect(DirectionType dir)
    {
        AudioManager.Instance.PlaySE("Move");
        if (dir == DirectionType.Right)
        {
            WalkEffect walk = Instantiate(_walkEffect, transform.position + _walkOffset, Quaternion.identity);
            walk.SetFlip(false);
        }
        else if (dir == DirectionType.Left)
        {
            WalkEffect walk = Instantiate(_walkEffect, transform.position + _walkOffset, Quaternion.identity);
            walk.SetFlip(true);
        }
    }
}
