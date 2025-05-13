using UnityEngine;
using UnityEngine.Events;

public class Talkable : MonoBehaviour
{
    [System.Serializable]
    public class TriggerEvent : UnityEvent<bool> { }

    [SerializeField] private bool isEntered;

    [TextArea(1, 3)]
    public string[] lines;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isEntered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isEntered = false;
        }
    }
}