using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaintainActive : MonoBehaviour
{
    [SerializeField] GameObject[] childrens;
    void Start()
    {
        
    }
    private void OnEnable()
    {
        Invoke("Ativar", 1f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void Ativar()
    {
        for (int i = 0; i < childrens.Length; i++)
        {
            childrens[i].SetActive(true);
        }
    }
}
