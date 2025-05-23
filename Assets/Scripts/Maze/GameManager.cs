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
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            GameState.savedPlayerPosition = player.transform.position;
            Debug.Log("Saved player position: " + GameState.savedPlayerPosition);
        }


        SceneManager.LoadScene(levelToLoad);
    }
}


public static class GameState
{
    public static Vector3? savedPlayerPosition = null;
}

