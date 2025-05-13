using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public TextAsset dialogDataFile;//�Ի��ı��ļ���CSV��ʽ
    public SpriteRenderer spriteLeft;//����ɫͼ��
    public SpriteRenderer spriteRight;//�Ҳ��ɫͼ������Ϊ��
    public TMP_Text nameText;//��ɫ�����ı�
    public TMP_Text dialogText;//�Ի������ı�

    public List<Sprite> sprites = new List<Sprite>();//��ɫͼƬ�б�

    Dictionary<string, Sprite> imageDic = new Dictionary<string, Sprite>();//��ɫ���ֶ�ӦͼƬ���ֵ�

    public int dialogIndex=0;//���浱ǰ�ĶԻ�����ֵ
    public string[] dialogRows;//�Ի��ı������зָ�

    public Button nextButton;
    public GameObject OptionButton;//ѡ�ťԤ����
    public Transform ButtonGroup;//ѡ�ť����㣬�����Զ�����

    private void Awake()
    {
        imageDic["С��"] = sprites[0];
        imageDic["����Ա"] = sprites[1];
    }

    private void Start()
    {
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
                Debug.Log("�������");
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
}
