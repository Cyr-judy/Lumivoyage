using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIController : Singleton<UIController>
{
    public TMP_Text score;
    public int num;
    public void AddScore()
    {
        num += 1;
        score.text = num.ToString();
    }
}
