using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject swordPrefab;
    [SerializeField] float attackTime;
    [SerializeField] float protectionTime;
    [SerializeField] GameObject escudoPrefab;
    GameObject escudo;
    GameObject sword;
    Player player;
    Coroutine attackRoutine;
    [SerializeField] Vector2 lastPlayerMove;
    [SerializeField] bool hasWeapon;

    private void Awake()
    {
        if(GetComponentInChildren<Sword>() == null)
        {
            sword = Instantiate(swordPrefab, transform);
            sword.SetActive(false);
            sword.transform.SetParent(transform, false);
        }
        escudo = Instantiate(escudoPrefab, transform);
        escudo.transform.SetParent(transform, false);
        escudo.transform.position = transform.position;
        escudo.SetActive(false);
    }
    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.moveInput != Vector2.zero) 
            lastPlayerMove = player.moveInput;
        if (Input.GetButtonDown("Fire1") && lastPlayerMove != Vector2.zero && attackRoutine == null && hasWeapon)
        {
            attackRoutine = StartCoroutine(Atacar());
        }
        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(Protect());
        }       
    }
    IEnumerator Protect()
    {
        player.isShielded = true;
        escudo.SetActive(true);
        yield return new WaitForSeconds(protectionTime);
        escudo.SetActive(false);
        player.isShielded = false;
    }
    private void LateUpdate()
    {
        hasWeapon = InventoryController.instance.CheckIfHasWeapon();
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
