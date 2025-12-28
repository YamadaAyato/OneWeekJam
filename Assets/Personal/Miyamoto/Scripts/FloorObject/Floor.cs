using UnityEngine;

public enum FloorState
{
    Closed,
    Open
}

/// <summary>
/// 床を開ける動作と閉じる動作を持つクラス
/// </summary>
public class Floor : MonoBehaviour
{
    [SerializeField]
    private FloorSwitch _floorSwitch;

    [Tooltip("ゲーム開始時の床の状態")]
    [SerializeField]
    private FloorState _initialState = FloorState.Closed;

    private Animator _animator;
    private Collider2D _collider2D;
    private bool _initialIsOpen;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _collider2D = GetComponent<Collider2D>();

        // 初期状態を保存して設定
        _initialIsOpen = (_initialState == FloorState.Open);
        SetFloorState(_initialIsOpen);
    }

    private void OnEnable()
    {
        _floorSwitch.OnCharacterEnter += OnSwitchPressed;
        _floorSwitch.OnCharacterLeft += OnSwitchReleased;
    }

    private void OnDisable()
    {
        _floorSwitch.OnCharacterEnter -= OnSwitchPressed;
        _floorSwitch.OnCharacterLeft -= OnSwitchReleased;
    }

    /// <summary>
    /// スイッチが押されたとき：初期状態の逆にする
    /// </summary>
    private void OnSwitchPressed()
    {
        SetFloorState(!_initialIsOpen);
    }

    /// <summary>
    /// スイッチが離されたとき：初期状態に戻す
    /// </summary>
    private void OnSwitchReleased()
    {
        SetFloorState(_initialIsOpen);
    }

    /// <summary>
    /// 床の状態を設定
    /// </summary>
    private void SetFloorState(bool isOpen)
    {
        _animator.SetBool("Open", isOpen);
        _collider2D.enabled = !isOpen;
    }
}