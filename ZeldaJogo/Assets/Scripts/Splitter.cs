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

    [Header("Debug")]
    [SerializeField] Transform playerTransform;
    [SerializeField] float timer;
    void Awake()
    {
        playerTransform = FindObjectOfType<Player>().transform;
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
        timer += Time.deltaTime;
        if (timer >= maxTime)
        {
            ShootPlayerPos();
            timer = 0;
        }
        transform.position = Vector3.Lerp(transform.position, playerTransform.position, Time.deltaTime / Speed);
        if (Life <= 0)
            Destroy(gameObject);
    }
    #region ShootDirection
    void ShootPlayerPos()
    {
        Vector3 direction = (playerTransform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        FireProjectile(angle);
        FireProjectile(angle - 20);
        FireProjectile(angle + 20);
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
    public void Damage(float damage)
    {
        Life -= (int)damage;
    }
}
