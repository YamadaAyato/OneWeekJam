using UnityEngine;

public class Ladder : MonoBehaviour
{
    public int Step => _step;
    public float CurrentPos => transform.position.y;

    [SerializeField] private int _step;
}
