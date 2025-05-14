using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public Camera mainCam;
    private Collider2D handleCollider;
    private bool isDragging = false;
    private Vector2 offset; // ��¼��������������ĵ�ƫ��

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
            // ֻ�ڰ���˲�����Ƿ�������ײ��
            if (handleCollider.OverlapPoint(mousePos))
            {
                isDragging = true;
                offset = (Vector2)transform.position - mousePos;
            }
        }

        if (isDragging)
        {
            // ��������λ�ã���ƫ��������
            transform.position = mousePos + offset;

            // �ɿ����ʱֹͣ��ק
            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
            }
        }
    }
}