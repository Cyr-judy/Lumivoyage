using UnityEngine;

public class PlayerRestorer : MonoBehaviour
{
    [Header("���س��� B ��Ŀ��λ��")]
    public Vector3 positionFromB = new Vector3(73f, 2f, -0.7f);

    [Header("���س��� C ��Ŀ��λ��")]
    public Vector3 positionFromC = new Vector3(5.6f, 2f, 36.9f); // ���Լ��趨��ֵ



    void Start()
    {
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.Save();

        if (PlayerPrefs.HasKey("ReturnFromScene"))
        {
            string fromScene = PlayerPrefs.GetString("ReturnFromScene");
            Debug.Log("PlayerPrefs �� ReturnFromScene ��ֵ��: " + fromScene);
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                CharacterController cc = player.GetComponent<CharacterController>();
                if (cc != null) cc.enabled = false;

                if (fromScene == "FindDif_1")
                {
                    player.transform.position = positionFromB;
                    Debug.Log("��Ҵ� SceneB ����������λ��Ϊ: " + positionFromB);
                }
                else if (fromScene == "FindDif_2")
                {
                    player.transform.position = positionFromC;
                    Debug.Log("��Ҵ� SceneC ����������λ��Ϊ: " + positionFromC);
                }

                if (cc != null) cc.enabled = true;

                fromScene = "None";
                PlayerPrefs.DeleteKey("ReturnFromScene");
                PlayerPrefs.Save();
            }
        }

        else
        {
            Debug.Log("PlayerPrefs ��û�� ReturnFromScene �������");
        }
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


