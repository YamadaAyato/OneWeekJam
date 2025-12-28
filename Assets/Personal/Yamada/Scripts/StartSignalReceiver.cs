using Unity.Cinemachine;
using UnityEngine;

/// <summary>
///          シグナルレシーバー用クラス
/// </summary>
public class StartSignalReceiver : MonoBehaviour
{
    [SerializeField] private CinemachineCamera _startZoom;
    [SerializeField] private CinemachineCamera _endZoom;

    private GameObject _player;
    private Animator _doorAnimator;

    /// <summary>
    ///         プレイヤーをセットする
    /// </summary>
    /// <param name="player"></param>
    public void SetPlayer(GameObject player)
    {
        _player = player;
        _player.SetActive(false);
    }

    /// <summary>
    ///         ドアをセットする
    /// </summary>
    /// <param name="door"></param>
    public void SetDoor(GameObject door)
    {
        _doorAnimator = door.GetComponent<Animator>();
    }

    /// <summary>
    ///         ドアアニメーションを再生
    /// </summary>
    public void HandleDoorOpen()
    {
        if (_doorAnimator == null)
        {
            Debug.LogWarning("DoorAnimatorがnull");
            return;
        }

        _doorAnimator.Play("DoorOpen", 0, 0f);
    }

    /// <summary>
    ///         プレイヤーを出現
    /// </summary>
    public void HandlePlayerAppear()
    {
        if (_player == null)
        {
            Debug.LogWarning("Player is null");
            return;
        }

        _player.SetActive(true);
    }

    /// <summary>
    ///         プレイヤー操作をONに
    /// </summary>
    public void HandleEnableControl()
    {
        _player.GetComponent<PlayerInputController>().enabled = true;
    }

    /// <summary>
    ///         カメラの優先度を変更
    /// </summary>
    public void SwitchToGameplayCamera()
    {
        _startZoom.Priority = 0;
        _endZoom.Priority = 10;
    }
}
