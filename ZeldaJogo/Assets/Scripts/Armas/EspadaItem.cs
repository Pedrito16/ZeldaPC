using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EspadaItem : Item
{
    [SerializeField] Image image;
    [SerializeField] Transform equippedSlot;
    [SerializeField] bool isEquipped;
    private void Awake()
    {
        
        image = GetComponent<Image>();
    }
    void Start()
    {
        equippedSlot = InventoryController.instance.weaponSlot;
    }

    public override void Usar()
    {
        if(!isEquipped)
        {
            if (equippedSlot.childCount <= 0)
            {
                transform.SetParent(equippedSlot, false);
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
