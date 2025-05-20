using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager_homeinside:MonoBehaviour
{
    public static DialogueManager_homeinside instance;
    public GameObject dialogueBox;
    //public Image character;
    public Text dialogueText,nameText;
    //public Sprite momSprite;    // 拖入charactormom的Sprite
   // public Sprite starSprite;   // 拖入charactorstar的Sprite

    [TextArea(1, 3)]
    public string []dialogueLines;
    [SerializeField] public int currentLine;

    private bool isScrolling;
    [SerializeField] private float textSpeed;
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }
    public void Start()
    {
        dialogueText.text = dialogueLines[currentLine];
    }

    private void Update()
    {
        if (dialogueBox.activeInHierarchy)
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (isScrolling == false)
                {
                    currentLine += 1;
                    if (currentLine < dialogueLines.Length)
                    {
                        CheckName();
                        //dialogueText.text = dialogueLines[currentLine];
                        StartCoroutine(ScrollingText());
                    }
                    else
                    {
                        dialogueBox.SetActive(false);
                        FindObjectOfType<PlayerMovement_homeinside>().canMove = true;
                    }
                }
            }
            
        }
    }
    public void ShowDialogue(string[] _newLines,bool _hasName)
    {
        dialogueLines = _newLines;
        currentLine = 0;

        CheckName();

        //dialogueText.text = dialogueLines[currentLine];
        StartCoroutine(ScrollingText());
        dialogueBox.SetActive(true);

        nameText.gameObject.SetActive(_hasName);

        FindObjectOfType<PlayerMovement_homeinside>().canMove = false;

    }
    private void CheckName()
    {
        if (dialogueLines[currentLine].StartsWith("n-"))
        {
            nameText.text = dialogueLines[currentLine].Replace("n-","");
            currentLine++;
        }
    }
    private IEnumerator ScrollingText()
    {
        isScrolling = true;
        dialogueText.text = "";

        foreach(char letter in dialogueLines[currentLine].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
        isScrolling = false;
    }
}
