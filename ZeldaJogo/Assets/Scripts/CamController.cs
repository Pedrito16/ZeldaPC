using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    Camera cam;
    Transform camPos;
    [SerializeField] float roomSize;
    [SerializeField] float duration;
    void Start()
    {
        cam = Camera.main;
        camPos = Camera.main.transform;
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            camPos.SetParent(null);
            
            StartCoroutine(MoveToDesiredLocation(transform.position));
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            cam.orthographicSize = 5;
            camPos.position = Vector3.zero + Vector3.forward * -10;
            camPos.SetParent(collision.transform, false);
        }
    }
    public IEnumerator MoveToDesiredLocation(Vector3 targetPos)
    {
        cam.orthographicSize = roomSize;
        float iterador = 0;
        targetPos.z = -10;
        
        while(iterador < duration)
        {
            camPos.position = Vector3.Lerp(camPos.position, targetPos, iterador / duration);
            iterador += Time.deltaTime;
            yield return null;
        }
    }
}
