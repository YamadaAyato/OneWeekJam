using System;
using UnityEngine;
/// <summary>
/// 床を開け閉めするスイッチクラス
/// </summary>
public class FloorSwitch : MonoBehaviour
{
    public event Action OnCharacterEnter;
    public event Action OnCharacterLeft;

    [Tooltip("ボタン(<color=magenta>突起</color>の部分)のコライダーをアサインしてくれ")]
    [SerializeField]
    private Collider2D _buttonCollider;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<CharacterMoverBase>(out var character))
        {
            OnCharacterEnter?.Invoke();
            _animator.SetBool("Push", true);
            AudioManager.Instance.PlaySE("Switch");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<CharacterMoverBase>(out var character))
        {
            OnCharacterLeft?.Invoke();
            _animator.SetBool("Push", false);
        }
    }
}