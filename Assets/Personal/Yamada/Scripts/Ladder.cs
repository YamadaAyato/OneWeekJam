using UnityEngine;

/// <summary>
///         梯子の情報クラス
/// </summary>
public class Ladder : MonoBehaviour
{
    public int Step => _step;
    public float CurrentPos => transform.position.y;

    [SerializeField] private int _step;
}
