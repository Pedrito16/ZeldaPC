using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pão : Item
{
    [SerializeField] Player player;
    [SerializeField] AudioClip eatingSound;
    [SerializeField] int regenLife;
    AudioSource eatingSource;

    void Start()
    {
        eatingSource = GetComponentInChildren<AudioSource>();
        eatingSource.clip = eatingSound;
        player = FindObjectOfType<Player>();
        regenLife = 1;
    }
    public override void Usar()
    {
        eatingSource?.Play();
        player.Vida += regenLife;
        Invoke("Destroy", 1.75f);
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
