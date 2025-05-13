using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                //���Դӳ������ҵ��Ѵ��ڵ�ʵ��
                instance = FindAnyObjectByType<T>();
                //��������в����ڸ�ʵ�����򴴽�һ���µ�ʵ��
                if (Instance == null)
                {
                    GameObject obj = new GameObject(typeof(T).Name);
                    instance = obj.AddComponent<T>();
                }
            }

            return instance;
        }
    }

    //��ʵ��������ʱ����
    protected virtual void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
}