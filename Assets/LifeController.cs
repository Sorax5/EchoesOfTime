using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    
    [SerializeField]
    private int life = 3;
    
    public int Life
    {
        get => life;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
