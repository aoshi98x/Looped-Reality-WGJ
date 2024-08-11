using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance {get; private set;}

    public AudioSource audioSource;
    public AudioClip slowTickTock;
    public AudioClip fastTickTock;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void PlaySlowTickTock()
    {
        audioSource.pitch = 0.85f;
        /*audioSource.clip = slowTickTock;
        audioSource.Play();*/
    }

    public void PlayFastTickTock()
    {
        audioSource.pitch = 1f;
        /*audioSource.clip = fastTickTock;
        audioSource.Play();*/
    }
}
