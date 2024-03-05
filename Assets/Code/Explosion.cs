using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public Sprite explosionSprite;
    public float explosionDuration = 1.0f;
    public float explosionSizeMultiplier = 2.0f; // Adjustable size multiplier
    private Sprite originalSprite;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSprite = spriteRenderer.sprite;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            StartCoroutine(ExplodeAndRevert());
        }
    }

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

        // Optionally, you can destroy the GameObject after the explosion
        // Destroy(gameObject);
    }
}