using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : Singleton<UIController>
{
    public TMP_Text scoreText; // �÷��ı�
    public GameObject finishDialogPanel; // ��ɵ������
    public Text finishDialogText; // ��ɵ����ı�
    public Button nextShelfButton; // ��һ�����ܰ�ť
    public GameObject outside1; // outside1 ͼƬ���������

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
            outside1.SetActive(false); // ���� outside1 ͼƬ
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
        // ������������ӽ�����һ�ص��߼�
    }
}