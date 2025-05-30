using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class EndVideoPlayer : MonoBehaviour
{
    public GameObject popupPanel;        // 弹窗的 Panel
    public GameObject backgroundImage;   // 背景图片
    public Button playButton;            // 弹窗中的播放按钮
    public GameObject quitButton;
    private VideoPlayer videoPlayer;

    void Start()
    {
        // 获取 VideoPlayer 组件
        videoPlayer = GetComponent<VideoPlayer>();

        videoPlayer.isLooping = false;

        // 初始状态：视频不播放，UI 显示
        popupPanel.SetActive(true);
        backgroundImage.SetActive(true);
        quitButton.SetActive(false);

        videoPlayer.Pause(); // 确保视频没有播放

        // 给按钮添加监听事件
        playButton.onClick.AddListener(OnPlayButtonClicked);

        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnPlayButtonClicked()
    {
        // 隐藏弹窗和背景图
        popupPanel.SetActive(false);
        backgroundImage.SetActive(false);

        // 开始播放视频
        videoPlayer.Play();
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // 播放完成后暂停，以停留在最后一帧
        vp.Pause();
        quitButton.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
