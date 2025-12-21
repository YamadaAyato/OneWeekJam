using UnityEngine;

public class StageManager : MonoBehaviour
{
    public int MoveCount => _moveCount;

    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _startPos;
    [SerializeField] private int _moveCount;

    private void Awake()
    {

    }
    /// <summary>
    /// 変数を初期化する
    /// </summary>
    private void Init()
    {
        //_player = FindAnyObjectByType<Player>();
        //_startPos = GameObject.Find("Start").transform;
        //_moveCount = StageData.MoveCount;
    }
}
