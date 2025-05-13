using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickControllor : MonoBehaviour
{

    void Update()
    {
        //��������
        if (Input.GetMouseButtonDown(0))
        {
            //����һ�������λ�����µ����ߣ���Ϊ2D��Y��ָ���ϣ����Է��������£�
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            //��������Ƿ���ײ����2D��ײ��
            if (hit.collider != null)
            {
                //�����ײ���������
                Debug.Log("Hit object:" + hit.collider.gameObject.name);
                if (hit.collider.gameObject.GetComponent<Circle>() != null)
                {
                    hit.collider.gameObject.GetComponent<Circle>().ShowCircle();
                    //�ӷ�
                    UIController.Instance.AddScore();

                }
            }
        }
    }
}
