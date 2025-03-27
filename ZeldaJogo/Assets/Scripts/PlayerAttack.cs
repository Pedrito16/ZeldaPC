using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject swordPrefab;
    [SerializeField] float attackTime;
    [SerializeField] GameObject escudo;
    GameObject sword;
    Player player;
    Coroutine attackRoutine;
    [SerializeField] Vector2 lastPlayerMove;
    public bool hasWeapon;

    private void Awake()
    {
        if(GetComponentInChildren<Sword>() == null)
        {
            sword = Instantiate(swordPrefab, transform);
            sword.SetActive(false);
            sword.transform.SetParent(transform, false);
        }
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
