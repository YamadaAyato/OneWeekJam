using System;
using UnityEngine;
public class TeleporterSwitch : MonoBehaviour
{
    public event Action OnTeleported;
    private Animator _animator;
    private bool _teleported;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<CharacterMoverBase>(out var charactor) && !_teleported)
        {
            OnTeleported.Invoke();
            _teleported = true;
            _animator.SetBool("Push", true);
        }
    }
}