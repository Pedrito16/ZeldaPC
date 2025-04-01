using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGroundItem : MonoBehaviour
{
    [SerializeField] float velocidade;
    [SerializeField] GameObject inventoryItem;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*float animation = Mathf.Sin(Time.deltaTime * Mathf.PI * velocidade) * 0.1f;
        transform.position = transform.position + new Vector3(0, animation);*/
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Transform slotTransform = InventoryController.instance.FindAvailableSlot();
        if (collision.gameObject.tag == "Player" && slotTransform != null)
        {
            GameObject item = Instantiate(inventoryItem);
            item.transform.SetParent(slotTransform, false);
            Pão bread = inventoryItem.GetComponent<Pão>();
            bread.player = collision.gameObject.GetComponent<Player>();
            Destroy(gameObject);
        }
    }
}
