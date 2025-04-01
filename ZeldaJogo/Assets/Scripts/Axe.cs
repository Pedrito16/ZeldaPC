using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    [HideInInspector] public Splitter splitter;
     Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
        rb.velocity = Vector3.zero;
        transform.position = splitter.transform.position;
        splitter.pool.Enqueue(rb);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            gameObject.SetActive(false);
            rb.velocity = Vector3.zero;
            transform.position = splitter.transform.position;
            splitter.pool.Enqueue(rb);
        }
    }
}
