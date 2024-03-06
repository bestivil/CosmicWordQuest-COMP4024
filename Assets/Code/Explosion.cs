using System.Collections;
using UnityEngine;

/// <summary>
/// Class responsible for explosions being drawn on top of planets during collision
/// </summary>
public class Explosion : MonoBehaviour
{
    public Sprite explosionSprite;
    public float explosionDuration = 1.0f; //Duration of explosion relative to original size
    public float explosionSizeMultiplier = 2.0f; // Size of explosion relative to original size
    private Sprite originalSprite;
    private SpriteRenderer spriteRenderer;
    
    /// <summary>
    /// stores the sprite for the original planet so can get it back after explosion is over
    /// </summary>
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSprite = spriteRenderer.sprite;
    }

    /// <summary>
    /// Check if the planet object has collided with a bullet
    /// </summary>
    /// <param name="collision">Collision2D parameter used to check for its gameObject member variable</param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            StartCoroutine(ExplodeAndRevert());
        }
    }

    /// <summary>
    /// Transforms the planet into an explosion and reverts it back to its original state
    /// </summary>
    /// <returns>returns an IEnumerator for the coroutine</returns>
    IEnumerator ExplodeAndRevert()
    {
        // Store the original scale
        Vector3 originalScale = transform.localScale;

        // Set explosion sprite and adjust size
        spriteRenderer.sprite = explosionSprite;
        transform.localScale *= explosionSizeMultiplier;

        // Wait for the specified duration
        yield return new WaitForSeconds(explosionDuration);

        // Revert to the original sprite and scale
        spriteRenderer.sprite = originalSprite;
        transform.localScale = originalScale;      
    }
}