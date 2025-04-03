using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RateScript : MonoBehaviour
{
    [SerializeField] Image[] estrelas;
    void Start()
    {
        
    }
    public void RateQuantity(int quantity)
    {
        for(int i = 0; i < quantity; i++)
        {
            estrelas[i].color = Color.yellow;
        }
    }
    public void Sair()
    {
        Application.Quit();
    }
}
