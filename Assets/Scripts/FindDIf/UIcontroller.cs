using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : Singleton<UIController>
{
    public TMP_Text scoreText; // 得分文本
    public GameObject finishDialogPanel; // 完成弹窗面板
    public Text finishDialogText; // 完成弹窗文本
    public Button nextShelfButton; // 下一个货架按钮
    public GameObject outside1; // outside1 图片对象的引用

    private int currentScore = 0; // 当前得分

    private void Start()
    {
        // 初始化得分
        scoreText.text = currentScore.ToString();
    }

    public void AddScore(int scoreToAdd = 1)
    {
        currentScore += scoreToAdd;
        scoreText.text = currentScore.ToString();
        Debug.Log("Current score: " + currentScore);

        // 检查是否达到目标分数
        if (currentScore >= 2)
        {
            HideOutside1();
            ShowFinishDialog();
        }
    }

    public void HideOutside1()
    {
        if (outside1 != null)
        {
            outside1.SetActive(false); // 隐藏 outside1 图片
        }
    }

    public void ShowFinishDialog()
    {
        if (finishDialogPanel != null)
        {
            finishDialogPanel.SetActive(true);
        }
    }

    public void ConfirmNextShelf()
    {
        if (finishDialogPanel != null)
        {
            finishDialogPanel.SetActive(false);
        }
        // 可以在这里添加进入下一关的逻辑
    }
}