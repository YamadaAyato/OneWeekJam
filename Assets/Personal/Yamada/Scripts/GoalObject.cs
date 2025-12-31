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
            
            // 演出的にゴールを消してプレイヤーをゴール位置に移動
            this.gameObject.SetActive(false);
            //collision.transform.position = this.transform.position;
        }
    }
}
