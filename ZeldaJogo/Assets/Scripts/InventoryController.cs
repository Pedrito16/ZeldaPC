using System.Collections;
using UnityEngine;
using TMPro;
public class InventoryController : MonoBehaviour
{
    [Header("Essenciais")]
    [SerializeField] Transform weaponSlot;
    [SerializeField] Transform[] slots;
    [SerializeField] GameObject inventory;
    [SerializeField] Transform selectionBox;
    [SerializeField] TextMeshProUGUI useText;

    [Header("Configurações")]
    [SerializeField] float velocidade;

    [Header("Debug")]
    [SerializeField] bool isActive;
    [SerializeField] bool canMove;
    [SerializeField] int currentSelectPos;
    
    
    public static InventoryController instance;
    void Awake()
    {
        useText.gameObject.SetActive(false);
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
            useText.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                Item item = slots[currentSelectPos].GetComponentInChildren<Item>();
                item.Usar();
            }
        }else
            useText.gameObject.SetActive(false);
    }
    public bool CheckIfHasWeapon()
    {
        return weaponSlot.childCount > 0;
    }
    IEnumerator moveSelect(Vector3 newPos)
    {
        float iterador = 0;
        while(iterador <= 0.3f)
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
