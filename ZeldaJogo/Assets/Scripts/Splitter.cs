using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Splitter : PlayerStatus    
{
    [SerializeField] float maxDistance;
    [SerializeField] Transform playerTransform;
    float distance;
    void Start()
    {
        
    }
    void Update()
    {
        if(playerTransform != null) 
            transform.position = Vector3.Lerp(transform.position, playerTransform.position, Time.deltaTime / Speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            playerTransform = collision.transform;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, maxDistance);
    }
}
