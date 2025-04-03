using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class DefeatEnemies : MonoBehaviour
{
    [SerializeField] Transform[] enemiesArray;
    [SerializeField] BoxCollider2D[] paredes;
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] LayerMask layerMask;
    [SerializeField] int enemiesQuantity;
    [SerializeField] DefeatEnemies deactivateScript;
    [SerializeField] bool isNotOnFight;
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        //deactivateScript = GetComponent<DefeatEnemies>();
        paredes = GetComponentsInChildren<BoxCollider2D>();
        for(int i = 0; i < paredes.Length; i++)
        {
            paredes[i].gameObject.SetActive(false);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isNotOnFight) 
        {
            return;
        }
        Vector2 size = boxCollider.size * transform.lossyScale;
        Vector2 position = (Vector2)transform.position + boxCollider.offset;
        Collider2D[] collider = Physics2D.OverlapBoxAll(position, size , 5, layerMask);
        enemiesQuantity = collider.Length;
        if(enemiesQuantity <= 0)
        {
            DesativarParedes(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isNotOnFight = true;
            DesativarParedes(true);
            for(int i = 0; i < enemiesArray.Length; i++)
            {
                enemiesArray[i]?.gameObject.SetActive(true);
            }
        }
    }
    void DesativarParedes(bool activeDesactive)
    {
        for(int i = 0; i < paredes.Length; i++)
        {
            paredes[i].gameObject.SetActive(activeDesactive);
        }
        if(!activeDesactive)
        deactivateScript.enabled = false;
    }
}
