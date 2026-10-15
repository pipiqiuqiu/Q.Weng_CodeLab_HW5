using System.Collections;
using UnityEditor.VersionControl;
using UnityEngine.InputSystem;
using UnityEngine;

public class followMouse : MonoBehaviour
{
    private Vector2 positionTracker;
    private Vector2 refposition = Vector2.zero;
    public float speed = 10f; 
    public float trackingSpeed = 10f; 
    [SerializeField] float waitTime = 1.0f;
    [SerializeField] private GameObject ballToSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnBall(waitTime));
    }

    IEnumerator SpawnBall(float w)
    {
        while (true)
        {
            Debug.Log("Wait");
            yield return new WaitForSeconds(waitTime);
            Instantiate(ballToSpawn, transform.position, Quaternion.identity);
            Debug.Log("Wait2s");
        }
        
    }
    
    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        FollowMouse();
    }

    void FollowMouse()
    {
        positionTracker = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        transform.position = Vector2.Lerp(transform.position,positionTracker,Time.deltaTime*speed);
        //Debug.Log(message: Mouse.current.position.ReadValue());

        transform.position = Vector2.SmoothDamp(transform.position, positionTracker, ref refposition,
            trackingSpeed);
    }
}
