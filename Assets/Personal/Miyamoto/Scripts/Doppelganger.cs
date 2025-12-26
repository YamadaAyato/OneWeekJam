using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ドッペルゲンガークラス
/// </summary>
public class Doppelganger : CharacterMoverBase
{
    private StageManager _stageManager;
    private Queue<DirectionType> _moveQueue = new Queue<DirectionType>();
    private DoppelgangerColider _dopCol;

    /// <summary>
    ///         ドッペルゲンガー移動
    /// </summary>
    /// <param name="dir"></param>
    public void Move()
    {
        if (IsMoving) return;
        if (_moveQueue.Count <= 0) return;

        var dir = _moveQueue.Dequeue();

        int step = 1;

        // 梯子のステップを読み取ってstepを更新
        if((dir == DirectionType.Up || dir == DirectionType.Down)
            && _dopCol.IsLadder)
        {
            step = _dopCol.CurrentLadder.Step;
        }

        StartMove(dir, step);
    }

    /// <summary>
    /// リセット
    /// </summary>
    private void OnReset()
    {
        _moveQueue.Clear();
        Destroy(gameObject);
    }

    protected override void Awake()
    {
        base.Awake();
        _stageManager = GameObject.FindAnyObjectByType<StageManager>();
        _dopCol = GetComponent<DoppelgangerColider>();
        _moveQueue = GameObject.FindAnyObjectByType<StageManager>().CommandQueue;
    }

    private void OnEnable()
    {
        _stageManager.Reset += OnReset;
        _stageManager.Move += Move;
    }

    private void OnDisable()
    {
        _stageManager.Reset -= OnReset;
        _stageManager.Move -= Move;
    }
}
