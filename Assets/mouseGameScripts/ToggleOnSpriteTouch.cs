using UnityEngine;

public class ToggleOnSpriteTouch : MonoBehaviour
{
    [SerializeField] private Collider2D touchingCollider;
    [SerializeField] private GameObject targetObject;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other != touchingCollider)
            return;

        if (targetObject != null)
        {
            targetObject.SetActive(!targetObject.activeSelf);
        }
    }
}