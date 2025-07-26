using UnityEngine;

public class Audio_Controller : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource1;

    public void PlayAudioClip(AudioClip clip)
    {
        audioSource1.clip = clip;
        audioSource1.Play();
    }
}
