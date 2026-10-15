using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public float speed = 10f;

    private Camera mainCamera;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (mainCamera == null || Mouse.current == null)
            return;

        Cursor.visible = false;

        float depth = transform.position.z - mainCamera.transform.position.z;
        Vector2 mouse = Mouse.current.position.ReadValue();
        Vector3 target = mainCamera.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, depth));
        target.z = transform.position.z;

        Vector3 next = Vector3.Lerp(transform.position, target, Mathf.Clamp01(speed * Time.deltaTime));
        Collider2D[] hits = Physics2D.OverlapPointAll(next);
        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("ground"))
            {
                transform.position = next;
                break;
            }
        }
    }
}
