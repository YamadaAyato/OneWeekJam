using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelector : MonoBehaviour
{
    [SerializeField] private List<StageData> _stageInfo;
    [SerializeField] private Canvas _stageCanvas;
    [SerializeField] private int _stageCount;
    private Dictionary<int, StageData> _stageDic = new Dictionary<int, StageData>();
    private int _currentIndex = 0;
    private GameObject[] _stages;
    private void Awake()
    {
        var outlines = _stageCanvas.GetComponentsInChildren<Outline>(true);
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
    /// 次のステージに移動する
    /// </summary>
    /// <param name="value">移動方向(1:次へ, -1:前へ)</param>
    private void ChangeStage(int value)
    {
        int nextIndex = _currentIndex + value;

        // インデックスが0以下にならないように
        if (nextIndex <= 0)
        {
            return;
        }

        // ページ境界のチェック
        int currentPage = (_currentIndex - 1) / _stageCount;
        int nextPage = (nextIndex - 1) / _stageCount;

        // ページが変わる場合
        if (currentPage != nextPage)
        {
            // 次のページの最初/最後のステージにジャンプ
            if (value > 0)
            {
                // 次のページの最初のステージ
                nextIndex = nextPage * _stageCount + 1;
            }
            else
            {
                // 前のページの最後のステージ
                nextIndex = currentPage * _stageCount;
            }

            ChangePage(value);
        }

        // インデックスの範囲チェック
        if (_stageDic.ContainsKey(nextIndex))
        {
            _currentIndex = nextIndex;
            UpdateStageDisplay();
        }
        else
        {
            Debug.LogWarning($"{nextIndex}番目のステージは存在しない");
        }
    }
    /// <summary>
    /// 次のステージに移動する
    /// </summary>
    /// <param name="value"></param>
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
    /// <param name="value">移動方向(1:次へ, -1:前へ)</param>
    private void ChangePage(int value)
    {
        // ページ切り替え時の処理(アニメーションなど)をここに実装
        Debug.Log($"ページ遷移: direction={value}");
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