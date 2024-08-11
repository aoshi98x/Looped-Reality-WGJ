using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource audioSource;
    public AudioClip slowTickTock;
    public AudioClip fastTickTock;

    void Awake()
    {
        instance = this;
    }

    public void PlaySlowTickTock()
    {
        audioSource.clip = slowTickTock;
        audioSource.Play();
    }

    public void PlayFastTickTock()
    {
        audioSource.clip = fastTickTock;
        audioSource.Play();
    }
}
