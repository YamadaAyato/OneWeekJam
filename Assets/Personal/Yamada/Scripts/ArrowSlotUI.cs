using UnityEngine;
using UnityEngine.UI;

public class ArrowSlotUI : MonoBehaviour
{
    [SerializeField, Tooltip("このオブジェクトのイメージコンポーネント")] private Image _image;
    [SerializeField, Tooltip("指示がない状態の空の画像")] private Sprite _emptyCommndImage;
    private Vector3 _defaultScale;

    public void ResetArrow()
    {
        transform.localScale = _defaultScale;
        _image.sprite = _emptyCommndImage;
        _image.rectTransform.rotation = Quaternion.identity;
    }

    public void SetUI(Sprite sprite,float rotationZ)
    {
        _image.sprite = sprite;
        _image.rectTransform.rotation = Quaternion.Euler(0, 0, rotationZ);

        PlayUIEffect();
    }

    private void PlayUIEffect()
    {
        // 演出再生、多分DOTween
    }

    private void Awake()
    {
        _defaultScale = this.transform.localScale;
    }
}
