using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EspadaItem : Item
{
    Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    void Start()
    {
        image.sprite = ItemSprite;
    }

    public override void MoveToEquip(Vector3 newPos)
    {
        
    }
    
}
