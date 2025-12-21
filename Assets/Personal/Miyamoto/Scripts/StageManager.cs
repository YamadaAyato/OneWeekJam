using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 全体の行動のマネージャークラス
/// </summary>
public class StageManager : MonoBehaviour
{
    public int MoveCount => _moveCount;
    //public Queue<DirectionType> CommandQueue => _commandQueue;

    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _startPos;
    [SerializeField] private int _moveCount;
    [SerializeField] private GameObject _stage;
    //[serializeField] private PlayerMover OnMoveStarted;
    //[SerializeField] private Queue<DirectionType> _commandQueue;

    private void Awake()
    {
        Init();
        Instantiate(_player, _startPos);
    }
    private void OnEnable()
    {
        //OnMoveStarted += AddCommnd;
    }
    private void OnDisable()
    {
        //OnMoveStarted -= AddCommnd;
    }
    /// <summary>
    /// 変数を初期化する
    /// </summary>
    private void Init()
    {
        //_player = FindAnyObjectByType<PlayerController>();
        //_startPos = GameObject.Find("Start").transform;
        //_moveCount = StageData.MoveCount;
        //_stage = StageData.Stage;
    }
    //private void AddCommand(DirectionType type)
    //{
    //    _commandQueue.Enqueue();
    //}
}
