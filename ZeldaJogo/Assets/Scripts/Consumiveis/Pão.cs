using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pão : Item
{
    [SerializeField] Player player;
    [SerializeField] AudioClip eatingSound;
    [SerializeField] int regenLife;
    [SerializeField] AudioSource eatingSource;

    void Start()
    {
        eatingSource.clip = eatingSound;
        player = FindObjectOfType<Player>();
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
