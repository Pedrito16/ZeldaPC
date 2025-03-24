using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IDamageable
{
    [SerializeField] int life;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(life <= 0)
            Destroy(gameObject);
    }
    public void Damage(float damage)
    {
        life -= Mathf.RoundToInt(damage);
    }
}
