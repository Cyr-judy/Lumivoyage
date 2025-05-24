using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance; // 单例模式

    [Header("背景音乐设置")]
    [SerializeField] private AudioSource _bgmSource;
    [SerializeField] private AudioClip _mainBGM;

    private void Awake()
    {
        // 单例模式保证唯一性
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 跨场景不销毁
        }
        else
        {
            Destroy(gameObject); // 如果已存在则销毁新实例
            return;
        }

        // 初始化音频源
        _bgmSource.loop = true;
        PlayBGM(_mainBGM);
    }

    // 播放指定背景音乐
    public void PlayBGM(AudioClip clip)
    {
        if (_bgmSource.clip == clip && _bgmSource.isPlaying) return;

        _bgmSource.clip = clip;
        _bgmSource.Play();
    }

    // 停止背景音乐
    public void StopBGM() => _bgmSource.Stop();
}