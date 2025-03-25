using System.Collections;
using UnityEngine;
using TMPro;
public class InventoryController : MonoBehaviour
{
    [SerializeField] float velocidade;
    [SerializeField] GameObject inventory;
    [SerializeField] Transform selectionBox;
    [SerializeField] Transform[] slots;
    [SerializeField] bool isActive;
    [SerializeField] bool canMove;
    [SerializeField] int currentSelectPos;
    [SerializeField] Transform[] equippedSlots;
    [SerializeField] TextMeshProUGUI useText;
    public static InventoryController instance; 
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        inventory.SetActive(false);
        selectionBox.position = slots[0].position;
        canMove = true;
    }
    void Update()
    {
        currentSelectPos = Mathf.Clamp(currentSelectPos, 0, 5);
        if(Input.GetKeyDown(KeyCode.T)) 
        {
            inventory.SetActive(!inventory.activeSelf);
            isActive = inventory.activeSelf;
        }
        if (isActive && Input.GetKeyDown(KeyCode.E) && currentSelectPos < 5 && canMove)
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
        if (slots[currentSelectPos].childCount > 0 && slots[currentSelectPos].GetComponentInChildren<Item>() != null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Item item = slots[currentSelectPos].GetComponentInChildren<Item>();
                item.Usar();
            }
        }
    }
    IEnumerator moveSelect(Vector3 newPos)
    {
        float iterador = 0;
        while(iterador <= 0.40f)
        {
            iterador += Time.deltaTime;
            selectionBox.position = Vector3.Lerp(selectionBox.position, newPos, iterador / velocidade);
            yield return null;
        }
        selectionBox.position = newPos;
        canMove = true;
    }
    public Transform FindAvailableSlot()
    {
        for (int i = 0; i < slots.Length - 2; i++)
        {
            if (slots[i].childCount <= 0)
            {
                return slots[i];
            }
        }
        return null;
    }
}
