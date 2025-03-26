using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EspadaItem : Item
{
    [SerializeField] Image image;
    [SerializeField] Transform[] equippedSlots;
    [SerializeField] bool isEquipped;
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    void Start()
    {
        
    }

    public override void Usar()
    {
        if(!isEquipped)
        {
            if (equippedSlots[0].childCount <= 0)
            {
                transform.SetParent(equippedSlots[0], false);
                isEquipped = true;
            }
        }
        else if(isEquipped)
        {
            
            if (InventoryController.instance.FindAvailableSlot() != null)
            {
                isEquipped = false;
                transform.SetParent(InventoryController.instance.FindAvailableSlot(), false);
            }
        }
    }
}
