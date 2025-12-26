using UnityEngine;

/// <summary>
///         その場に召喚し、時間がたったら消去
/// </summary>
public class WalkEffect : MonoBehaviour
{
    [SerializeField] private float _lifeTime;
    [SerializeField]private SpriteRenderer _spriteRenderer;

    /// <summary>
    ///         向きを変更
    /// </summary>
    /// <param name="flipX"></param>
    public void SetFlip(bool flipX)
    {
        _spriteRenderer.flipX = flipX;
    }

    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }
}
