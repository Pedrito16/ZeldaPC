using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerStatus : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int vida;
    public float Speed { get => speed; set => speed = value; }
    public int Life { get => vida; set => vida = value; }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
