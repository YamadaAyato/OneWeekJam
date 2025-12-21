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
    private AudioSource _bgmPlayer;

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
        _bgmPlayer = GetComponentInChildren<AudioSource>();
    }

    /// <summary>
    /// SE再生
    /// </summary>
    /// <param name="name"></param>
    /// <param name="volume"></param>
    public void PlaySE(string name, float volume)
    {
        foreach (var se in _seList)
        {
            if (se.name == name)
            {
                GameObject sePlayer = new GameObject("SEPlayer");
                sePlayer.transform.SetParent(transform);

                var source = sePlayer.AddComponent<AudioSource>();
                source.spatialBlend = 0f;
                source.volume = volume;
                source.Play();
                Destroy(sePlayer, se.length);
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
