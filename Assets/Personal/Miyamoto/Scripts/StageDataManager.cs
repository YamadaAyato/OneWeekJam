using UnityEngine;
/// <summary>
/// 選んだステージの情報を取得するクラス
/// </summary>
public static class StageDataManager
{
    /// <summary>ステージのID</summary>
    public static int StageId;
    /// <summary>行動回数</summary>
    public static int MoveCount;
    /// <summary>ステージプレファブ</summary>
    public static GameObject Stage;
    public static void GetStageInfo(int moveCount, GameObject stage)
    {
        MoveCount = moveCount;
        Stage = stage;
        Debug.Log($"ステージの情報を追加{stage.name}");
    }
}