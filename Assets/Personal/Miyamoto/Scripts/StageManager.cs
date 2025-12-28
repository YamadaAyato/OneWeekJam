using System;
using System.Collections.Generic;
using UnityEngine;

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
    [SerializeField] private StartTimelineController _startTimeline;

    [ReadOnly, SerializeField] private Queue<DirectionType> _commandQueue = new Queue<DirectionType>();
    [ReadOnly, SerializeField] private PlayerMover _mover;
    [ReadOnly, SerializeField] private Transform _startPos;
    [ReadOnly, SerializeField] private int _moveCount;
    [ReadOnly, SerializeField] private GameObject _stage;
    private bool _isSpawn;

    private void Awake()
    {
        Init();
    }
    private void OnEnable()
    {
        _mover.OnMoveStarted += AddCommand;
        _mover.OnMoveFinished += FinishCommand;
        ResetEvent.OnStageReset += ResetStage;
    }
    private void OnDisable()
    {
        _mover.OnMoveStarted -= AddCommand;
        _mover.OnMoveFinished -= FinishCommand;
        ResetEvent.OnStageReset -= ResetStage;
    }
    /// <summary>
    /// 変数を初期化する
    /// </summary>
    private void Init()
    {
        _stage = StageDataManager.Stage;
        Instantiate(_stage);
        _startPos = GameObject.Find("Start").transform;
        _player = Instantiate(_player, _startPos.position, Quaternion.identity);

        // 最初は操作不可に
        _mover = _player.GetComponent<PlayerMover>();
        _mover.enabled = false;
        _moveCount = StageDataManager.MoveCount;

        _startTimeline.Play(_player, _startPos);
    }
    /// <summary>
    /// コマンドQueueに引数で与えられものを追加する
    /// </summary>
    /// <param name="type"></param>
    private void AddCommand(DirectionType type)
    {
        if (_moveCount > 0)
        {
            _commandQueue.Enqueue(type);
            _moveCount--;
            Debug.Log($"<color=lime>{type}</color> : をQueueに格納");
        }
        Move?.Invoke();
    }
    /// <summary>
    ///         命令終了時に呼ばれる
    /// </summary>
    private void FinishCommand()
    {
        if (_moveCount <= 0 && !_isSpawn)
        {
            Instantiate(_doppelganger, _startPos.position, Quaternion.identity);
            _isSpawn = true;
            Debug.Log("ドッペルゲンガー生成");
        }
    }
    /// <summary>
    /// リセットが呼ばれたときに呼ぶ
    /// </summary>
    public void ResetStage()
    {
        Debug.Log("ステージリセット");
        _moveCount = StageDataManager.MoveCount;
        _isSpawn = false;
        Reset?.Invoke();
        _commandQueue.Clear();
        _mover.ForceStop();
        _player.transform.position = _startPos.position;
    }
}