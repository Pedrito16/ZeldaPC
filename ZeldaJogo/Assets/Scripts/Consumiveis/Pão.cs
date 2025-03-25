using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pão : Consumivel
{
    [SerializeField] Player player;
    [SerializeField] AudioClip eatingSound;
    AudioSource eatingSource;
    void Start()
    {
        eatingSource = GetComponentInChildren<AudioSource>();
        eatingSource.clip = eatingSound;
        player = FindObjectOfType<Player>();
        RegenLife = 1;
    }
    public override void Consumir()
    {
        eatingSource?.Play();
        player.Vida += RegenLife;
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
