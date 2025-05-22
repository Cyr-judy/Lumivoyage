using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpScene : MonoBehaviour
{
    public string nextSceneName;

    public void OnContinueButtonClicked()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}   
