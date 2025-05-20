// LevelController.cs
using UnityEngine;
using System.Collections.Generic;

public class LevelController_Level2 : Singleton_level2<LevelController_Level2>
{
    void Start()
    {
        Debug.Log($"关卡数：{levelList.Count}");
    }
   
   
    public List<GameObject> levelList;
    public int LevelIndex;

    public void NextLevel()
    {
        if (LevelIndex < levelList.Count - 1)
        {
            Debug.Log("切换下一关");
            //关闭全部关卡
            foreach (var o in levelList)
            {
                o.SetActive(false);
            }
            //显示指定关卡
            LevelIndex += 1;
            levelList[LevelIndex].SetActive(true);
        }



        else
        {

            Debug.Log("你已经买完了！");
        }
      }
    
}