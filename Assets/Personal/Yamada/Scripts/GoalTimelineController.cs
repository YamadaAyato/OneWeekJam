using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

/// <summary>
///         ゴール時のタイムライン制御クラス
/// </summary>
public class GoalTimelineController : MonoBehaviour
{
    [SerializeField] private PlayableDirector _director;
    [SerializeField] private CinemachineCamera _zoomCamera;
    [SerializeField] private GoalSignalReceiver _signalReceiver;

    /// <summary>
    ///         ゴールのタイムライン再生
    /// </summary>
    /// <param name="player"></param>
    public void Play(GameObject player)
    {
        PlayerInputController playerInput = player.GetComponent<PlayerInputController>();
        // 動的に注入
        _signalReceiver.SetPlayer(playerInput);

        // カメラ追従
        // FollowとLookAtを統合した新しい書き方らしい
        _zoomCamera.Target = new CameraTarget { TrackingTarget = player.transform };

        _director.Play();
    }
}
