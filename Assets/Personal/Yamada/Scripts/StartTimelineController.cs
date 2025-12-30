using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Playables;

/// <summary>
///         スタート時のタイムライン制御クラス
/// </summary>
public class StartTimelineController : MonoBehaviour
{
    [SerializeField] private PlayableDirector _director;
    [SerializeField] private CinemachineCamera _startZoom;
    [SerializeField] private StartSignalReceiver _signalReceiver;

   /// <summary>
   ///          スタートのアニメーションをセットしてプレイ
   /// </summary>
   /// <param name="player"></param>
   /// <param name="door"></param>
    public void Play(GameObject player, Transform door)
    {
        // Signalに動的オブジェクトを渡す
        _signalReceiver.SetPlayer(player);
        _signalReceiver.SetDoor(door.gameObject);

        // カメラ追従を動的に設定
        _startZoom.Follow = player.transform;
        _startZoom.LookAt = player.transform;

        _director.Play();
    }
}
