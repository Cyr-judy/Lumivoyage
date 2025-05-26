using UnityEngine;

public class EscRestore : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.HasKey("PlayerPosX") && PlayerPrefs.HasKey("PlayerPosY") && PlayerPrefs.HasKey("PlayerPosZ"))
        {
            float x = PlayerPrefs.GetFloat("PlayerPosX");
            float y = PlayerPrefs.GetFloat("PlayerPosY");
            float z = PlayerPrefs.GetFloat("PlayerPosZ");

            float x_rot = PlayerPrefs.GetFloat("PlayerRotX");
            float y_rot = PlayerPrefs.GetFloat("PlayerRotY");
            float z_rot = PlayerPrefs.GetFloat("PlayerRotZ");


            Vector3 savedPosition = new Vector3(x, y, z);
            Vector3 savedRotation = new Vector3(x_rot, y_rot, z_rot);

            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                player.transform.position = savedPosition;
                player.transform.rotation = Quaternion.Euler(savedRotation);
                Debug.Log("Restored player position to: " + savedPosition);
                Debug.Log("Restored player rotation to: " + savedRotation);
            }

            // 清除保存的玩家位置
            PlayerPrefs.DeleteKey("PlayerPosX");
            PlayerPrefs.DeleteKey("PlayerPosY");
            PlayerPrefs.DeleteKey("PlayerPosZ");
            PlayerPrefs.DeleteKey("PlayerRotX");
            PlayerPrefs.DeleteKey("PlayerRotY");
            PlayerPrefs.DeleteKey("PlayerRotZ");
        }
    }
}
