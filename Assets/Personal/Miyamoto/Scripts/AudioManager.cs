using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [System.Serializable]
    public class SoundData
    {
        public AudioClip Se => _se;
        public AudioClip Bgm=> _bgm;

        [SerializeField] private AudioClip _se;
        [SerializeField] private AudioClip _bgm;
    }

    [SerializeField] private List<AudioClip> _seList;
    [SerializeField] private List<AudioClip> _bgmList;

    private AudioSource _sePlayer;
    private AudioSource _bgmPlayer;

    public void SEPlay(string name)
    {
        foreach (var se in _seList)
        {
            if (se.name == name)
            {
                _sePlayer.PlayOneShot(se);
            }
        }
    }
}
