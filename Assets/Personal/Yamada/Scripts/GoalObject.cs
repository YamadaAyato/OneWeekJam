using UnityEngine;

/// <summary>
///         ゴールクラス
/// </summary>
public class GoalObject : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    [SerializeField] private int _stageId;
    /// <summary> 
    ///         ゴール時の演出等をするクラス
    /// </summary>
    private void Goal()
    {
        // 演出追加予定らしい、シークエンスの最後にシーン遷移してもいいかも
        SceneLoader.LoadScene(_sceneName);
        StageProgressManager.SetStageCleared(StageDataManager.StageId);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            Goal();
    }
}
