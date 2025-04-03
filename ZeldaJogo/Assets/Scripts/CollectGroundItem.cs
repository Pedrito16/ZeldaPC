using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGroundItem : MonoBehaviour
{
    [SerializeField] GameObject inventoryItem;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Transform slotTransform = InventoryController.instance.FindAvailableSlot();
        if (collision.gameObject.tag == "Player" && slotTransform != null)
        {
            GameObject item = Instantiate(inventoryItem);
            item.transform.SetParent(slotTransform, false);
            Destroy(gameObject);
        }
    }
}
