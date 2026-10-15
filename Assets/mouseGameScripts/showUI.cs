using UnityEngine;

public class showUI : MonoBehaviour
{
    public SpriteRenderer targetSprite;
    public AudioSource audioSource;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (targetSprite != null)
                targetSprite.enabled = true;

            if (audioSource != null)
                audioSource.Play();

            Destroy(gameObject);
        }
    }
}
