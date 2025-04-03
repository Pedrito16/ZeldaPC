using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GiveDamage : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] string dontAttackName;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out IDamageable damageable))
        {
            if(collision.tag != dontAttackName)
            damageable.Damage(damage);
        }
    }
}
