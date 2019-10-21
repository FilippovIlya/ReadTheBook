

using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Collider2D))]
public class Goal : MonoBehaviour
{
    private AudioSource audioSrc;

    void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        audioSrc.Play();
        other.gameObject.GetComponent<PlayerProgress>().curLife=0f;
        
    }
}
