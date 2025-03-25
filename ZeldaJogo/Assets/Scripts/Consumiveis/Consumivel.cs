using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Consumivel : MonoBehaviour
{
    private int regenLife;

    
    public int RegenLife { get => regenLife; set => regenLife = value; }
    public virtual void Consumir()
    {
        
    }
}
