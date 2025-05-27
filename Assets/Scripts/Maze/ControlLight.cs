using UnityEngine;

public class ControlLight: MonoBehaviour
{
    //public GameObject ControlCube;
    public GameObject PointLight;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // �����������Ļ����
        Cursor.visible = false;

        PointLight.SetActive(false);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.gameObject.name);
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            PointLight.SetActive(true);
        }
    }
}
