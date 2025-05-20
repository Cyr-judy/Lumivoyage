using UnityEngine;

public class Talkbale_homeinside : MonoBehaviour
{
    [SerializeField] private bool isEntered;
    [TextArea(1,3)]
    public string[] lines;
    [SerializeField] private bool hasName;
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
            DialogueManager_homeinside.instance.ShowDialogue(lines,hasName);
        }
    }
}
