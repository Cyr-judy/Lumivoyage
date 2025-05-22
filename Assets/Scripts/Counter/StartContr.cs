using UnityEngine;
using UnityEngine.UI;

public class ClosePopup : MonoBehaviour
{
    [Header("��������")]
    [Tooltip("��Ҫ���Ƶĵ������")]
    public GameObject popupPanel;

    [Tooltip("�رյ����Ŀ�ݼ�")]
    public KeyCode closeShortcut = KeyCode.Escape;

    void Update()
    {
        // ����ݼ��ر�
        if (Input.GetKeyDown(closeShortcut))
        {
            SetPopupState(false);
        }
    }

    // ������������ť����
    public void ClosePopupPanel()
    {
        SetPopupState(false);
    }

    // ͨ��״̬���÷���
    private void SetPopupState(bool state)
    {
        if (popupPanel != null)
        {
            popupPanel.SetActive(state);

            // ��ѡ���л�ʱ��ͣ/�ָ���Ϸ
            // Time.timeScale = state ? 0 : 1;
        }
        else
        {
            Debug.LogWarning("δָ��������壡");
        }
    }
}