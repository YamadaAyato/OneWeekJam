using UnityEngine;
/// <summary>
/// 消える床の処理
/// </summary>
public class FloorButton : MonoBehaviour
{
    [Header("どのタグを指定するか")]
    [SerializeField] private string _tagName;

    /// <summary>
    /// ボタンによってタグを変えることで消す床の種類を変える
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject[] tagObject = GameObject.FindGameObjectsWithTag(_tagName);
            foreach (var t in tagObject)
            {
                t.SetActive(false);
            }
        }
    }
}
