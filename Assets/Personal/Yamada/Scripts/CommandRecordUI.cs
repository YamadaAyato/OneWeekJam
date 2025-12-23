using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
///         記録ターンのコマンドをUI表示するクラス
/// </summary>
public class CommandRecordUI : MonoBehaviour
{
    //[SerializeField, Tooltip("カウント表示のテキスト")] private TMP_Text _countText;
    [SerializeField, Tooltip("UIのプレハブ")] private ArrowSlotUI _slotPrefab;
    [SerializeField, Tooltip("指示の矢印の画像")] private Sprite _arrowImage;
    [SerializeField] private Transform _parentObject;

    private readonly List<ArrowSlotUI> _uiSlots = new();
    private StageManager _stageManager;
    private int _curretIndex;

    /// <summary>
    ///         方向を取得してUIに設定
    /// </summary>
    private void CommandRecord()
    {
        UpdateCount();

        if (_curretIndex < _uiSlots.Count)
        {
            DirectionType dir = GetLastCommand();
            _uiSlots[_curretIndex].SetUI(_arrowImage, GetRotation(dir));
            _curretIndex++;
        }
    }

    /// <summary>
    ///         向きなどが入っていないスロット群を作成する
    /// </summary>
    /// <param name="count"></param>
    private void CreateSlots(int count)
    {
        ClearSlots();

        // 指示がない状態の画像を生成
        for (int i = 0; i < _stageManager.MoveCount; i++)
        {
            var oneSlot = Instantiate(_slotPrefab, _parentObject);
            oneSlot.ResetArrow();
            _uiSlots.Add(oneSlot);
        }

        _curretIndex = 0;
    }

    /// <summary>
    ///         スロットをListから消去する
    /// </summary>
    private void ClearSlots()
    {
        foreach (var oneSlot in _uiSlots)
            Destroy(oneSlot.gameObject);

        _uiSlots.Clear();
    }

    /// <summary>
    ///         UIのリセット
    /// </summary>
    private void ResetUI()
    {
        CreateSlots(_stageManager.MoveCount);
        UpdateCount();
    }

    /// <summary>
    ///         MoveCountをテキストで表示
    /// </summary>
    private void UpdateCount()
    {
        // _countText.text = _stageManager.MoveCount.ToString();
    }

    /// <summary>
    ///         現状の最終命令の取得して返す
    /// </summary>
    /// <returns>Directionを返す</returns>
    private DirectionType GetLastCommand()
    {
        DirectionType last = _stageManager.CommandQueue.ElementAt(_stageManager.CommandQueue.Count - 1);
        return last;
    }

    /// <summary>
    ///         方向に対応したRotationを返す
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    private float GetRotation(DirectionType type)
    {
        return type switch
        {
            DirectionType.Up => 0f,
            DirectionType.Left => 90f,
            DirectionType.Down => 180f,
            DirectionType.Right => 270f
        };
    }

    private void Awake()
    {
        _stageManager = FindAnyObjectByType<StageManager>();

        CreateSlots(_stageManager.MoveCount);
    }

    private void OnEnable()
    {
        _stageManager.Move += CommandRecord;
        _stageManager.Reset += ResetUI;
    }

    private void OnDisable()
    {
        _stageManager.Move -= CommandRecord;
        _stageManager.Reset -= ResetUI;
    }
}
