using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AudioManager : Singleton<AudioManager>
{
    [Header("Audio Source")]
    [SerializeField] private AudioSource musicSource;

    [Space]
    [Header("Audio in Game")]
    [SerializeField] private AudioClip musicBG;

    protected override void Awake()
    {
        base.KeepAlive(false); // Không giữ qua các scene, có thể thay bằng true nếu muốn
        base.Awake();
    }

    void Start()
    {
        SetMuteMusic();
        PlayMusicBG(); // Tự động phát nhạc nền khi scene bắt đầu
    }

    public void SetMuteMusic()
    {
        // Tạm thời bỏ qua UIController nếu chưa có, luôn bật nhạc
        // if (UIController.Instance != null && UIController.Instance.UISetting != null && UIController.Instance.UISetting.IsMuteMusic)
        // {
        //     musicSource.mute = true;
        //     return;
        // }
        musicSource.mute = false; // Mặc định bật nhạc
    }

    public void PlayMusicBG()
    {
        if (!musicSource.isPlaying && musicBG != null)
        {
            musicSource.clip = musicBG;
            musicSource.DOFade(1f, 0.5f).OnPlay(() =>
            {
                musicSource.Play();
            }).SetUpdate(true);
        }
    }

    public void StopMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.DOFade(0f, 0.5f).OnComplete(() =>
            {
                musicSource.Stop();
            }).SetUpdate(true);
        }
    }
}