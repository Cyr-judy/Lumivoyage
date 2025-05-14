using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoEndLoader : MonoBehaviour
{
    public string nextSceneName ; // �滻Ϊ���Ŀ�곡����

    void Start()
    {
        VideoPlayer vp = GetComponent<VideoPlayer>();
        vp.loopPointReached += OnVideoEnd; // ��Ƶ�����괥��
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
