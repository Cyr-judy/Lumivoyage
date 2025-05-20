// LevelController.cs
using UnityEngine;
using System.Collections.Generic;

public class LevelController_Level2 : Singleton_level2<LevelController_Level2>
{
    void Start()
    {
        Debug.Log($"�ؿ�����{levelList.Count}");
    }
   
   
    public List<GameObject> levelList;
    public int LevelIndex;

    public void NextLevel()
    {
        if (LevelIndex < levelList.Count - 1)
        {
            Debug.Log("�л���һ��");
            //�ر�ȫ���ؿ�
            foreach (var o in levelList)
            {
                o.SetActive(false);
            }
            //��ʾָ���ؿ�
            LevelIndex += 1;
            levelList[LevelIndex].SetActive(true);
        }



        else
        {

            Debug.Log("���Ѿ������ˣ�");
        }
      }
    
}