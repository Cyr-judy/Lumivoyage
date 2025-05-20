using UnityEngine;
using UnityEngine.UI;

public class StartDialogController_Level2 : MonoBehaviour
{
    public GameObject startDialogPanel; // �������
    public Text startDialogText; // �����ı�
    public Button confirmButton; // ȷ�ϰ�ť

    private void Start()
    {
        // ��ʾ����
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
        // ������������ӿ�ʼ��Ϸ���߼�
    }
}