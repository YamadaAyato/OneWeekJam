using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class StageSelector : MonoBehaviour
{
    [SerializeField] private List<StageData> _stageInfo;
    [SerializeField] private Canvas _stageCanvas;
    [SerializeField] private int _stageCount;
    [SerializeField] private Ease _stageAnimEase;
    [SerializeField] private float _stageAnimMaxSize;
    [SerializeField] private float _stageAnimDuration;
    private Dictionary<int, StageData> _stageDic = new Dictionary<int, StageData>();
    private int _currentIndex = 0;
    private Tween _stageTween;
    private Transform _prevStage;

    private void Awake()
    {
        var outlines = _stageCanvas.GetComponentsInChildren<Outline>();
        for (int i = 0; i < _stageInfo.Count; i++)
        {
            _stageInfo[i].GetStageID(i + 1);
            _stageInfo[i].SetSelectStage(outlines[i].gameObject);
        }
        foreach (var stage in _stageInfo)
        {
            if (stage == null)
            {
                Debug.Log($"ステージの情報がないよ");
            }
            _stageDic.Add(stage.StageId, stage);
        }
        _currentIndex = 1;
        UpdateStageDisplay();
        PlayStageAnim(_stageDic[_currentIndex].SelectStage.transform);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            ChangeStage(-3);
        else if (Input.GetKeyDown(KeyCode.A))
            ChangeStage(-1);
        else if (Input.GetKeyDown(KeyCode.S))
            ChangeStage(3);
        else if (Input.GetKeyDown(KeyCode.D))
            ChangeStage(1);
        else if (Input.GetKeyDown(KeyCode.Space))
            EnterStage(_currentIndex);
    }
    /// <summary>
    /// ステージアニメーションを再生する
    /// </summary>
    /// <param name="target"></param>
    private void PlayStageAnim(Transform target)
    {
        ResetPrevStage();

        _prevStage = target;
        target.localScale = Vector3.one;

        _stageTween = target
            .DOScale(_stageAnimMaxSize, _stageAnimDuration)
            .SetEase(_stageAnimEase)
            .SetLoops(-1, LoopType.Yoyo);
    }
    /// <summary>
    /// 前のステージがあれば元に戻す
    /// </summary>
    private void ResetPrevStage()
    {
        if (_stageTween != null && _stageTween.IsActive())
        {
            _stageTween.Kill();
            _stageTween = null;
        }

        if (_prevStage != null)
        {
            _prevStage.localScale = Vector3.one;
            _prevStage = null;
        }
    }

    /// <summary>
    /// 次のステージに移動する
    /// </summary>
    /// <param name="value">移動方向(正の数:次へ, 負の数:前へ)</param>
    private void ChangeStage(int value)
    {
        int nextIndex = _currentIndex + value;

        if (nextIndex <= 0)
            return;

        // ページ境界チェック
        int currentPage = (_currentIndex - 1) / _stageCount;
        int nextPage = (nextIndex - 1) / _stageCount;

        if (currentPage != nextPage)
        {
            if (value > 0)
                nextIndex = nextPage * _stageCount + 1;
            else
                nextIndex = currentPage * _stageCount;

            ChangePage(value);
        }

        if (!_stageDic.ContainsKey(nextIndex))
        {
            Debug.LogWarning($"{nextIndex}番目のステージは存在しない");
            return;
        }

        _currentIndex = nextIndex;

        var nextStage = _stageDic[_currentIndex].SelectStage.transform;
        PlayStageAnim(nextStage);
        UpdateStageDisplay();
    }
    /// <summary>
    /// ステージの表示を更新する
    /// </summary>
    private void UpdateStageDisplay()
    {
        // 全てのステージのアウトラインを消す
        foreach (var s in _stageInfo)
        {
            if (s.SelectStage != null)
            {
                s.SelectStage.GetComponent<Outline>().enabled = false;
            }
        }

        // 現在のステージのアウトラインだけ有効にする
        if (_stageDic.TryGetValue(_currentIndex, out var stage))
        {
            if (stage.SelectStage.GetComponent<Outline>() != null)
            {
                stage.SelectStage.GetComponent<Outline>().enabled = true;
            }
            Debug.Log($"現在のステージ: {_currentIndex}");
        }
    }
    /// <summary>
    ///　ページの遷移
    /// </summary>
    /// <param name="value">移動方向(正の数:次へ, 負の数:前へ)</param>
    private void ChangePage(int value)
    {
        // ページ切り替え時の処理(アニメーションなど)をここに実装
        Debug.Log($"ページ遷移:{value}");
    }
    /// <summary>
    /// ステージに入る
    /// </summary>
    /// <param name="index"></param>
    private void EnterStage(int index)
    {
        StageDataManager.GetStageInfo(_stageDic[index].MoveCount, _stageDic[index].StagePrefab);
        //SceneLoader(Stage);
    }
}