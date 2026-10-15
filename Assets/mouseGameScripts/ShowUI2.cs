using UnityEngine;

public class ShowUI2 : MonoBehaviour
{
    public Collider2D triggerCollider;
    public Collider2D playerCollider;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    void Update()
    {
        if (triggerCollider == null || playerCollider == null)
            return;

        if (triggerCollider.IsTouching(playerCollider))
        {
            spriteRenderer.enabled = true;
        }
    }
}