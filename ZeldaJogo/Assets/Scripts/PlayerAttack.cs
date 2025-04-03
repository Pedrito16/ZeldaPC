using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Essentials")]
    [SerializeField] GameObject bookPrefab;
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject swordPrefab;
    [SerializeField] GameObject escudoPrefab;

    [Header("Configurações")]
    [SerializeField] string swordTag;
    [SerializeField] float attackTime;
    [SerializeField] float projectileSpeed;
    [SerializeField] float protectionTime;
    [SerializeField] float protectionCooldown;

    [Header("Debug")]
    [SerializeField] Vector2 lastPlayerMove;
    [SerializeField] bool hasWeapon;
    [SerializeField] bool canProtect;
    //variaveis invisiveis
    Coroutine attackRoutine;
    GameObject escudo;
    GameObject sword;
    GameObject book;
    Player player;
    private void Awake()
    {
        if (GetComponentInChildren<Livro>() == null)
        {
            book = Instantiate(bookPrefab, transform);
            book.SetActive(false);
            book.transform.position = transform.position;
            book.transform.SetParent(transform, false);
        }
        if (GetComponentInChildren<Sword>() == null)
        {
            
            sword = Instantiate(swordPrefab, transform);
            sword.SetActive(false);
            sword.transform.SetParent(transform, false);
        }
        sword.tag = swordTag;
        escudo = Instantiate(escudoPrefab, transform);
        escudo.transform.SetParent(transform, false);
        escudo.transform.position = transform.position;
        escudo.SetActive(false);
    }
    void Start()
    {
        player = GetComponent<Player>();
    }
    void Update()
    {
        if(player.moveInput != Vector2.zero) 
            lastPlayerMove = player.moveInput;
        if (Input.GetButtonDown("Fire1") && lastPlayerMove != Vector2.zero && attackRoutine == null && hasWeapon)
        {
            Item arma = InventoryController.instance.CheckIfHasWeapon();
            if (arma.CompareTag("Book"))
            {
                StartCoroutine(SpellShoot());
            }
            else
            {
                attackRoutine = StartCoroutine(Atacar());
            }
        }
        if (Input.GetMouseButtonDown(1) && canProtect)
        {
            StartCoroutine(Protect());
        }       
    }
    IEnumerator ProtectionCooldown()
    {
        canProtect = false;
        yield return new WaitForSeconds(protectionCooldown);
        canProtect = true;
    }
    IEnumerator Protect()
    {
        player.isShielded = true;
        escudo.SetActive(true);
        yield return new WaitForSeconds(protectionTime);
        escudo.SetActive(false);
        player.isShielded = false;
        StartCoroutine(ProtectionCooldown());
    }
    private void LateUpdate()
    {
        hasWeapon = InventoryController.instance.CheckIfHasWeapon();
    }
    IEnumerator SpellShoot()
    {
        GameObject tiro = Instantiate(projectile);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Rigidbody2D projectileRb = tiro.GetComponent<Rigidbody2D>();
        Vector2 direction = mousePos - transform.position;
        direction = direction.normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        tiro.transform.rotation = Quaternion.Euler(0,0,angle);
        book.SetActive(true);
        tiro.transform.position = transform.position;
        projectileRb.velocity = direction * projectileSpeed;
        yield return new WaitForSeconds(0.75f);
        book.SetActive(false);
    }
    IEnumerator Atacar()
    {
        sword.SetActive(true);
        Vector3 rotation = Vector3.left * lastPlayerMove.x + Vector3.down * lastPlayerMove.y;

        sword.transform.rotation = Quaternion.LookRotation(Vector3.forward, rotation);
        sword.transform.position = transform.position + new Vector3(lastPlayerMove.x, lastPlayerMove.y);

        yield return new WaitForSeconds(attackTime);
        sword.SetActive(false);
        attackRoutine = null;
    }
}
