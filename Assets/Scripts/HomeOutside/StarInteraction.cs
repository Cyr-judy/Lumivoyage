using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StarInteraction : MonoBehaviour
{
    [TextArea(1, 3)]
    public string initialDisplayText; // ��ʼ��ʾ������

    public GameObject dialogWindow; // �Ի�����
    public Text dialogText; // �Ի����е��ı�
    public Button confirmButton; // ȷ����ť
    public Button cancelButton; // ȡ����ť

    private UnityAction confirmAction; // ȷ����ť�Ļص�����
    private UnityAction cancelAction; // ȡ����ť�Ļص�����

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
        confirmAction?.Invoke(); // ִ�лص�
        HideDialog();
    }

    public void OnCancelClicked()
    {
        cancelAction?.Invoke(); // ִ�лص�
        HideDialog();
    }
}