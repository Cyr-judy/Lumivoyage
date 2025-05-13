using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Circle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //������ʾ����
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    public void ShowCircle()
    {
        //��ȡ����ĸ�����
        Transform parentTransform = transform.parent;
        if (parentTransform != null)
        {
            //��ȡ�������µ��������壨��������
            Transform[] children = parentTransform.GetComponentsInChildren<Transform>(true);
            //���ÿ�������������
            foreach (Transform child in children)
            {
                if (child.gameObject.GetComponent<SpriteRenderer>() != null &&
                   child.gameObject.GetComponent<Collider2D>() != null)
                {
                    //������ʾ����
                    child.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    //�Ƴ���Collider���
                    child.gameObject.GetComponent<Collider2D>().enabled = false;

                }
            }
        }
    }
}
