using UnityEngine;
using UnityEngine.SceneManagement;

public class Transport: MonoBehaviour
{
    public string levelToLoad;
    private bool active = true;

    void Start()
    {
        // ����ռ��ؽ��������ݽ��ô���������ֹһ�����ʹ�����
        active = false;
        Invoke("EnableTrigger", 1f); // 1���������������Ҳ������0.5f��
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
