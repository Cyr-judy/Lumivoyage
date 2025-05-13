using UnityEngine;
using UnityEngine.UI;

public class StarManager : MonoBehaviour
{
    public StarInteraction firstStar;
    public StarInteraction secondStar;
    public GameObject confirmToSupermarketWindow;
    public Text confirmToSupermarketText;
    public Button adviceCloseButton; // 新增的关闭按钮引用

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
            // 点击第一个星星的确定按钮时的逻辑
        });
        firstStar.SetupCancelButton(() =>
        {
            // 取消逻辑
        });
    }

    private void SetupSecondStar()
    {
        secondStar.SetupConfirmButton(() =>
        {
            if (confirmToSupermarketText != null && confirmToSupermarketWindow != null)
            {
                confirmToSupermarketText.text = "还是去便利店吧，大超市商品种类繁多，眼花缭乱的货架、色彩鲜艳的包装、此起彼伏的广播等，容易让自闭症儿童的感官系统受到过度刺激，造成信息过载，进而引发情绪崩溃等现象。便利店与大超市相比，在信息量、噪音、商品陈列等方面具有优势，更符合自闭症儿童的需求。";
                confirmToSupermarketWindow.SetActive(true);
            }
        });
        secondStar.SetupCancelButton(() =>
        {
            // 取消逻辑
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