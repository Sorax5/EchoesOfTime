using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public abstract class Chronometer : MonoBehaviour
{
    
    [SerializeField]
    private int time = 0;
    
    [SerializeField]
    private int maxTime = 1000;
    
    [SerializeField]
    private bool start = false;
    
    public bool Start
    {
        get => start;
    }

    public void eachIteration()
    {
        if (start)
        {
            if(time >= maxTime)
            {
                End();
                start = false;
                time = 0;
            }
            time++;
        }
    }

    public abstract void End();

    public abstract void Begin();

    public void StartChronometer()
    {
        time = 0;
        start = true;
        Begin();
    }
    
    public void StopChronometer()
    {
        start = false;
        time = 0;
    }
}
