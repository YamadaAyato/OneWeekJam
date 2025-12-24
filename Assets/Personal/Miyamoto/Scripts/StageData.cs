using UnityEngine;
[System.Serializable]
public class StageData
{
    public int StageId => _stageId;
    public bool IsCleared => _isCleared;

    [Tooltip("該当するステージ")]
    public GameObject SelectStage => _selectStage;
    [ReadOnly, SerializeField]
    private GameObject _selectStage;

    [Header("インゲームの情報")]

    [Tooltip("ステージのプレファブ")]
    public GameObject StagePrefab;
    [Tooltip("プレイヤーの行動回数")]
    public int MoveCount;
    [Tooltip("ゴールしたかどうかの判定")]
    private bool _isCleared;
    [Tooltip("ステージの番号")]
    [ReadOnly, SerializeField]
    private int _stageId;

    public void SetSelectStage(GameObject stage) => _selectStage = stage;
    public void GetStageID(int value) => _stageId = value;
    public void SetCleared(bool cleared) => _isCleared = cleared;
}