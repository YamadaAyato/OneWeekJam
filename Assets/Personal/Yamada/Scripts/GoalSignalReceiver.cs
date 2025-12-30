using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///         ゴール時シグナルレシーバー用クラス
/// </summary>
public class GoalSignalReceiver : MonoBehaviour
{
    [SerializeField] private Image _fadePanel;
    [SerializeField] private float _fadeTime;
    [SerializeField] private string _sceneName;
    private GameObject _player;
    private Rigidbody2D _rb;
    private Animator _playerAnimator;

    /// <summary>
    ///         プレイヤーをセットする
    /// </summary>
    public void SetPlayer(GameObject player)
    {
        _player = player;
        _playerAnimator = player.GetComponent<Animator>();
    }

    /// <summary>
    ///         プレイヤーの操作を無効、位置固定
    /// </summary>
    public void HandleDisableControl()
    {
        _player.GetComponent<PlayerInputController>().enabled = false;
        _rb = _player.GetComponent<Rigidbody2D>();
        _rb.bodyType = RigidbodyType2D.Kinematic;
        _rb.linearVelocity = Vector3.zero;
    }

    /// <summary>
    ///         ゴールアニメーションを再生
    /// </summary>
    public void HandlePlayGoalAnim()
    {
        _playerAnimator.SetBool("IsGoal", true);
    }

    /// <summary>
    ///         画面全体をFade
    /// </summary>
    public void HandleFade()
    {
        _fadePanel.gameObject.SetActive(true);
        _fadePanel.DOFade(1f, _fadeTime).From(0);
    }

    /// <summary>
    ///         ゴールアニメーション再生終了時の処理
    /// </summary>
    public void HandleFinishGoal()
    {
        SceneLoader.LoadScene(_sceneName);
        StageProgressManager.SetStageCleared(StageDataManager.StageId);
    }
}
