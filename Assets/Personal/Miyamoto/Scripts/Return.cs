using UnityEngine;

public class Return : MonoBehaviour
{
    [SerializeField] private Transform _startPos;
    private void Awake()
    {
        AudioManager.Instance.PlayBGM("Title");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = _startPos.position;
        }
    }
}
