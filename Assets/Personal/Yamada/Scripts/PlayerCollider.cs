using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    /// <summary>
    ///         梯子上にいるか
    /// </summary>
    public bool IsLadder => _isLadder;

    /// <summary>
    ///         地面の上にいるか
    /// </summary>
    public bool IsGrounded => _isGrouded;

    /// <summary>
    ///         現在位置している梯子を返す
    /// </summary>
    public Ladder CurrentLadder => _currentLadder;

    [SerializeField] private float _rayDistance;
    [SerializeField] private LayerMask _layerMask;

    private bool _isLadder;
    private bool _isGrouded;
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

    private void Update()
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.down, _rayDistance, _layerMask))
        {
            _isGrouded = true;
        }
        else
        {
            _isGrouded = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _isGrouded ? Color.green : Color.red;
        Gizmos.DrawLine(this.transform.position
            , this.transform.position + Vector3.down * _rayDistance
            );
    }
}
