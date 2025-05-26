using UnityEngine;

public class PlayerRestorer : MonoBehaviour
{
    [Header("返回场景 B 的目标位置")]
    public Vector3 positionFromB = new Vector3(73f, 2f, -0.7f);

    [Header("返回场景 C 的目标位置")]
    public Vector3 positionFromC = new Vector3(5.6f, 2f, 36.9f); // 你自己设定的值



    void Start()
    {
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.Save();

        if (PlayerPrefs.HasKey("ReturnFromScene"))
        {
            string fromScene = PlayerPrefs.GetString("ReturnFromScene");
            Debug.Log("PlayerPrefs 中 ReturnFromScene 的值是: " + fromScene);
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                CharacterController cc = player.GetComponent<CharacterController>();
                if (cc != null) cc.enabled = false;

                if (fromScene == "FindDif_1")
                {
                    player.transform.position = positionFromB;
                    Debug.Log("玩家从 SceneB 回来，设置位置为: " + positionFromB);
                }
                else if (fromScene == "FindDif_2")
                {
                    player.transform.position = positionFromC;
                    Debug.Log("玩家从 SceneC 回来，设置位置为: " + positionFromC);
                }

                if (cc != null) cc.enabled = true;

                fromScene = "None";
                PlayerPrefs.DeleteKey("ReturnFromScene");
                PlayerPrefs.Save();
            }
        }

        else
        {
            Debug.Log("PlayerPrefs 中没有 ReturnFromScene 这个键。");
        }
    }
}


public static class SceneReturnData
{
    public enum ReturnSource
    {
        None,
        FromB,
        FromC
    }

    public static ReturnSource source = ReturnSource.None;
}


