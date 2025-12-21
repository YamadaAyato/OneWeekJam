using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ドッペルゲンガークラス
/// </summary>
public class Doppelganger : MonoBehaviour
{
    [SerializeField] private float _moveDistance;
    [SerializeField] private float _moveTime;
    private StageManager _stageManager;
    private Queue<DirectionType> _moveQueue = new Queue<DirectionType>();

    private void Awake()
    {
        _stageManager = GameObject.FindAnyObjectByType<StageManager>();
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
    /// <summary>
    ///         ドッペルゲンガー移動
    /// </summary>
    /// <param name="dir"></param>
    public void Move()
    {
        if (_moveQueue.Count <= 0) return;

        var dir = _moveQueue.Dequeue();
        // 移動開始通知
        StartCoroutine(MoveRoutine(dir));
    }

    /// <summary>
    ///         移動コルーチン
    /// </summary>
    /// <param name="dir"></param>
    /// <returns></returns>
    private IEnumerator MoveRoutine(DirectionType dir)
    {

        Vector2 direction = DirectionToVector(dir);

        // 初期位置とターゲットとなる場所を計算
        Vector3 startPos = transform.position;
        Vector3 targetPos = startPos + (Vector3)(direction.normalized * _moveDistance);

        // 位置を補間して滑らかに移動
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / _moveTime;
            transform.position = Vector3.Lerp(startPos, targetPos, t);
            yield return null;
        }

        transform.position = targetPos;
    }

    /// <summary>
    ///         方向のenumからvector2に変換
    /// </summary>
    /// <param name="dir"></param>
    /// <returns></returns>
    private Vector2 DirectionToVector(DirectionType dir)
    {
        return dir switch
        {
            DirectionType.Up => Vector2.up,
            DirectionType.Down => Vector2.down,
            DirectionType.Left => Vector2.left,
            DirectionType.Right => Vector2.right
        };
    }
    /// <summary>
    /// リセット
    /// </summary>
    private void OnReset()
    {
        _moveQueue.Clear();
        _stageManager = null;
        _moveTime = 0f;
        _moveDistance = 0f;
        Destroy(gameObject);
    }
}
