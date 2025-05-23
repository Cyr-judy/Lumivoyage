using UnityEngine;

public class MultiStageButton : MonoBehaviour
{
    private int clickCount = 0;

    public UIController_level2 uiController;      // 从 Inspector 拖拽引用
    public JumpScene jumpScene;            // 从 Inspector 拖拽引用

    public void HandleClick()
    {
        clickCount++;

        if (clickCount == 1)
        {
            uiController.ConfirmNextShelf();
        }
        else if (clickCount == 2)
        {
            jumpScene.OnContinueButtonClicked();
        }
    }
}

