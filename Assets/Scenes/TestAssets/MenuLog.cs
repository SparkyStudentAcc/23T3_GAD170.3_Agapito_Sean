using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Testing menu
/// </summary>

public class Menulog : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
    
    public void LoadOtherscene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void GameQuit() {
        Debug.Log("quitted game");
        Application.Quit();
        
    }

  

}
