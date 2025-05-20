using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public TextAsset dialogDataFile;//�Ի��ı��ļ���CSV��ʽ
    public SpriteRenderer spriteLeft;//����ɫͼ��
    public SpriteRenderer spriteRight;//�Ҳ��ɫͼ��
    public SpriteRenderer spriteMid;//�м��ɫͼ��������С��ʾ
    public TMP_Text nameText;//��ɫ�����ı�
    public TMP_Text dialogText;//�Ի������ı�

    public List<Sprite> sprites = new List<Sprite>();//��ɫͼƬ�б�

    Dictionary<string, Sprite> imageDic = new Dictionary<string, Sprite>();//��ɫ���ֶ�ӦͼƬ���ֵ�

    public int dialogIndex=0;//���浱ǰ�ĶԻ�����ֵ
    public string[] dialogRows;//�Ի��ı������зָ�

    public Button nextButton;
    public GameObject OptionButton;//ѡ�ťԤ����
    public Transform ButtonGroup;//ѡ�ť����㣬�����Զ�����

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
        imageDic["С��"] = sprites[0];
        imageDic["����Ա"] = sprites[1];
        imageDic["С��ʾ"] = sprites[2];
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        ReadText(dialogDataFile);
        ShowDialogRow();
        //UpdateText("x","���");
        //UpdateImage("С��", false);
    }

    private void Update()
    {
        
    }

    public void UpdateText(string _name,string _text)//�����ı���Ϣ
    {
        nameText.text = _name;
        dialogText.text = _text;
    }

    public void UpdateImage(string _name,string _position)//����ͼƬ��Ϣ
    {
        if(_position == "��")
        {
            spriteLeft.sprite = imageDic[_name];
        }
        else if(_position == "��")
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
        Debug.Log("��ȡ�ɹ�");
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

                dialogIndex = int.Parse(cells[5]); //������ת
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
            //�󶨰�ť�¼�
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
