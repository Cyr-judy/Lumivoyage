using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndEvent : MonoBehaviour
{
    public GameObject HomeToPuzzle;
    public GameObject About;
    public GameObject Canvas;
    public GameObject PuzzleToRoad;

    private void Start()
    {
        HomeToPuzzle.SetActive(true);
    }

    public void CloseHomeToPuzzle()
    {
        HomeToPuzzle.SetActive(false);
    }

    // 打开主弹窗
    public void ShowAbout()
    {
        About.SetActive(true);
        Canvas.SetActive(false);
    }


    // 关闭子弹窗
    public void CloseAbout()
    {
        About.SetActive(false);
        PuzzleToRoad.SetActive(true);
    }
}
