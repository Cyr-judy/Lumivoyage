using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoEndLoader : MonoBehaviour
{
    public string nextSceneName ; // 替换为你的目标场景名

    void Start()
    {
        VideoPlayer vp = GetComponent<VideoPlayer>();
        vp.loopPointReached += OnVideoEnd; // 视频播放完触发
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
