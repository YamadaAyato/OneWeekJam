using UnityEngine;
/// <summary>
/// ドアのテレポート処理
/// </summary>
public class Door : MonoBehaviour
{
    [Header("テレポートする座標")]
    [SerializeField] private GameObject _teleportGameObject;

    /// <summary>
    /// 入ってきたオブジェクトのtagがplayerなら、テレポートさせる
    /// テレポートが一度終わったら再びボタンを踏むまでテレポートはしない
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Open(true))
        {
            GameObject player = collision.gameObject;
            player.transform.position = _teleportGameObject.transform.position;
            Open(false);
        }
    }

    public bool Open(bool open)
    {
        if (!open)
            return false;

        return true;
    }
}
