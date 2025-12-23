using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class CommandRecordUI : MonoBehaviour
{
    //[SerializeField, Tooltip("カウント表示のテキスト")] private TMP_Text _countText;
    [SerializeField, Tooltip("UIのプレハブ")] private ArrowSlotUI _slotPrefab;
    [SerializeField, Tooltip("指示の矢印の画像")] private Sprite _arrowImage;
    [SerializeField] private Transform _parentObject;

    private readonly List<ArrowSlotUI> _uiSlots = new();
    private StageManager _stageManager;
    private int _curretIndex;

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

    private void ClearSlots()
    {
        foreach (var oneSlot in _uiSlots)
            Destroy(oneSlot.gameObject);

        _uiSlots.Clear();
    }

    private void ResetUI()
    {
        CreateSlots(_stageManager.MoveCount);
        UpdateCount();
    }

    private void UpdateCount()
    {
        // _countText.text = _stageManager.MoveCount.ToString();
    }

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
