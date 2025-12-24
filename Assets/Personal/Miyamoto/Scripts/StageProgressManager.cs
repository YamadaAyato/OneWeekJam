using UnityEngine;

public static class StageProgressManager : MonoBehaviour
{
    private const string CLEAR_KEY = "STAGE_CLEAR"
    /// <summary>
    ///クリア情報をセーブする
    /// </summary>
    /// <param name="stageId"></param>
    public void SetStageCleared(int stageId)
    {
        PlayerPrefs.SetInt(CLEAR_KEY + stageId, 1);
        PlayerPrefs.Save();
    }
    public bool IsStageCleared(int stageId)
    {
        return PlayerPrefs.GetInt(CLEAR_KEY + stageId, 0) == 1;
    }
}
