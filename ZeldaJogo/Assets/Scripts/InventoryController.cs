using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] float velocidade;
    [SerializeField] GameObject inventory;
    [SerializeField] Transform selectionBox;
    [SerializeField] Transform[] slots;
    [SerializeField] bool isActive;
    [SerializeField] bool canMove;
    [SerializeField] int currentSelectPos;
    void Awake()
    {

    }
    private void Start()
    {
        inventory.SetActive(false);
        selectionBox.position = slots[0].position;
        canMove = true;
    }
    void Update()
    {
        currentSelectPos = Mathf.Clamp(currentSelectPos, 0, 3);
        if(Input.GetKeyDown(KeyCode.T)) 
        {
            inventory.SetActive(!inventory.activeSelf);
            isActive = inventory.activeSelf;
        }
        if (isActive && Input.GetKeyDown(KeyCode.E) && currentSelectPos < 3 && canMove)
        {
            currentSelectPos++;
            canMove = false;
            StartCoroutine(moveSelect(slots[currentSelectPos].position));
        }else if(isActive && Input.GetKeyDown(KeyCode.Q) && currentSelectPos > 0 && canMove) 
        {
            currentSelectPos--;
            canMove = false;
            StartCoroutine(moveSelect(slots[currentSelectPos].position));
        }
    }
    IEnumerator moveSelect(Vector3 newPos)
    {
        float iterador = 0;
        while(iterador <= 0.5f)
        {
            iterador += Time.deltaTime;
            selectionBox.position = Vector3.Lerp(selectionBox.position, newPos, iterador / velocidade);
            yield return null;
        }
        selectionBox.position = newPos;
        canMove = true;
    }
}
