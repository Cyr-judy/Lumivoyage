using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance; // ����ģʽ

    [Header("������������")]
    [SerializeField] private AudioSource _bgmSource;
    [SerializeField] private AudioClip _mainBGM;

    private void Awake()
    {
        // ����ģʽ��֤Ψһ��
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �糡��������
        }
        else
        {
            Destroy(gameObject); // ����Ѵ�����������ʵ��
            return;
        }

        // ��ʼ����ƵԴ
        _bgmSource.loop = true;
        PlayBGM(_mainBGM);
    }

    // ����ָ����������
    public void PlayBGM(AudioClip clip)
    {
        if (_bgmSource.clip == clip && _bgmSource.isPlaying) return;

        _bgmSource.clip = clip;
        _bgmSource.Play();
    }

    // ֹͣ��������
    public void StopBGM() => _bgmSource.Stop();
}