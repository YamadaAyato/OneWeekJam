using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public bool IsLadder => _isLadder;
    public Ladder CurrentLadder => _currentLadder;

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
            _currentLadder =null;
        }
    }
}
