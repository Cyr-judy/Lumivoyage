using UnityEngine;

public class Talkbale_homeinside : MonoBehaviour
{
    [SerializeField] private bool isEntered;
    [TextArea(1,3)]
    public string[] lines;
    [SerializeField] private bool hasName;
    public bool showSceneButtonAtEnd;
    public GameObject indicatorImage;  // �� Inspector ����ק������Ӧ�� Image
    private bool hasInteracted = false;


    void OnDialogueFinished()
    {
        hasInteracted = true;

        if (indicatorImage != null)
        {
            indicatorImage.SetActive(false); // ���� Image
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isEntered = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isEntered = false;
        }
    }
    private void Update()
    {
        if (isEntered && Input.GetKeyDown(KeyCode.Space)&&DialogueManager_homeinside.instance.dialogueBox.activeInHierarchy==false)
        {
            DialogueManager_homeinside.instance.ShowDialogue(lines,hasName, showSceneButtonAtEnd);
            OnDialogueFinished();
        }
    }
}
