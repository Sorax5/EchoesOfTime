using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZonesController : MonoBehaviour
{
    
    [SerializeField]
    private CheckPointsManager checkPointsManager;
    
    public void triggerEnter()
    {
        checkPointsManager.respawn();
    }
}
