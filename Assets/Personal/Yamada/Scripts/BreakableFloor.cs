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

    /// <summary>
    ///         床を落としながら破壊
    /// </summary>
    private void Break()
    {
        // 落ちて消えていくように設定、一定時間たつと破壊
        _rb.bodyType = RigidbodyType2D.Dynamic;
        _boxCollider.enabled = false;
        Destroy(this.gameObject, _destroyTime);
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        // 通常は動かないように
        _rb.bodyType = RigidbodyType2D.Kinematic;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")
            || collision.gameObject.CompareTag("Enemy"))
        {
            _maxPassCount--;
            Debug.Log($"壊れる床を通過 後{_maxPassCount}回");

            if (_maxPassCount <= 0)
                Break();
        }
    }
}
