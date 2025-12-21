using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [System.Serializable]
    public class SoundData
    {
        public AudioClip Clip => _clip;
        public string Name => _name;

        [SerializeField] private AudioClip _clip;
        [SerializeField] private string _name;
    }
    [Header("プレイヤー")]
    [ReadOnly, SerializeField]private AudioSource _bgmPlayer;

    [Header("SEリスト")]
    [SerializeField] private List<SoundData> _seList;
    [Header("BGMリスト")]
    [SerializeField] private List<SoundData> _bgmList;

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
            if (se.Name == name)
            {
                GameObject sePlayer = new GameObject("SEPlayer");
                sePlayer.transform.SetParent(transform);

                var source = sePlayer.AddComponent<AudioSource>();
                source.spatialBlend = 0f;
                source.volume = volume;
                source.clip = se.Clip;
                source.Play();
                Destroy(sePlayer, se.Clip.length);
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
            if (bgm.Name == name)
            {
                _bgmPlayer.loop = true;
                _bgmPlayer.clip = bgm.Clip;
                _bgmPlayer.Play();
            }
        }
    }
}
