using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class StageData
{
    public int StageId => _stageId;

    [Tooltip("該当するステージのアウトラインをアサインして")]
    public Outline CurrentStageOutLine;

    [Header("インゲームの情報")]

    [Tooltip("ステージのプレファブ")]
    public GameObject StagePrefab;
    [Tooltip("プレイヤーの行動回数")]
    public int MoveCount;
    [Tooltip("ステージの番号")]
    [ReadOnly, SerializeField]
    private int _stageId;

    public int GetStageID(int value) => _stageId = value;
}