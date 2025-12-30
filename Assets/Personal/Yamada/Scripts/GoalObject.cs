using UnityEngine;

/// <summary>
///         ゴールクラス
/// </summary>
public class GoalObject : MonoBehaviour
{
    private GoalTimelineController _goalController;

    private void Start()
    {
        _goalController = FindAnyObjectByType<GoalTimelineController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _goalController.Play(collision.gameObject);
        }
    }
}
