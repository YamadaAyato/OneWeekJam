using UnityEngine;

/// <summary>
///         プレイヤーや敵が通過すると壊れる床のクラス
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class BreakableFloor : MonoBehaviour
{
    [SerializeField] private int _maxPassCount;
    [SerializeField] private float _destroyTime;

    private Rigidbody2D _rb;
    private BoxCollider2D _boxCollider;
    private Animator _animator;
    private Vector3 _startPos;
    private StageManager _stageManager;
    private int _currentPassCount;

    /// <summary>
    ///         リセット
    /// </summary>
    public void ResetFloor()
    {
        // 初期化
        _currentPassCount = _maxPassCount;

        // 落下しているため速度を消す
        _rb.linearVelocity = Vector2.zero;
        _rb.bodyType = RigidbodyType2D.Kinematic;
        _boxCollider.enabled = true;
        this.transform.position = _startPos;

        UpdateAnimation();
    }

    /// <summary>
    ///         アニメーションの更新
    /// </summary>
    private void UpdateAnimation()
    {
        _animator.SetInteger("Count", _currentPassCount);
    }

    /// <summary>
    ///         床を落としながら破壊
    /// </summary>
    private void Break()
    {
        _boxCollider.enabled = false;
    }

    private void Awake()
    {
        _stageManager = FindAnyObjectByType<StageManager>();
        _rb = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();

        // 通常は動かないように
        _rb.bodyType = RigidbodyType2D.Kinematic;
        _startPos = this.transform.position;
        _currentPassCount = _maxPassCount;

        ResetFloor();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")
            || collision.gameObject.CompareTag("Enemy"))
        {
            _currentPassCount--;
            Debug.Log($"壊れる床を通過 後{_currentPassCount}回");

            UpdateAnimation();

            if (_currentPassCount <= 0)
                Break();
        }
    }

    private void OnEnable()
    {
        _stageManager.Reset += ResetFloor;
    }

    private void OnDisable()
    {
        _stageManager.Reset -= ResetFloor;
    }
}
