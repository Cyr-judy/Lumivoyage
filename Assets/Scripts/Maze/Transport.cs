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
            // 保存位置和朝向
            PlayerReturnData.savedPosition = other.transform.position;
            PlayerReturnData.forwardDirection = other.transform.forward;

            Debug.Log("Saving position: " + other.transform.position);

            PlayerReturnData.hasData = true;

            SceneManager.LoadScene(levelToLoad);
        }
    }
}

public static class PlayerReturnData
{
    public static Vector3 savedPosition;
    public static Vector3 forwardDirection;
    public static bool hasData = false;
}
