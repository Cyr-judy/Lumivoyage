using UnityEngine;
using UnityEngine.SceneManagement;

public class Transport: MonoBehaviour
{
    public string levelToLoad;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.gameObject.name);
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
