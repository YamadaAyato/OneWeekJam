using UnityEngine;

public static class StageProgressManager : MonoBehaviour
{
    private const string CLEAR_KEY = "STAGE_CLEAR"
    public void SetStageCleared(int stageId)
    {
        PlayerPrefs.SetInt(CLEAR_KEY + stageId, 1);
        PlayerPrefs.Save();
    }
}
