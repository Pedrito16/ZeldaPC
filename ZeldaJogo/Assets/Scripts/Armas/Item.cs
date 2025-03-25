using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class Item : MonoBehaviour
{
    Sprite itemSprite;
    Image itemImage;
    public Sprite ItemSprite { get => itemSprite; set => itemSprite = value; }
    public Image ItemImage { get => itemImage; set => itemImage = value; }

    public virtual void MoveToEquip(Vector3 newPos)
    {
        transform.position = newPos;
    }
    public virtual void Usar()
    {

    }
}
