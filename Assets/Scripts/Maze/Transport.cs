using UnityEngine;
using UnityEngine.SceneManagement;

public class Transport: MonoBehaviour
{
    public string levelToLoad;
    private bool active = true;

    void Start()
    {
        // 如果刚加载进来，短暂禁用传送器（防止一进来就触发）
        active = false;
        Invoke("EnableTrigger", 1f); // 1秒后再允许触发（你也可以用0.5f）
    }

    void EnableTrigger()
    {
        active = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!active) return;

        Debug.Log("Trigger entered by: " + other.gameObject.name);
        if (other.gameObject.tag == "Player")
        {
            PlayerPrefs.SetString("ReturnFromScene", levelToLoad);
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
