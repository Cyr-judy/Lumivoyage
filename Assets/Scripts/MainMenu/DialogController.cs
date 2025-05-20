using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogController : MonoBehaviour
{
    public GameObject Team;
    public GameObject Credits;
    public GameObject About;
    public string nextSceneName;

    // ��������
    public void ShowTeam()
    {
        Team.SetActive(true);
    }

    // ���ӵ���
    public void ShowCredits()
    {
        Credits.SetActive(true);
        Team.SetActive(false);
    }

    // �ر��ӵ���
    public void CloseCredits()
    {
        Credits.SetActive(false);
        Team.SetActive(true);
    }

    // �ر��������������Ҫ��
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

