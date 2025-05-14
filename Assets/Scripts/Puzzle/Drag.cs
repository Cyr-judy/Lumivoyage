using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public Camera mainCam;
    private Collider2D handleCollider;
    private bool isDragging = false;
    private Vector2 offset; // 记录点击点与物体中心的偏移

    void Start()
    {
        handleCollider = GetComponent<Collider2D>();
        if (mainCam == null) mainCam = Camera.main;
    }

    private void Update()
    {
        Vector2 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            // 只在按下瞬间检测是否点击到碰撞体
            if (handleCollider.OverlapPoint(mousePos))
            {
                isDragging = true;
                offset = (Vector2)transform.position - mousePos;
            }
        }

        if (isDragging)
        {
            // 持续更新位置（带偏移修正）
            transform.position = mousePos + offset;

            // 松开鼠标时停止拖拽
            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
            }
        }
    }
}