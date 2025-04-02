using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ShowLife : MonoBehaviour
{
    [SerializeField] Image[] hearts;
    [SerializeField] Sprite[] sprites;
    Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        hearts = GetComponentsInChildren<Image>();
    }
    void Start()
    {
        player.takeDamage += RemoveLife;
    }
    void Update()
    {
        if (player.canRegenLife)
        {
            RecoverLife();
            player.canRegenLife = false;
        }
    }
    void RecoverLife()
    {
        if (player.Life == 3)
            hearts[player.Life - 1].sprite = sprites[1];
        else if(player.Life == 2)
        {
            print("RestoringLife: " + player.Life);
            hearts[player.Life].sprite = sprites[1];
        }
            
    }
    void RemoveLife()
    {
        if (player.Life < 3)
        {
            print(player.Life);
            hearts[player.Life].sprite = sprites[0];
        }
    }
}
