using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UIController_level2 : Singleton_level2<UIController>
{
    public TMP_Text scoreText; // 得分文本
    public GameObject finishDialogPanel; // 完成弹窗面板
    public Text finishDialogText; // 完成弹窗文本
    public Button nextShelfButton; // 下一个货架按钮

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
        if (currentScore >= 3)
        {
            ShowFinishDialog();
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
        
        UpdateDialogText("自闭症患者的大脑像一台高清显微镜，" +
            "总先捕捉细节，再拼凑全局/为了模拟这种独特的视觉体验，我们故意模糊了图片大部分区域，只保留关键细节。通过游戏，我" +
            "们希望让更多人理解：不是他们\"太较真\"，而是世界在他们眼中，本就以超清慢镜头播放。");
        UpdateButtonText("确认");
        // 可以在这里添加进入下一关的逻辑
    }

    private void UpdateDialogText(string newText)
    {
        if (finishDialogText != null)
        {
            finishDialogText.text = newText;
        }
    }

    private void UpdateButtonText(string newText)
    {
        if (nextShelfButton != null)
        {
            nextShelfButton.GetComponentInChildren<Text>().text = newText;
        }
    }
}