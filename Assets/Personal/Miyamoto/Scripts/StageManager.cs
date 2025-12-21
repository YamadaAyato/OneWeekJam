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
    [SerializeField] private Transform _startPos;
    [SerializeField] private int _moveCount;
    [SerializeField] private GameObject _stage;
    [SerializeField] private PlayerMover Mover;
    [SerializeField] private Queue<DirectionType> _commandQueue = new Queue<DirectionType>();

    private void Awake()
    {
        Init();
        //Instantiate(_player, _startPos);
    }
    private void OnEnable()
    {
        Mover.OnMoveStarted += AddCommand;
    }
    private void OnDisable()
    {
        Mover.OnMoveStarted -= AddCommand;
    }
    /// <summary>
    /// 変数を初期化する
    /// </summary>
    private void Init()
    {
        _player = FindAnyObjectByType<PlayerInputController>().gameObject;
        Mover = _player.GetComponent<PlayerMover>();
        //_startPos = GameObject.Find("Start").transform;
        //_moveCount = StageData.MoveCount;
        //_stage = StageData.Stage;
    }
    private void AddCommand(DirectionType type)
    {
        _commandQueue.Enqueue(type);
        Debug.Log($"<color=lime>{type}</color> : をQueueに格納");
    }
}
