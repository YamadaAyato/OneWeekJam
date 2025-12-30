using UnityEngine;

public class GoalSignalReceiver : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    private GameObject _player;
    private Animator _playerAnimator;

    public void SetPlayer(GameObject player)
    {
        _player = player;
        _playerAnimator = player.GetComponent<Animator>();
    }

    public void HandleDisableControl()
    {
        _player.GetComponent<PlayerInputController>().enabled = false;
    }

    public void HandlePlayGoalAnim()
    {
        _playerAnimator.SetBool("IsGoal", true);
    }

    public void HandleFinishGoal()
    {
        SceneLoader.LoadScene(_sceneName);
        StageProgressManager.SetStageCleared(StageDataManager.StageId);
    }
}
