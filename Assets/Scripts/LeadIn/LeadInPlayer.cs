using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LeadInPlayer : MonoBehaviour
{
    public GameObject continueButton;  // 在 Inspector 中拖入按钮对象
    public string nextSceneName;

    private VideoPlayer vp;

    void Start()
    {
        vp = GetComponent<VideoPlayer>();
        vp.loopPointReached += OnVideoEnd;
        continueButton.SetActive(false); // 初始隐藏按钮
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        vp.Pause(); // 停在最后一帧
        continueButton.SetActive(true); // 显示按钮
    }

    // 可挂在按钮 OnClick 事件上
    public void OnContinueButtonClicked()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}

