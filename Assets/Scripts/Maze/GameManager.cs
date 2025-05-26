using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuShortcut : MonoBehaviour
{
    public string levelToLoad;
    private bool isSaving = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isSaving)
        {
            StartCoroutine(ReturnToMenuCoroutine());
        }
    }

    void ReturnToMenu()
    {
        if (isSaving) return;

        isSaving = true;

        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            //GameState.savedPlayerPosition = player.transform.position;
            PlayerPrefs.SetFloat("PlayerPosX", player.transform.position.x);
            PlayerPrefs.SetFloat("PlayerPosY", player.transform.position.y);
            PlayerPrefs.SetFloat("PlayerPosZ", player.transform.position.z);

            Vector3 euler = player.transform.eulerAngles;
            PlayerPrefs.SetFloat("PlayerRotX", euler.x);
            PlayerPrefs.SetFloat("PlayerRotY", euler.y);
            PlayerPrefs.SetFloat("PlayerRotZ", euler.z);

            PlayerPrefs.Save();
        }

        Invoke("LoadScene", 0.1f);
    }

    IEnumerator ReturnToMenuCoroutine()
    {
        isSaving = true;

        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            PlayerPrefs.SetFloat("PlayerPosX", player.transform.position.x);
            PlayerPrefs.SetFloat("PlayerPosY", player.transform.position.y);
            PlayerPrefs.SetFloat("PlayerPosZ", player.transform.position.z);

            Vector3 euler = player.transform.eulerAngles;
            PlayerPrefs.SetFloat("PlayerRotX", euler.x);
            PlayerPrefs.SetFloat("PlayerRotY", euler.y);
            PlayerPrefs.SetFloat("PlayerRotZ", euler.z);

            PlayerPrefs.Save();
            Debug.Log("Saved player position and rotation");
        }

        // 等待 0.2 秒确保写入完成
        yield return new WaitForSeconds(0.2f);

        SceneManager.LoadScene(levelToLoad);
    }
}
