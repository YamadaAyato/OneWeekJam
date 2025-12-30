using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GoalSignalReceiver : MonoBehaviour
{
    [SerializeField] private Image _fadePanel;
    [SerializeField] private float _fadeTime;
    [SerializeField] private string _sceneName;
    private GameObject _player;
    private Rigidbody2D _rb;
    private Animator _playerAnimator;

    public void SetPlayer(GameObject player)
    {
        _player = player;
        _playerAnimator = player.GetComponent<Animator>();
    }

    public void HandleDisableControl()
    {
        _player.GetComponent<PlayerInputController>().enabled = false;
        _rb = _player.GetComponent<Rigidbody2D>();
        _rb.bodyType = RigidbodyType2D.Kinematic;
        _rb.linearVelocity = Vector3.zero;
    }

    public void HandlePlayGoalAnim()
    {
        _playerAnimator.SetBool("IsGoal", true);
    }

    public void HandleFade()
    {
        _fadePanel.gameObject.SetActive(true);
        _fadePanel.DOFade(1f, _fadeTime).From(0);
    }

    public void HandleFinishGoal()
    {
        SceneLoader.LoadScene(_sceneName);
        StageProgressManager.SetStageCleared(StageDataManager.StageId);
    }
}
