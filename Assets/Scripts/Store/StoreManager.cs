using UnityEngine;
using UnityEngine.SceneManagement;

public class StoreManager : MonoBehaviour
{
    public GameObject Panel;
    public GameObject NextScene;
    public GameObject Hint;
    public string nextSceneName;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Panel.SetActive(true); 
        }
    }

    public void ShowNestScene()
    {
        Hint.SetActive(false);
        NextScene.SetActive(true);
        Panel.SetActive(false);
    }

    public void ShowHint()
    {
        Hint.SetActive(true);
        Panel.SetActive(false);
    }

    public void OnContinueButtonClicked()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}

