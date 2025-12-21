using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [System.Serializable]
    public class SoundData
    {
        public List<AudioClip> SeList => _seList;
        public List<AudioClip> BgmList => _bgmList;

        [SerializeField] private List<AudioClip> _seList;
        [SerializeField] private List<AudioClip> _bgmList;
    }

    private GameObject _sePlayer;
    private GameObject _bgmPlayer;
}
