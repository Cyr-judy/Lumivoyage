using UnityEngine;
using UnityEngine.UI;

public class ClosePopup : MonoBehaviour
{
    [Header("弹窗设置")]
    [Tooltip("需要控制的弹窗面板")]
    public GameObject popupPanel;

    [Tooltip("关闭弹窗的快捷键")]
    public KeyCode closeShortcut = KeyCode.Escape;

    void Update()
    {
        // 检测快捷键关闭
        if (Input.GetKeyDown(closeShortcut))
        {
            SetPopupState(false);
        }
    }

    // 公共方法供按钮调用
    public void ClosePopupPanel()
    {
        SetPopupState(false);
    }

    // 通用状态设置方法
    private void SetPopupState(bool state)
    {
        if (popupPanel != null)
        {
            popupPanel.SetActive(state);

            // 可选：切换时暂停/恢复游戏
            // Time.timeScale = state ? 0 : 1;
        }
        else
        {
            Debug.LogWarning("未指定弹窗面板！");
        }
    }
}