using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StarInteraction : MonoBehaviour
{
    [TextArea(1, 3)]
    public string initialDisplayText; // 初始显示的文字

    public GameObject dialogWindow; // 对话窗口
    public Text dialogText; // 对话框中的文本
    public Button confirmButton; // 确定按钮
    public Button cancelButton; // 取消按钮

    private UnityAction confirmAction; // 确定按钮的回调函数
    private UnityAction cancelAction; // 取消按钮的回调函数

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShowDialog(initialDisplayText);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HideDialog();
        }
    }

    private void ShowDialog(string text)
    {
        if (dialogWindow != null)
        {
            dialogText.text = text;
            dialogWindow.SetActive(true);
        }
    }

    private void HideDialog()
    {
        if (dialogWindow != null)
        {
            dialogWindow.SetActive(false);
        }
    }

    public void SetupConfirmButton(UnityAction action)
    {
        confirmAction = action;
        confirmButton.onClick.AddListener(() => OnConfirmClicked());
    }

    public void SetupCancelButton(UnityAction action)
    {
        cancelAction = action;
        cancelButton.onClick.AddListener(() => OnCancelClicked());
    }

    public void OnConfirmClicked()
    {
        confirmAction?.Invoke(); // 执行回调
        HideDialog();
    }

    public void OnCancelClicked()
    {
        cancelAction?.Invoke(); // 执行回调
        HideDialog();
    }
}