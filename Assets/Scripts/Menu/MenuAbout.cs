using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAbout: MonoBehaviour
{
    public GameObject About;

    // 打开主弹窗
    public void ShowAbout()
    {
        About.SetActive(true);
    }


    // 关闭子弹窗
    public void CloseAbout()
    {
        About.SetActive(false);
    }
}
