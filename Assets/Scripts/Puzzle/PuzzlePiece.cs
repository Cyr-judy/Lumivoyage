using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public bool isComplete; //标记该拼图块是否已经放置到正确的位置
    private bool isDragging = false; //标记该拼图块是否正在被拖拽
    private Vector3 offset; //鼠标点击时与拼图块中心点之间的偏移量
    private Camera cam; //主摄像机，用于将屏幕坐标转换为世界坐标
    public Transform targetPosition; //拼图块的目标位置（即正确的位置）
    public float snapThreshold = 0.5f; //判断拼图块是否靠近目标位置的阈值

    void Start()
    {
        cam = Camera.main; //获取主摄像机
    }

    void OnMouseDown()//鼠标按下事件
    {
        if (isComplete)
            return; //如果拼图块已经完成，则忽略鼠标按下事件
        isDragging = true; //开始拖拽
        offset = transform.position - GetMouseWorldPosition(); //计算鼠标与拼图块的偏移量
    }

    void OnMouseUp()//鼠标松开事件
    {
        if (isComplete)
            return; //如果拼图块已经完成，则忽略鼠标松开事件
        isDragging = false; //停止拖拽
        CheckPosition(); //检查拼图块是否靠近目标位置
    }

    void Update()
    {
        if (isDragging)
        {
            transform.position = GetMouseWorldPosition() + offset; //更新拼图块的位置
        }
    }

    //获取鼠标的世界坐标
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition; //获取鼠标的屏幕坐标
        mousePoint.z = cam.WorldToScreenPoint(transform.position).z; //设置鼠标坐标的深度值
        return cam.ScreenToWorldPoint(mousePoint); //将屏幕坐标转换为世界坐标
    }

    //
    private void CheckPosition()
    {
        if (Vector3.Distance(transform.position, targetPosition.position) < snapThreshold)
        {
            transform.position = targetPosition.position; //将拼图块吸附到目标位置
            isComplete = true; //标记拼图块已完成
            PuzzleMG.instance.Check();//调用管理器方法，检查拼图是否全部完成
        }
    }
}
