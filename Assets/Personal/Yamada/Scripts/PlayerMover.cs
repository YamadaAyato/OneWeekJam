using System;
using System.Collections;
using UnityEngine;

/// <summary>
///         プレイヤーの移動クラス
/// </summary>
public class PlayerMover : MonoBehaviour
{
    public event Action<DirectionType> OnMoveStarted;
    public event Action OnMoveFinished;

    /// <summary>
    ///         今動いているかのプロパティ
    /// </summary>
    public bool IsMoving => _moveCoroutine != null;

    [SerializeField] private float _moveDistance;
    [SerializeField] private float _moveTime;

    private Coroutine _moveCoroutine;

    /// <summary>
    ///         Move処理を強制終了
    /// </summary>
    public void ForceStop()
    {
        if (_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);
            _moveCoroutine = null;
        }
    }

    /// <summary>
    ///         プレイヤー移動
    /// </summary>
    /// <param name="dir"></param>
    public void Move(DirectionType dir, int step)
    {
        if (_moveCoroutine != null) return;

        // 移動開始通知
        OnMoveStarted?.Invoke(dir);
        _moveCoroutine = StartCoroutine(MoveRoutine(dir, step));
    }

    /// <summary>
    ///         移動コルーチン
    /// </summary>
    /// <param name="dir"></param>
    /// <returns></returns>
    private IEnumerator MoveRoutine(DirectionType dir, int step)
    {
        Vector2 direction = DirectionToVector(dir);

        // 初期位置とターゲットとなる場所を計算
        Vector3 startPos = transform.position;
        Vector3 targetPos = startPos + (Vector3)(direction.normalized * _moveDistance * step);

        // 位置を補間して滑らかに移動
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / _moveTime;
            transform.position = Vector3.Lerp(startPos, targetPos, t);
            yield return null;
        }

        transform.position = targetPos;
        _moveCoroutine = null;

        // 移動完了通知
        OnMoveFinished?.Invoke();
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
}
