using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject menuControls;
    
    void Start()
    {
        menuControls.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Sair()
    {
        Application.Quit();
        EditorApplication.isPlaying = false;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ControlsMenu()
    {
        menuControls.SetActive(true);
    }
    public void FechaControls()
    {
        menuControls.SetActive(false);
    }
      
    
}
