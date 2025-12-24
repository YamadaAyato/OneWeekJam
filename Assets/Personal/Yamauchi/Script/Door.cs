using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ドアのテレポート処理
/// </summary>
public class Door : MonoBehaviour
{
    [Header("テレポートする座標")]
    [SerializeField] private GameObject _teleportGameObject;
    [Header("DoorManager")]
    [SerializeField] private DoorManager _doorManager;
    [Header("ドアの初期状態")]
    [SerializeField]
    private bool _isOpen = default;

    /// <summary>
    /// 入ってきたオブジェクトのtagがplayerなら、テレポートさせる
    /// テレポートが一度終わったら再びボタンを踏むまでテレポートはしない
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (!_isOpen) return;

        if (!collision.TryGetComponent<IActor>(out var teleportable))
            return;

        _teleportGameObject.GetComponent<Collider2D>().enabled = false;

        teleportable.OnTeleport();

        collision.transform.position = _teleportGameObject.transform.position;

        _doorManager.CallClose();
        Invoke(nameof(RessurectionCollider), 1.5f);
    }

    /// <summary>
    /// ドアを開ける処理
    /// </summary>
    public void Open()
    {
        _isOpen = true;
    }

    /// <summary>
    /// ドアを閉める処理
    /// </summary>
    public void Close()
    {
        _isOpen = false;
    }

    /// <summary>
    /// テレポート先のオブジェクトのコライダーを復活させる処理
    /// テレポートできなくしてからコライダーを復活させる
    /// </summary>
    private void RessurectionCollider()
    {
        _teleportGameObject.GetComponent<Collider2D>().enabled = true;
    }
}
