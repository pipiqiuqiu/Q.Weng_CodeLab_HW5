using UnityEngine;
using UnityEngine.EventSystems;

public class mouseInteraction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject ballToSpawn;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse Enter!");
        Debug.Log("Entered:" + gameObject.name);
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        Instantiate(ballToSpawn, transform.position, Quaternion.identity);
    }
}
