using UnityEngine;

public class Circle : MonoBehaviour
{
    public bool isScoreAdded = false; // �Ƿ��Ѿ��ӷ�

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // ���س�ʼ״̬
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void ShowCircle()
    {
       
        // ��ȡ����ĸ�����
        Transform parentTransform = transform.parent;
        if (parentTransform != null)
        {
            // ��ȡ�������µ��������壨��������
            Transform[] children = parentTransform.GetComponentsInChildren<Transform>(true);
            // ���ÿ�������������
            foreach (Transform child in children)
            {
                if (child.gameObject.GetComponent<SpriteRenderer>() != null &&
                   child.gameObject.GetComponent<Collider2D>() != null)
                {
                    // ������ʾ����
                    child.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    // �Ƴ���Collider���
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