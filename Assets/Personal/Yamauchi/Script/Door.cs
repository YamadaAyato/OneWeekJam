using UnityEngine;
/// <summary>
/// ドアのテレポート処理
/// </summary>
public class Door : MonoBehaviour
{
    [Header("テレポートする座標")]
    [SerializeField] private Vector2 _teleportPosition;
    [Header("DoorButton")]
    [SerializeField] private DoorButton _doorButton;

    /// <summary>
    /// 入ってきたオブジェクトのtagがplayerなら、テレポートさせる
    /// テレポートが一度終わったら再びボタンを踏むまでテレポートはしない
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && _doorButton.isDoorOpen)
        {
            GameObject player = collision.gameObject;
            player.transform.position = _teleportPosition;
            _doorButton.isDoorOpen = false;
        }
    }
}
