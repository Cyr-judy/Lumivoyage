using UnityEngine;
using UnityEngine.UI;

public class StartDialogController_Level2 : MonoBehaviour
{
    public GameObject startDialogPanel; // 弹窗面板
    public Text startDialogText; // 弹窗文本
    public Button confirmButton; // 确认按钮

    private void Start()
    {
        // 显示弹窗
        ShowStartDialog();
    }

    public void ShowStartDialog()
    {
        if (startDialogPanel != null)
        {
            startDialogPanel.SetActive(true);
        }
    }

    public void ConfirmClicked()
    {
        if (startDialogPanel != null)
        {
            startDialogPanel.SetActive(false);
        }
        // 可以在这里添加开始游戏的逻辑
    }
}