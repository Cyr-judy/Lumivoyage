using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAbout: MonoBehaviour
{
    public GameObject About;

    // ��������
    public void ShowAbout()
    {
        About.SetActive(true);
    }


    // �ر��ӵ���
    public void CloseAbout()
    {
        About.SetActive(false);
    }
}
