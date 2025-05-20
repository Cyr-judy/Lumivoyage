using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UIController_level2 : Singleton_level2<UIController>
{
    public TMP_Text scoreText; // �÷��ı�
    public GameObject finishDialogPanel; // ��ɵ������
    public Text finishDialogText; // ��ɵ����ı�
    public Button nextShelfButton; // ��һ�����ܰ�ť

    private int currentScore = 0; // ��ǰ�÷�

    private void Start()
    {
        // ��ʼ���÷�
        scoreText.text = currentScore.ToString();
    }

    public void AddScore(int scoreToAdd = 1)
    {
        currentScore += scoreToAdd;
        scoreText.text = currentScore.ToString();
        Debug.Log("Current score: " + currentScore);

        // ����Ƿ�ﵽĿ�����
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
        
        UpdateDialogText("�Ա�֢���ߵĴ�����һ̨������΢����" +
            "���Ȳ�׽ϸ�ڣ���ƴ��ȫ��/Ϊ��ģ�����ֶ��ص��Ӿ����飬���ǹ���ģ����ͼƬ�󲿷�����ֻ�����ؼ�ϸ�ڡ�ͨ����Ϸ����" +
            "��ϣ���ø�������⣺��������\"̫����\"�������������������У������Գ�������ͷ���š�");
        UpdateButtonText("ȷ��");
        // ������������ӽ�����һ�ص��߼�
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