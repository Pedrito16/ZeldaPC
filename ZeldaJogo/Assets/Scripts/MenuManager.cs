using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
       // SceneManager.LoadScene("NOMEDACENA")
    }
      
    
}
