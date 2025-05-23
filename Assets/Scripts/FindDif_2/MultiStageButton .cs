using UnityEngine;

public class MultiStageButton : MonoBehaviour
{
    private int clickCount = 0;

    public UIController_level2 uiController;      // �� Inspector ��ק����
    public JumpScene jumpScene;            // �� Inspector ��ק����

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

