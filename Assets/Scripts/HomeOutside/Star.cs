using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    [TextArea(1, 3)]
    public string displayText; // 每个星星可以设置不同的文字

    public Text uiText; // 关联的UI Text组件

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
    }

    private void HideText()
    {
        if (uiText != null)
        {
            uiText.gameObject.SetActive(false);
        }
    }
}