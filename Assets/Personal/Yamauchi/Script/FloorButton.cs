using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 消える床の処理
/// </summary>
public class FloorButton : MonoBehaviour
{
    [Header("消すオブジェクトのリスト")]
    [SerializeField] private List<GameObject> _destroyList = new List<GameObject>();

    /// <summary>
    /// ボタンによってタグを変えることで消す床の種類を変える
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (var item in _destroyList)
            {
                item.SetActive(false);
            }
        }
    }
}
