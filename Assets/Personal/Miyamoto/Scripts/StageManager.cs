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
}
