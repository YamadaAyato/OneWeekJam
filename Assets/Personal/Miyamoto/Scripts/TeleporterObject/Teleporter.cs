using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField]
    [Tooltip("移動先のテレポーターオブジェクト")]
    private Teleporter _destination;
    private Animator _animator;
    private TeleporterSwitch _teleporterSwitch;
    private bool _isActive = true;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _teleporterSwitch = FindAnyObjectByType<TeleporterSwitch>();
    }
    private void OnEnable()
    {
        _teleporterSwitch.OnTeleported += ReSpwanTeleportor;
    }
    private void OnDisable()
    {
        _teleporterSwitch.OnTeleported -= ReSpwanTeleportor;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_isActive) return;

        if (collision.gameObject.TryGetComponent<CharacterMoverBase>(out var charactor))
        {
            Debug.Log("Charが入ってきた");
            charactor.ForceStop();
            charactor.transform.position = _destination.transform.position;
            TeleportedProcces();
        }
    }
    /// <summary>
    /// テレポートした時の処理
    /// </summary>
    private void TeleportedProcces()
    {
        Debug.Log("てれぽーとしたときのしょり");
        _animator.SetBool("Teleport", true);
        _destination._animator.SetBool("Teleport", true);
        _isActive = false;
        _destination._isActive = false;
    }
    /// <summary>
    /// テレポートのリスポーン処理
    /// </summary>
    public void ReSpwanTeleportor()
    {
        _isActive = true;
        _animator.SetBool("Teleport", false);
    }
}
