using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public TextAsset dialogDataFile;//对话文本文件，CSV格式
    public SpriteRenderer spriteLeft;//左侧角色图像
    public SpriteRenderer spriteRight;//右侧角色图像，这里为空
    public TMP_Text nameText;//角色名字文本
    public TMP_Text dialogText;//对话内容文本

    public List<Sprite> sprites = new List<Sprite>();//角色图片列表

    Dictionary<string, Sprite> imageDic = new Dictionary<string, Sprite>();//角色名字对应图片的字典

    public int dialogIndex=0;//保存当前的对话索引值
    public string[] dialogRows;//对话文本，按行分割

    public Button nextButton;
    public GameObject OptionButton;//选项按钮预制体
    public Transform ButtonGroup;//选项按钮父结点，用于自动排列

    private void Awake()
    {
        imageDic["小星"] = sprites[0];
        imageDic["收银员"] = sprites[1];
    }

    private void Start()
    {
        ReadText(dialogDataFile);
        ShowDialogRow();
        //UpdateText("x","你好");
        //UpdateImage("小星", false);
    }

    private void Update()
    {
        
    }

    public void UpdateText(string _name,string _text)//更新文本信息
    {
        nameText.text = _name;
        dialogText.text = _text;
    }

    public void UpdateImage(string _name,string _position)//更新图片信息
    {
        if(_position == "左")
        {
            spriteLeft.sprite = imageDic[_name];
        }
        else if(_position == "右")
        {
            spriteRight.sprite = imageDic[_name];
        }
    }

    public void ReadText(TextAsset _textAsset)
    {
        dialogRows = _textAsset.text.Split('\n');
        //foreach(var row in rows)
        //{
        //    string[] cell = row.Split(',');
        //}
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

                dialogIndex = int.Parse(cells[5]); //更新跳转
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
                Debug.Log("剧情结束");
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
            //绑定按钮事件
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
}
