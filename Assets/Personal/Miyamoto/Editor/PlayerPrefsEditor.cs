using UnityEditor;
using UnityEngine;
public static class PlayerPrefsEditor
{
    [MenuItem("Tools/PlayerPrefs/Reset")]
    public static void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("<color=red>ステージの情報を全部リセット</color>");
    }
}