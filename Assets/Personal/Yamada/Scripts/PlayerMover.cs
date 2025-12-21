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
    public bool IsMoving => _isMoving;

    [SerializeField] private float _moveDistance;
    [SerializeField] private float _moveTime;

    private bool _isMoving;

    /// <summary>
    ///         プレイヤー移動
    /// </summary>
    /// <param name="dir"></param>
    public void Move(DirectionType dir)
    {
        if (_isMoving) return;

        // 移動開始通知
        OnMoveStarted?.Invoke(dir);
        StartCoroutine(MoveRoutine(dir));
    }

    /// <summary>
    ///         移動コルーチン
    /// </summary>
    /// <param name="dir"></param>
    /// <returns></returns>
    private IEnumerator MoveRoutine(DirectionType dir)
    {
        _isMoving = true;

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
        _isMoving = false;

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
