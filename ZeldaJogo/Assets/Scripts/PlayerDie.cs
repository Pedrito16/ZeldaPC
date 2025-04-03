using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{
    [SerializeField] GameObject dieScreen;
    [SerializeField] GameObject inventoryMenu;
    void Start()
    {
        dieScreen.SetActive(false);
    }
    void Die()
    {
        dieScreen.SetActive(true);
        inventoryMenu.SetActive(false);
    }
    public void Restart()
    {
        Player.isDead = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // Update is called once per frame
    void Update()
    {
        if (Player.isDead) Die();
    }
}
