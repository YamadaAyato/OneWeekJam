using UnityEngine;

public class TitleGoalObj : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneLoader.LoadScene(_sceneName);
        }
    }
}
