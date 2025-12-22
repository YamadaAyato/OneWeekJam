using UnityEngine;
/// <summary>
/// ボタンを押すとドアでのテレポートが可能になる
/// </summary>
public class DoorButton : MonoBehaviour
{
    /// <summary>
    /// ドアが開いているか開いてないかの判定
    /// </summary>
    public bool isDoorOpen = false;

    /// <summary>
    /// ボタンを押したらドアが開く
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isDoorOpen = true;
        }
    }
}
