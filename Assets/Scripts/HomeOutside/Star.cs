using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    [TextArea(1, 3)]
    public string displayText; // ÿ�����ǿ������ò�ͬ������

    public Text uiText; // ������UI Text���
    public GameObject uiPanel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShowText();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HideText();
        }
    }

    private void ShowText()
    {
        if (uiText != null)
        {
            uiText.text = displayText;
            uiText.gameObject.SetActive(true);
        }

        if (uiPanel != null)
        {
            uiPanel.SetActive(true); // ��ʾ Panel
        }
    }

    private void HideText()
    {
        if (uiText != null )
        {
            uiText.gameObject.SetActive(false);
        }

        if (uiPanel != null)
        {
            uiPanel.SetActive(false); // ���� Panel
        }
    }
}