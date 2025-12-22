using UnityEngine;
/// <summary>
/// ボタンを押すとドアでのテレポートが可能になる
/// </summary>
public class DoorButton : MonoBehaviour
{
    [Header("Door")]
    [SerializeField] private Door _door;

    /// <summary>
    /// ボタンを押したらドアが開く
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _door.Open(true);
        }
    }
}
