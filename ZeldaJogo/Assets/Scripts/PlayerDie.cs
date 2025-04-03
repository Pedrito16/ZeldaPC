using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{
    [SerializeField] GameObject dieScreen;
    [SerializeField] GameObject inventoryMenu;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip loseSound;
    bool oneTime;
    void Start()
    {
        oneTime = true;
        source.clip = loseSound;
        dieScreen.SetActive(false);
    }
    void Die()
    {
        if (oneTime)
        {
            source.PlayOneShot(loseSound);
            dieScreen.SetActive(true);
            inventoryMenu.SetActive(false);
            oneTime = false;
        }
        
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
