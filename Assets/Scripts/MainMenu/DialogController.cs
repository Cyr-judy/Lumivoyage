using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogController : MonoBehaviour
{
    public GameObject Team;
    public GameObject Credits;
    public GameObject About;
    public string nextSceneName;

    // 打开主弹窗
    public void ShowTeam()
    {
        Team.SetActive(true);
    }

    // 打开子弹窗
    public void ShowCredits()
    {
        Credits.SetActive(true);
        Team.SetActive(false);
    }

    // 关闭子弹窗
    public void CloseCredits()
    {
        Credits.SetActive(false);
        Team.SetActive(true);
    }

    // 关闭主弹窗（如果需要）
    public void CloseTeam()
    {
        Team.SetActive(false);
    }

    public void ShowAbout()
    {
        About.SetActive(true);
    }

    public void CloseAbout()
    {
        About.SetActive(false);
    }

    public void OnContinueButtonClicked()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}

