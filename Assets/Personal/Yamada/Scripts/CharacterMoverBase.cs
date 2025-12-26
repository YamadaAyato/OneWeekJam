using System.Collections;
using UnityEngine;

/// <summary>
///         Moverの基底クラス
/// </summary>
public abstract class CharacterMoverBase : MonoBehaviour
{
    /// <summary>
    ///         今動いているかのプロパティ
    /// </summary>
    public bool IsMoving => _moveCoroutine != null;

    [SerializeField] protected float _moveDistance;
    [SerializeField] protected float _moveTime;

    protected Animator _animator;
    protected Coroutine _moveCoroutine;
    protected SpriteRenderer _spriteRenderer;

    /// <summary>
    ///         ギミック（テレポートなど）によって
    ///         強制的に位置変更される際に呼ばれる処理
    /// </summary>
    public virtual void HandleTeleport()
    {
        ForceStop();
    }

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

        if (_animator != null)
        {
            _animator.SetBool("IsLadder", false);
        }
    }

    /// <summary>
    ///         キャラクター移動
    /// </summary>
    /// <param name="dir"></param>
    protected virtual void StartMove(DirectionType dir, int step)
    {
        if (_moveCoroutine != null) return;

        _moveCoroutine = StartCoroutine(MoveRoutine(dir, step));
    }

    /// <summary>
    ///         移動コルーチン
    /// </summary>
    /// <param name="dir"></param>
    /// <returns></returns>
    protected virtual IEnumerator MoveRoutine(DirectionType dir, int step)
    {
        if (dir == DirectionType.Up || dir == DirectionType.Down)
            _animator.SetBool("IsLadder", true);
        else if (dir == DirectionType.Left)
            _spriteRenderer.flipX = true;
        else if (dir == DirectionType.Right)
            _spriteRenderer.flipX = false;

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

        _animator.SetBool("IsLadder", false);

        HandleMoveFinished();
    }

    /// <summary>
    ///         移動完了メソッド（プレイヤーのイベント用）
    /// </summary>
    protected virtual void HandleMoveFinished() { }

    /// <summary>
    ///         方向のenumからvector2に変換
    /// </summary>
    /// <param name="dir"></param>
    /// <returns></returns>
    protected virtual Vector2 DirectionToVector(DirectionType dir)
    {
        return dir switch
        {
            DirectionType.Up => Vector2.up,
            DirectionType.Down => Vector2.down,
            DirectionType.Left => Vector2.left,
            DirectionType.Right => Vector2.right
        };
    }

    protected virtual void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }
}
