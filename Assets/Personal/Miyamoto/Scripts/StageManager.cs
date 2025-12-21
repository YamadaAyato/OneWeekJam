using UnityEngine;

/// <summary>
/// 全体の行動のマネージャークラス
/// </summary>
public class StageManager : MonoBehaviour
{
    public int MoveCount => _moveCount;

    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _startPos;
    [SerializeField] private int _moveCount;
    [SerializeField] private GameObject _stage;
    //[SerializeField] private Queue<ICommand> _commandQueue;

    private void Awake()
    {
        Init();
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
}
