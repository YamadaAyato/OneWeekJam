using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///         向きを表すスロットの演出や向きの設定をするクラス
/// </summary>
public class ArrowSlotUI : MonoBehaviour
{
    [SerializeField, Tooltip("このオブジェクトのイメージコンポーネント")] private Image _image;
    [SerializeField, Tooltip("指示がない状態の空の画像")] private Sprite _emptyCommndImage;

    [Header("演出系")]
    [SerializeField] private float _effectScale;
    [SerializeField] private float _effectDuration;

    private Tween _tween;
    private Vector3 _defaultScale;

    /// <summary>
    ///        向きとイメージをリセットする
    /// </summary>
    public void ResetArrow()
    {
        transform.localScale = _defaultScale;
        _image.sprite = _emptyCommndImage;
        _image.rectTransform.rotation = Quaternion.identity;
    }

    /// <summary>
    ///         UI一つに画像と向きを設定
    /// </summary>
    /// <param name="sprite"></param>
    /// <param name="rotationZ"></param>
    public void SetUI(Sprite sprite, float rotationZ)
    {
        _image.sprite = sprite;
        _image.rectTransform.rotation = Quaternion.Euler(0, 0, rotationZ);

        PlayUIEffect();
    }

    /// <summary>
    ///         コマンドが入った時に演出を再生
    /// </summary>
    private void PlayUIEffect()
    {
        _tween?.Kill();

        _tween = DOTween.Sequence()
            .Append(transform.DOPunchScale(Vector3.one * _effectScale, _effectDuration, 8, 0.8f));
    }

    private void Awake()
    {
        _defaultScale = this.transform.localScale;
    }
}
