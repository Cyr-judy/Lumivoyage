using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickControllor : MonoBehaviour
{

    void Update()
    {
        //检测鼠标点击
        if (Input.GetMouseButtonDown(0))
        {
            //创建一条从鼠标位置向下的射线（因为2D中Y轴指向上，所以方向是向下）
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            //检测射线是否碰撞到了2D碰撞器
            if (hit.collider != null)
            {
                //输出碰撞物体的名称
                Debug.Log("Hit object:" + hit.collider.gameObject.name);
                if (hit.collider.gameObject.GetComponent<Circle>() != null)
                {
                    hit.collider.gameObject.GetComponent<Circle>().ShowCircle();
                    //加分
                    UIController.Instance.AddScore();

                }
            }
        }
    }
}
