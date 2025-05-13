using UnityEngine;

public class DragScript : MonoBehaviour
{
    public Camera mainCam;
    Collider2D handleCollider;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        handleCollider = this.gameObject.GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            if (handleCollider == Physics2D.OverlapPoint(mousePos))
            {
                this.transform.position = mousePos;
            }
            Debug.Log($"Mouse Pos: {mousePos}, Object Pos: {transform.position}");
            Debug.Log($"原始输入坐标: {Input.mousePosition}"); // 添加此行
        }
    }
}
