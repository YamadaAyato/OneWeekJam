using UnityEngine;

/// <summary>
/// 床を開ける動作と閉じる動作を持つクラス
/// </summary>
public class Floor : MonoBehaviour
{
    [SerializeField]
    private FloorSwitch _floorSwitch;
    private Animator _animator;
    private Collider2D _collider2D;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _collider2D = GetComponent<Collider2D>();
        _collider2D.enabled = true;
    }

    private void OnEnable()
    {
        _floorSwitch.OnCharacterEnter += FloorOpen;
        _floorSwitch.OnCharacterLeft += FloorClose;
    }
    private void OnDisable()
    {
        _floorSwitch.OnCharacterEnter -= FloorOpen;
        _floorSwitch.OnCharacterLeft -= FloorClose;
    }
    /// <summary>
    /// 床空ける
    /// </summary>
    private void FloorOpen()
    {
        _animator.SetBool("Open", true);
        _collider2D.enabled = false;
    }
    /// <summary>
    /// 床閉じる
    /// </summary>
    private void FloorClose()
    {
        _animator.SetBool("Open", false);
        _collider2D.enabled = true;
    }
}
