using Unity.VisualScripting;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource source;
    private bool isPlayer = false;
    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void OnMouseDown()
    {
        isPlayer = !isPlayer;
        if (isPlayer) source.Play();
        else source.Pause();
    }
}
