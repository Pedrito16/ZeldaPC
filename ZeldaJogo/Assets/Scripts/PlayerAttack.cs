using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : PlayerStatus
{
    [SerializeField] GameObject sword;
    Player player;
    void Start()
    {
        player = GetComponent<Player>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            sword.SetActive(true);
            sword.transform.position = player.transform.position + new Vector3(player.moveInput.x, player.moveInput.y, 0);
        }
    }
}
