using UnityEditor;
using UnityEngine;
public static class PlayerPrefsEditor
{
    [MenuItem("Tools/PlayerPrefs/Reset")]
    public static void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("ステージの情報を全部リセット");
    }
}
