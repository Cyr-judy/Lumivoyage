using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent (typeof (AudioSource))]

public class MainMenuBtns : MonoBehaviour
{
    public string levelToLoad;
    public AudioClip beep;

    private AudioSource audioSource;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Debug.Log("MainMenuBtns script has started.");
        audioSource = GetComponent<AudioSource>(); // 获取 AudioSource 组件
    }

    public void LoadGame()
    {
        Debug.Log("Load Game Button Clicked");
        StartCoroutine(Music());
        SceneManager.LoadScene(levelToLoad);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game Button Clicked");
        StartCoroutine(Music());
        Application.Quit();
    }

    IEnumerator Music()
    {
        audioSource.PlayOneShot(beep);
        yield return new WaitForSeconds(0.35f);
    }
}