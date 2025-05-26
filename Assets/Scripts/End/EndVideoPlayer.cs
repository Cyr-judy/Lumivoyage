using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class EndVideoPlayer : MonoBehaviour
{
    public GameObject popupPanel;        // 弹窗的 Panel
    public GameObject backgroundImage;   // 背景图片
    public Button playButton;            // 弹窗中的播放按钮
    private VideoPlayer videoPlayer;

    void Start()
    {
        // 获取 VideoPlayer 组件
        videoPlayer = GetComponent<VideoPlayer>();

        // 初始状态：视频不播放，UI 显示
        popupPanel.SetActive(true);
        backgroundImage.SetActive(true);
        videoPlayer.Pause(); // 确保视频没有播放

        // 给按钮添加监听事件
        playButton.onClick.AddListener(OnPlayButtonClicked);
    }

    void OnPlayButtonClicked()
    {
        // 隐藏弹窗和背景图
        popupPanel.SetActive(false);
        backgroundImage.SetActive(false);

        // 开始播放视频
        videoPlayer.Play();
    }
}
