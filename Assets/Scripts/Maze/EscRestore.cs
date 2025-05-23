using UnityEngine;

public class EscRestore : MonoBehaviour
{
    void Start()
    {
        if (GameState.savedPlayerPosition.HasValue)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                player.transform.position = GameState.savedPlayerPosition.Value;
                Debug.Log("Restored player position to: " + GameState.savedPlayerPosition.Value);
            }

            // 清空保存的位置，避免下次错误还原
            GameState.savedPlayerPosition = null;
        }
    }
}
