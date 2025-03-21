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
            Vector3 rotation = Vector3.left * player.moveInput.x + Vector3.down * player.moveInput.y;
            sword.transform.rotation = Quaternion.LookRotation(Vector3.forward, rotation);
            sword.transform.position = transform.position + new Vector3(player.moveInput.x, player.moveInput.y);
        }
    }
    float GetLookingPosition()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - transform.position;
        direction = direction.normalized;
        float angulo = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return -angulo;
    }
}
