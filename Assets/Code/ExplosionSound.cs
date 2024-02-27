using UnityEngine;
using UnityEngine.UI; // Use UnityEngine.UI for the Text component

public class ExplosionSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            audioSource.PlayOneShot(clip);

        }
    }


}
