using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ドアを管理するManager
/// </summary>
public class DoorManager : MonoBehaviour
{
    [Header("ドアのリスト")]
    [SerializeField] private List<GameObject> _doorList = new List<GameObject>();

    /// <summary>
    ///Open状態になったら呼ばれる
    /// </summary>
    public void CallOpen()
    {
        foreach (GameObject door in _doorList)
        {
            door.GetComponent<Door>().Open();
        }
    }

    /// <summary>
    /// Closeする時に呼ぶ
    /// </summary>
    public void CallClose()
    {
        foreach (GameObject door in _doorList)
        {
            door.GetComponent<Door>().Close();
        }
    }
}
