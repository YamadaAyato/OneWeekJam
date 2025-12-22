using UnityEngine;
using UnityEngine.UI;
public class StageData
{
    [Tooltip("該当するステージのアウトラインをアサインして")]
    public Outline CurrentStageOutLine;

    [Header("インゲームの情報")]
    public GameObject StagePrefab;
    public int MoveCount;
    public int Index;
}