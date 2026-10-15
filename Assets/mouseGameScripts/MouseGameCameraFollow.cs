using UnityEngine;

public class MouseGameCameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Collider2D ground;
    [SerializeField] private float followSpeed = 5f;

    private Camera followedCamera;

    void Awake()
    {
        followedCamera = GetComponent<Camera>();
    }

    void Start()
    {
        if (target == null)
            return;

        transform.position = GetDesiredPosition();
    }

    void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 desired = GetDesiredPosition();
        transform.position = Vector3.Lerp(transform.position, desired, Mathf.Clamp01(followSpeed * Time.deltaTime));
    }

    Vector3 GetDesiredPosition()
    {
        Vector3 desired = new Vector3(target.position.x, target.position.y, transform.position.z);
        if (ground == null || followedCamera == null || !followedCamera.orthographic)
            return desired;

        Bounds bounds = ground.bounds;
        float halfHeight = followedCamera.orthographicSize;
        float halfWidth = halfHeight * followedCamera.aspect;

        desired.x = bounds.size.x > halfWidth * 2f
            ? Mathf.Clamp(desired.x, bounds.min.x + halfWidth, bounds.max.x - halfWidth)
            : bounds.center.x;
        desired.y = bounds.size.y > halfHeight * 2f
            ? Mathf.Clamp(desired.y, bounds.min.y + halfHeight, bounds.max.y - halfHeight)
            : bounds.center.y;
        return desired;
    }
}
