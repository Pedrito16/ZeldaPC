using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morcego : PlayerStatus, IDamageable
{
    [SerializeField] float cooldownToDamagePlayer;
    [SerializeField] bool canDamagePlayer;
    [SerializeField] AudioClip damageSound;
    AudioSource source;
    Rigidbody2D rb;
    Vector2 direction;
    Transform playerTransform;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = FindObjectOfType<Player>().transform;
        source = GetComponentInChildren<AudioSource>();
        source.clip = damageSound;
    }
    void Start()
    {
        canDamagePlayer = true;
    }
    void Update()
    {
        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        if(Life <= 0 )
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        direction = playerTransform.position - transform.position;
        direction = direction.normalized;
        rb.AddForce(direction * Speed);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, 8f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable damageable) && canDamagePlayer)
        {
            if (collision.gameObject.tag != "Bat" && collision.gameObject.tag != "Slime")
            {
                StartCoroutine(CanDamagePlayer());
                damageable.Damage(1);
            }
        }
    }
    IEnumerator CanDamagePlayer()
    {
        canDamagePlayer = false;
        yield return new WaitForSeconds(cooldownToDamagePlayer);
        canDamagePlayer = true;
    }
    public void Damage(float damage)
    {
        source.Play();
        Life -= (int)damage;
    }
}
