using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Playables;

public class GoalTimelineController : MonoBehaviour
{
    [SerializeField] private PlayableDirector _director;
    [SerializeField] private CinemachineCamera _zoomCamera;
    [SerializeField] private GoalSignalReceiver _signalReceiver;

    public void Play(GameObject player)
    {
        // 動的に注入
        _signalReceiver.SetPlayer(player);

        // カメラ追従
        // FollowとLookAtを統合した新しい書き方らしい
        _zoomCamera.Target = new CameraTarget { TrackingTarget = player.transform };

        _director.Play();
    }
}
