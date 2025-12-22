using UnityEngine;

/// <summary>
///         プレイヤーが動くたびに呼び出され、LazerのOnOffを切り替える
///         このオブジェクトのタグはプレイヤーの死亡判定になるタグにしてね
/// </summary>
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Laser : MonoBehaviour
{
    [SerializeField] private bool _isBooting;

    private bool _currentIsBooting;
    private StageManager _stageManager;
    private SpriteRenderer _spriteRenderer;
    private PlayerMover _playerMover;
    private Collider2D _collider;

    /// <summary>
    ///         変更の適用
    /// </summary>
    private void ApplyState()
    {
        //  一旦OnOffでやってる、透明度いじって見やすくしたりでもいいかも
        _collider.enabled = _currentIsBooting;
        _spriteRenderer.enabled = _currentIsBooting;
    }

    /// <summary>
    ///         LazerのOnOffを切り替える
    /// </summary>
    private void SwichLazerBoot()
    {
        _currentIsBooting = !_currentIsBooting;
        ApplyState();
    }

    /// <summary>
    ///         Lazerの状態をResetする
    /// </summary>
    private void ResetBoot()
    {
        // 初期値に戻す
        _currentIsBooting = _isBooting;
        ApplyState();
    }

    private void Awake()
    {
        _stageManager = FindAnyObjectByType<StageManager>();
        _playerMover = FindAnyObjectByType<PlayerMover>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
        _currentIsBooting = _isBooting;

        ApplyState();
    }

    private void OnEnable()
    {
        _stageManager.Move += SwichLazerBoot;
        //_playerMover.OnMoveFinished += SwichLazerBoot;
        _stageManager.Reset += ResetBoot;
    }

    private void OnDisable()
    {
         _stageManager.Move -= SwichLazerBoot;
        //_playerMover.OnMoveFinished -= SwichLazerBoot;
        _stageManager.Reset -= ResetBoot;
    }
}
