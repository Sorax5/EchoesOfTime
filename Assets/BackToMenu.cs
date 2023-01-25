using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(returnToMenu());
    }
    
    IEnumerator returnToMenu()
    {
        yield return new WaitForSeconds(33);
        SceneManager.LoadScene(3);
    }
}
