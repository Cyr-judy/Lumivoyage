using UnityEngine;

public class PlayerRestorer : MonoBehaviour
{
    [Header("返回场景 B 的目标位置")]
    public Vector3 positionFromB = new Vector3(72.3f, 2f, -0.7f);

    [Header("返回场景 C 的目标位置")]
    public Vector3 positionFromC = new Vector3(5.6f, 2f, 36.9f); // 你自己设定的值



    void Start()
    {
        if (SceneReturnData.source == SceneReturnData.ReturnSource.None)
        {
            Debug.Log("没有来自其他场景的返回，保持当前位置");
            return;
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogWarning("Player 未找到");
            return;
        }

        switch (SceneReturnData.source)
        {
            case SceneReturnData.ReturnSource.FromB:
                player.transform.position = positionFromB;
                Debug.Log("从 B 返回，玩家移动到：" + positionFromB);
                break;

            case SceneReturnData.ReturnSource.FromC:
                player.transform.position = positionFromC;
                Debug.Log("从 C 返回，玩家移动到：" + positionFromC);
                break;
        }

        // 重置，防止下次也触发
        SceneReturnData.source = SceneReturnData.ReturnSource.None;
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


