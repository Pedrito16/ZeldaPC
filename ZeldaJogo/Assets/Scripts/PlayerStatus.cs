using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerStatus : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int vida;
    [SerializeField] float damage;
    public float Speed { get => speed; set => speed = value; }
    public int Vida { get => vida; set => vida = value; }
    public float Damage { get => damage; set => damage = value; }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
