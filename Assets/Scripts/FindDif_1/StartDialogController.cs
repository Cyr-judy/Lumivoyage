using UnityEngine;
using UnityEngine.UI;

public class StartDialogController : MonoBehaviour
{
    public GameObject startDialogPanel; // �������
    public Text startDialogText; // �����ı�
    public Button confirmButton; // ȷ�ϰ�ť

    private void Start()
    {
        // ��ʾ����
        ShowStartDialog();
        SceneReturnData.source = SceneReturnData.ReturnSource.FromB;
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