using UnityEngine;

/// <summary>
/// Class responsible for playing explosion sound when bulelt hits a planet
/// </summary>
public class ExplosionSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;
    /// <summary>
    /// sets up the AudioSource member
    /// </summary>
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    /// <summary>
    /// Plays sound if collision happens
    /// </summary>
    /// <param name="collision">Collision2D object used to check for its gameObject member</param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            audioSource.PlayOneShot(clip);
        }
    }


}
