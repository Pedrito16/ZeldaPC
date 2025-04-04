using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splitter : PlayerStatus, IDamageable
{
    [Header("Essentials")]
    [SerializeField] GameObject projectile;
    [SerializeField] float maxTime;
    [Tooltip("Time for each shoot")]
    public Queue<Rigidbody2D> pool = new Queue<Rigidbody2D>();

    [Header("Configs")]
    [SerializeField] int maxObjectsPool;
    [SerializeField] float projectileSpeed;
    [SerializeField] float distanceShoot;
    [SerializeField] AudioClip damageSound;
    
    [Header("Optional")]
    [SerializeField] GameObject item;

    [Header("Debug")]
    [SerializeField] AudioSource source;
    [SerializeField] Transform playerTransform;
    [SerializeField] float timer;
    
    //variaveis invisiveis
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Vector3 direction;
    void Awake()
    {
        source = GetComponentInChildren<AudioSource>();
        source.clip = damageSound;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerTransform = FindObjectOfType<Player>().transform;
        direction = playerTransform.position;
        direction = direction.normalized;
    }
    void Start()
    {
        for(int i = 0; i < maxObjectsPool; i++)
        {
            GameObject projetil = Instantiate(projectile);
            projetil.transform.SetParent(transform);
            projetil.SetActive(false);
            projetil.GetComponent<Axe>().splitter = this;
            pool.Enqueue(projetil.GetComponent<Rigidbody2D>());
        }
    }
    void Update()
    {
        float distance = transform.position.x - playerTransform.position.x;
        if ( distance > 0) 
            spriteRenderer.flipX = true;
        else if(distance < 0)
            spriteRenderer.flipX = false;

        timer += Time.deltaTime;
        if (timer >= maxTime)
        {
            
            ShootPlayerPos();
            timer = 0;
        }
        
        if (Life <= 0)
        {
            DropItemOnDeath();
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        direction = playerTransform.position - transform.position;
        direction = direction.normalized;
        if (Vector2.Distance(transform.position, playerTransform.position) > 0.5f)
        {
            rb.velocity = direction * Speed;
            //rb.AddForce(direction * Speed);
            //rb.velocity = Vector2.ClampMagnitude(rb.velocity, 5f);
        }
        else
            rb.velocity = Vector2.zero;
    }
    #region ShootDirection
    void ShootPlayerPos()
    {
        //direction = playerTransform.position;
        //direction = direction.normalized;

        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        FireProjectile(angle);
        FireProjectile(angle - 30);
        FireProjectile(angle + 30);
    }
    void FireProjectile(float angle)
    {
        Rigidbody2D projetil = pool.Dequeue();
        projetil.transform.position = transform.position;
        projetil.gameObject.SetActive(true);
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        projetil.velocity = rotation * Vector3.right * projectileSpeed;
    }
    #endregion
    public override void DropItemOnDeath()
    {
        if(item != null)
        {
            int randomNumber = Random.Range(1, 10);
            print(randomNumber);
            if (randomNumber <= 3)
            {
                Instantiate(item, transform.position, transform.rotation);
            }
        }
    }
    public void Damage(float damage)
    {
        source.Play();
        Life -= (int)damage;
    }
}
