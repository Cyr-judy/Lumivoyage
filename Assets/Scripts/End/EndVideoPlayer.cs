using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class EndVideoPlayer : MonoBehaviour
{
    public GameObject popupPanel;        // ������ Panel
    public GameObject backgroundImage;   // ����ͼƬ
    public Button playButton;            // �����еĲ��Ű�ť
    public GameObject quitButton;
    private VideoPlayer videoPlayer;

    void Start()
    {
        // ��ȡ VideoPlayer ���
        videoPlayer = GetComponent<VideoPlayer>();

        videoPlayer.isLooping = false;

        // ��ʼ״̬����Ƶ�����ţ�UI ��ʾ
        popupPanel.SetActive(true);
        backgroundImage.SetActive(true);
        quitButton.SetActive(false);

        videoPlayer.Pause(); // ȷ����Ƶû�в���

        // ����ť��Ӽ����¼�
        playButton.onClick.AddListener(OnPlayButtonClicked);

        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnPlayButtonClicked()
    {
        // ���ص����ͱ���ͼ
        popupPanel.SetActive(false);
        backgroundImage.SetActive(false);

        // ��ʼ������Ƶ
        videoPlayer.Play();
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // ������ɺ���ͣ����ͣ�������һ֡
        vp.Pause();
        quitButton.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
