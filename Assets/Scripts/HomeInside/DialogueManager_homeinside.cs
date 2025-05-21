using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager_homeinside:MonoBehaviour
{
    public static DialogueManager_homeinside instance;
    public GameObject dialogueBox;
    //public Image character;
    public Text dialogueText,nameText;
    //public Sprite momSprite;    // ����charactormom��Sprite
    // public Sprite starSprite;   // ����charactorstar��Sprite

    public Button nextSceneButton;
    public string NextSceneName;
    private bool isWaitingForSceneButton = false;
    private bool shouldShowSceneButtonForThisDialogue = false;


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
        //DontDestroyOnLoad(gameObject);
    }
    public void Start()
    {
        dialogueText.text = dialogueLines[currentLine];
        nextSceneButton.gameObject.SetActive(false); 
        nextSceneButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(NextSceneName); 
        });
    }

    private void Update()
    {
        if (dialogueBox.activeInHierarchy)
        {
            if (dialogueBox == null || !dialogueBox.activeInHierarchy)
                return;

            if (Input.GetMouseButtonUp(0))
            {
                if (isScrolling == false)
                {

                    if (currentLine == dialogueLines.Length - 1 && shouldShowSceneButtonForThisDialogue)
                    {
                        if (!isWaitingForSceneButton)
                        {
                            // ��һ�ε����һ�У���ʾ��ť
                            isWaitingForSceneButton = true;
                            nextSceneButton.gameObject.SetActive(true);
                        }
                        else
                        {
                            // �Ѿ���ʾ��ť�ˣ�˵���û�����˱� �� �رնԻ���
                            dialogueBox.SetActive(false);
                            FindObjectOfType<PlayerMovement_homeinside>().canMove = true;
                            isWaitingForSceneButton = false;
                            nextSceneButton.gameObject.SetActive(false);
                        }

                        return; // ���ټ����� currentLine
                    }
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
    public void ShowDialogue(string[] _newLines,bool _hasName,bool showSceneButtonAtEnd)
    {
        dialogueLines = _newLines;
        currentLine = 0;
        shouldShowSceneButtonForThisDialogue = showSceneButtonAtEnd;

        CheckName();

        //dialogueText.text = dialogueLines[currentLine];
        StartCoroutine(ScrollingText());
        dialogueBox.SetActive(true);

        nameText.gameObject.SetActive(_hasName);

        FindObjectOfType<PlayerMovement_homeinside>().canMove = false;

        isWaitingForSceneButton = false;
        nextSceneButton.gameObject.SetActive(false);

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
