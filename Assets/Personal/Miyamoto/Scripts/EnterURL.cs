using UnityEngine;

public class EnterURL : MonoBehaviour
{
    public void URL(string url)
    {
        Application.OpenURL(url);
    }
}
