using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public string menuSceneName;

    public void ExitGame()
    {
        if (string.IsNullOrEmpty(menuSceneName))
        {
            Debug.LogError("menuSceneName is empty");
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        try
        {
            SceneManager.LoadScene(menuSceneName);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error loading scene: " + ex.Message);
        }
    }
}
