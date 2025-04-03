using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Player : PlayerStatus, IDamageable
{
    public delegate  void TakeDamage();
    public TakeDamage takeDamage;
    
    [SerializeField] float invencibilityTime;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;
    public Vector2 moveInput;

    public bool canRegenLife;
    public bool isShielded;
    public bool isInvencible;
    public static bool isDead;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(horizontal, vertical);
        rb.velocity = moveInput * Speed;

        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
        if(Life <= 0)
        {
            isDead = true;
            gameObject.SetActive(false);
        }
    }
    IEnumerator Invencibility()
    {
        isInvencible = true;
        yield return new WaitForSeconds(invencibilityTime);
        isInvencible = false;
    }
    public void Damage(float damage)
    {
        if(!isShielded && !isInvencible)
        {
            Life -= (int)damage;
            takeDamage?.Invoke();
            StartCoroutine(Invencibility());
        }
    }
    public void RegenLife(int quantity)
    {
        Life += quantity;
        canRegenLife = true;
    }
}
