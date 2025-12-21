using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 全体の行動のマネージャークラス
/// </summary>
public class StageManager : MonoBehaviour
{
    public int MoveCount => _moveCount;
    public Queue<DirectionType> CommandQueue => _commandQueue;

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
        //Instantiate(_player, _startPos);
    }
    private void OnEnable()
    {
        _mover.OnMoveStarted += AddCommand;
    }
    private void OnDisable()
    {
        _mover.OnMoveStarted -= AddCommand;
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
    private void AddCommand(DirectionType type)
    {
        if (_moveCount < 0 && !_isSpawn)
        {
            Instantiate(_doppelganger, _startPos);
        }
        else
        {
            _commandQueue.Enqueue(type);
            _moveCount--;
            Debug.Log($"<color=lime>{type}</color> : をQueueに格納");
        }
    }
}
