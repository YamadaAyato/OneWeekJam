using UnityEngine;

public static class StageProgressManager
{
    private const string CLEAR_KEY = "STAGE_CLEAR";
    /// <summary>
    ///クリア情報をセーブする
    /// </summary>
    /// <param name="stageId"></param>
    public static void SetStageCleared(int stageId)
    {
        PlayerPrefs.SetInt(CLEAR_KEY + stageId, 1);
        PlayerPrefs.Save();
    }
    /// <summary>
    /// ステージがクリアされているかどうか判断する
    /// </summary>
    /// <param name="stageId"></param>
    /// <returns></returns>
    public static bool IsStageCleared(int stageId)
    {
        return PlayerPrefs.GetInt(CLEAR_KEY + stageId, 0) == 1;
    }
}