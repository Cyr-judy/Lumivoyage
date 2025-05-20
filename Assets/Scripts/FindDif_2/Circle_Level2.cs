using UnityEngine;

public class Circle_Level2 : MonoBehaviour
{
    public bool isScoreAdded = false; // 是否已经加分

    void Start()
    {
        // 隐藏初始状态
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void ShowCircle()
    {
        // 获取物体的父物体
        Transform parentTransform = transform.parent;
        if (parentTransform != null)
        {
            // 获取父物体下的所有物体（包括自身）
            Transform[] children = parentTransform.GetComponentsInChildren<Transform>(true);
            // 输出每个子物体的名称
            foreach (Transform child in children)
            {
                if (child.gameObject.GetComponent<SpriteRenderer>() != null &&
                   child.gameObject.GetComponent<Collider2D>() != null)
                {
                    // 进行显示处理
                    child.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    // 移除掉Collider组件
                    child.gameObject.GetComponent<Collider2D>().enabled = false;
                    Debug.Log("SpriteRenderer enabled and Collider disabled for: " + child.gameObject.name);
                }
            }
        }
    }

    public bool HasScoreAdded()
    {
        return isScoreAdded;
    }
}