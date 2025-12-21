using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [System.Serializable]
    public class SoundData
    {
        [SerializeField] private List<AudioClip> _seList;
        [SerializeField] private List<AudioClip> _bgmList;
    }
}
