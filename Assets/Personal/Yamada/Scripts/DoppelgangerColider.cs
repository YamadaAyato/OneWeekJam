using UnityEngine;

/// <summary>
///         ドッペルゲンガーのコライダーを管理するクラス
/// </summary>
public class DoppelgangerColider : MonoBehaviour
{
    private bool _isLadder;
    private Ladder _currentLadder;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            _isLadder = true;
            _currentLadder = collision.gameObject.GetComponent<Ladder>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            _isLadder = false;
            _currentLadder = null;
        }
    }
}
