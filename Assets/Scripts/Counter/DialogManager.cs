using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public TextAsset dialogDataFile;
    public SpriteRenderer spriteLeft;
    public SpriteRenderer spriteRight;
    public SpriteRenderer spriteMid;
    public TMP_Text nameText;
    public TMP_Text dialogText;

    public List<Sprite> sprites = new List<Sprite>();

    Dictionary<string, Sprite> imageDic = new Dictionary<string, Sprite>();

    public int dialogIndex=0;
    public string[] dialogRows;

    public Button nextButton;
    public GameObject OptionButton;
    public Transform ButtonGroup;

    // 新增弹窗配置字段
    [Header("多级弹窗设置")]
    public GameObject firstPopup;    // 第一个弹窗面板
    public TMP_Text popup1Text;      // 第一个弹窗的文本
    public GameObject confirmPopup;  // 第二个弹窗面板
    public TMP_Text popup2Text;      // 第二个弹窗的文本

    [TextArea]
    public string popup1Content;    // 第一个弹窗的文字（Inspector设置）
    [TextArea]
    public string popup2Content;    // 第二个弹窗的文字（Inspector设置）

    public UnityEvent onFinalConfirm; // 最终确认回调

    private void Awake()
    {
        imageDic["小星"] = sprites[0];
        imageDic["收银员"] = sprites[1];
        imageDic["小提示"] = sprites[2];
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        ReadText(dialogDataFile);
        ShowDialogRow();
    }

    private void Update()
    {
        
    }

    public void UpdateText(string _name,string _text)
    {
        nameText.text = _name;
        dialogText.text = _text;
    }

    public void UpdateImage(string _name,string _position)
    {
        if(_position == "左")
        {
            spriteLeft.sprite = imageDic[_name];
        }
        else if(_position == "右")
        {
            spriteRight.sprite = imageDic[_name];
        }
        else spriteMid.sprite = imageDic[_name];
    }

    public void ReadText(TextAsset _textAsset)
    {
        dialogRows = _textAsset.text.Split('\n');
        Debug.Log("读取成功");
    }

    public void ShowDialogRow()
    {
        for(int i=0; i<dialogRows.Length; i++)
        {
            string[] cells = dialogRows[i].Split(',');
            if (cells[0] == "#" && int.Parse(cells[1]) == dialogIndex)
            {
                UpdateText(cells[2], cells[4]);
                UpdateImage(cells[2], cells[3]);

                dialogIndex = int.Parse(cells[5]);
                nextButton.gameObject.SetActive(true);
                break;
            }
            else if(cells[0] == "&" && int.Parse(cells[1]) == dialogIndex)
            {
                nextButton.gameObject.SetActive(false);
                GenerateOption(i);
            }
            else if(cells[0] == "END" && int.Parse(cells[1]) == dialogIndex)
            {
                ShowFirstPopup();
                break;
            }
        }
    }

    public void OnClickNext()
    {
        ShowDialogRow();
    }

    public void GenerateOption(int _index)
    {
        string[] cells = dialogRows[_index].Split(',');
        if (cells[0] == "&")
        {
            GameObject button = Instantiate(OptionButton, ButtonGroup);
            button.GetComponentInChildren<TMP_Text>().text = cells[4];
            button.GetComponent<Button>().onClick.AddListener(
                delegate { 
                    OnOptionClick(int.Parse(cells[5])); 
                }
              );
            GenerateOption(_index + 1);
        }
    }

    public void OnOptionClick(int _id)
    {
        dialogIndex = _id;
        ShowDialogRow();
        for(int i=0;i<ButtonGroup.childCount;i++)
        {
            Destroy(ButtonGroup.GetChild(i).gameObject);
        }
    }

    // 第一个弹窗显示
    void ShowFirstPopup()
    {
        firstPopup.SetActive(true);
        popup1Text.text = popup1Content;
    }

    // "我们想说"按钮点击
    public void OnWeWantToSayClick()
    {
        firstPopup.SetActive(false);
        ShowConfirmPopup();
    }

    // 显示确认弹窗
    void ShowConfirmPopup()
    {
        confirmPopup.SetActive(true);
        popup2Text.text = popup2Content;
    }

    // 最终确认
    public void OnFinalConfirm()
    {
        confirmPopup.SetActive(false);
        onFinalConfirm.Invoke();
    }
}
