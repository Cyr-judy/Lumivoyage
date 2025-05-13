using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuShortcut : MonoBehaviour
{
    public string levelToLoad;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnToMenu();
        }
    }

    void ReturnToMenu()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}

