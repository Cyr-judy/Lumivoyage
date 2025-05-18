using UnityEngine;

public class ClickController : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        // 检测鼠标点击
        if (Input.GetMouseButtonDown(0))
        {
            // 创建一条从鼠标位置向下的射线
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            // 检测射线是否碰撞到了2D碰撞器
            if (hit.collider != null)
            {
                // 输出碰撞物体的名称
                Debug.Log("Hit object: " + hit.collider.gameObject.name);

                // 如果碰撞到的对象是 Circle 类型
                Circle circle = hit.collider.gameObject.GetComponent<Circle>();
                if (circle != null)
                {
                    // 调用 Circle 的 ShowCircle 方法
                    circle.ShowCircle();

                    // 检查是否已经加分
                    if (!circle.HasScoreAdded())
                    {
                        // 增加分数
                        UIController.Instance.AddScore(1);
                        circle.isScoreAdded = true; // 标记已经加分
                    }
                }
            }
        }
    }
}