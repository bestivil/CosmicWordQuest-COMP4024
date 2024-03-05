using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public Sprite explosionSprite;
    public float explosionDuration = 1.0f; //Duration of explosion relative to original size
    public float explosionSizeMultiplier = 2.0f; // Size of explosion relative to original size
    private Sprite originalSprite;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSprite = spriteRenderer.sprite;
    }

    // Check if the object has collided with a bullet
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            StartCoroutine(ExplodeAndRevert());
        }
    }

    // Transforms the planet into an explosion and reverts it back to its original state
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