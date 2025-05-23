using UnityEngine;

public class PlayerRestorer : MonoBehaviour
{
    [Header("���س��� B ��Ŀ��λ��")]
    public Vector3 positionFromB = new Vector3(72.3f, 2f, -0.7f);

    [Header("���س��� C ��Ŀ��λ��")]
    public Vector3 positionFromC = new Vector3(5.6f, 2f, 36.9f); // ���Լ��趨��ֵ



    void Start()
    {
        if (SceneReturnData.source == SceneReturnData.ReturnSource.None)
        {
            Debug.Log("û���������������ķ��أ����ֵ�ǰλ��");
            return;
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogWarning("Player δ�ҵ�");
            return;
        }

        switch (SceneReturnData.source)
        {
            case SceneReturnData.ReturnSource.FromB:
                player.transform.position = positionFromB;
                Debug.Log("�� B ���أ�����ƶ�����" + positionFromB);
                break;

            case SceneReturnData.ReturnSource.FromC:
                player.transform.position = positionFromC;
                Debug.Log("�� C ���أ�����ƶ�����" + positionFromC);
                break;
        }

        // ���ã���ֹ�´�Ҳ����
        SceneReturnData.source = SceneReturnData.ReturnSource.None;
    }
}


public static class SceneReturnData
{
    public enum ReturnSource
    {
        None,
        FromB,
        FromC
    }

    public static ReturnSource source = ReturnSource.None;
}


