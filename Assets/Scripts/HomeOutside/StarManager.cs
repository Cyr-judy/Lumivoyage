using UnityEngine;
using UnityEngine.UI;

public class StarManager : MonoBehaviour
{
    public StarInteraction firstStar;
    public StarInteraction secondStar;
    public GameObject confirmToSupermarketWindow;
    public Text confirmToSupermarketText;
    public Button adviceCloseButton; // �����Ĺرհ�ť����

    private void Start()
    {
        SetupFirstStar();
        SetupSecondStar();
        SetupAdviceCloseButton();
    }

    private void SetupFirstStar()
    {
        firstStar.SetupConfirmButton(() =>
        {
            // �����һ�����ǵ�ȷ����ťʱ���߼�
        });
        firstStar.SetupCancelButton(() =>
        {
            // ȡ���߼�
        });
    }

    private void SetupSecondStar()
    {
        secondStar.SetupConfirmButton(() =>
        {
            if (confirmToSupermarketText != null && confirmToSupermarketWindow != null)
            {
                confirmToSupermarketText.text = "����ȥ������ɣ�������Ʒ���෱�࣬�ۻ����ҵĻ��ܡ�ɫ�����޵İ�װ������˷��Ĺ㲥�ȣ��������Ա�֢��ͯ�ĸй�ϵͳ�ܵ����ȴ̼��������Ϣ���أ����������������������󡣱������������ȣ�����Ϣ������������Ʒ���еȷ���������ƣ��������Ա�֢��ͯ������";
                confirmToSupermarketWindow.SetActive(true);
            }
        });
        secondStar.SetupCancelButton(() =>
        {
            // ȡ���߼�
        });
    }

    private void SetupAdviceCloseButton()
    {
        if (adviceCloseButton != null)
        {
            adviceCloseButton.onClick.AddListener(() =>
            {
                if (confirmToSupermarketWindow != null)
                {
                    confirmToSupermarketWindow.SetActive(false);
                }
            });
        }
    }
}