using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

/// <summary>
/// 全体の行動のマネージャークラス
/// </summary>
public class StageManager : MonoBehaviour
{
    public int MoveCount => _moveCount;
    public Queue<DirectionType> CommandQueue => _commandQueue;

    public event Action Reset;
    public event Action Move;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _doppelganger;
    [SerializeField] private Transform _startPos;
    [SerializeField] private int _moveCount;
    [SerializeField] private GameObject _stage;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private Queue<DirectionType> _commandQueue = new Queue<DirectionType>();
    private bool _isSpawn;

    private void Awake()
    {
        Init();
        //Instantiate(_player, _startPos.position, Quaternion.identity);
    }
    private void OnEnable()
    {
        _mover.OnMoveStarted += AddCommand;
        ResetEvent.OnStageReset += ResetStage;
    }
    private void OnDisable()
    {
        _mover.OnMoveStarted -= AddCommand;
        ResetEvent.OnStageReset -= ResetStage;
    }
    /// <summary>
    /// 変数を初期化する
    /// </summary>
    private void Init()
    {
        _player = FindAnyObjectByType<PlayerInputController>().gameObject;
        _mover = _player.GetComponent<PlayerMover>();
        //_startPos = GameObject.Find("Start").transform;
        //_moveCount = StageData.MoveCount;
        //_stage = StageData.Stage;
    }
    /// <summary>
    /// コマンドQueueに引数で与えられものを追加する
    /// </summary>
    /// <param name="type"></param>
    private void AddCommand(DirectionType type)
    {
        if (_moveCount <= 0 && !_isSpawn)
        {
            Instantiate(_doppelganger, _startPos.position, Quaternion.identity);
            _isSpawn = true;
        }
        else if(_moveCount > 0)
        {
            _commandQueue.Enqueue(type);
            _moveCount--;
            Debug.Log($"<color=lime>{type}</color> : をQueueに格納");
        }
        Move?.Invoke();
    }
    /// <summary>
    /// リセットが呼ばれたときに呼ぶ
    /// </summary>
    public void ResetStage()
    {
        Debug.Log("ステージリセット");
        Reset?.Invoke();
        _commandQueue.Clear();
        _player.transform.position = _startPos.position;
    }
}