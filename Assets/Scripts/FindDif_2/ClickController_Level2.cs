using UnityEngine;

public class ClickController_Level2 : MonoBehaviour
{
    void Update()
    {
        // ��������
        if (Input.GetMouseButtonDown(0))
        {
            // ����һ�������λ�����µ�����
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            // ��������Ƿ���ײ����2D��ײ��
            if (hit.collider != null)
            {
                // �����ײ���������
                Debug.Log("Hit object: " + hit.collider.gameObject.name);

                // �����ײ���Ķ����� Circle ����
                Circle_Level2 circle = hit.collider.gameObject.GetComponent<Circle_Level2>();
                if (circle != null)
                {
                    // ���� Circle �� ShowCircle ����
                    circle.ShowCircle();

                    // ����Ƿ��Ѿ��ӷ�
                    if (!circle.HasScoreAdded())
                    {
                        // ���ӷ���
                        UIController.Instance.AddScore(1);
                        circle.isScoreAdded = true; // ����Ѿ��ӷ�
                    }
                }
            }
        }
    }
}