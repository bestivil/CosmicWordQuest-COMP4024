using UnityEngine;
using UnityEngine.UI;

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
