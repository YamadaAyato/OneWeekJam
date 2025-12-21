using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [System.Serializable]
    public class SoundData
    {
        public AudioClip Se => _se;
        public AudioClip Bgm=> _bgm;

        [SerializeField] private AudioClip _se;
        [SerializeField] private AudioClip _bgm;
    }
    [Header("プレイヤー")]
    [SerializeField] private AudioSource _sePlayer;
    [SerializeField] private AudioSource _bgmPlayer;

    [Header("SEリスト")]
    [SerializeField] private List<AudioClip> _seList;
    [Header("BGMリスト")]
    [SerializeField] private List<AudioClip> _bgmList;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    /// <summary>
    /// SE再生
    /// </summary>
    /// <param name="name"></param>
    public void PlaySE(string name)
    {
        if (_sePlayer == null) return;

        foreach (var se in _seList)
        {
            if (se.name == name)
            {
                _sePlayer.PlayOneShot(se);
            }
        }
    }
    /// <summary>
    /// BGM再生(ループ)
    /// </summary>
    /// <param name="name"></param>
    public void PlayBGM(string name)
    {
        foreach (var bgm in _bgmList)
        {
            if (bgm.name == name)
            {
                _bgmPlayer.loop = true;
                _bgmPlayer.clip = bgm;
                _bgmPlayer.Play();
            }
        }
    }
}
