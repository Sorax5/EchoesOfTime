using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void LoadGameScene()
    {
        // load scene with index
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        
    }
}
