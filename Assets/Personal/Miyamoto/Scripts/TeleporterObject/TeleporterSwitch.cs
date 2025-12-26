using System;
using UnityEngine;
public class TeleporterSwitch : MonoBehaviour
{
    public event Action OnTeleported;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<CharacterMoverBase>(out var charactor))
        {
            OnTeleported.Invoke();
        }
    }
}