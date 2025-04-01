using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pão : Item
{
    [SerializeField] public Player player;
    [SerializeField] AudioClip eatingSound;
    [SerializeField] int regenLife;
    [SerializeField] AudioSource eatingSource;

    void Start()
    {
        eatingSource = InventoryController.instance.audioSource;
        eatingSource.clip = eatingSound;
        regenLife = 1;
    }
    public override void Usar()
    {
        eatingSource?.Play();
        player.RegenLife(regenLife);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
