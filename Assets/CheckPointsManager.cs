using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointsManager : MonoBehaviour
{
    [SerializeField]
    private List<CheckPoint> checkPoints = new List<CheckPoint>();
    
    [SerializeField]
    private GameObject player;

    public CheckPoint currentCheckPoint
    {
        get
        {
            CheckPoint cur = null;
            foreach (var checkPoint in checkPoints)
            {
                if (checkPoint.IsActivated)
                {
                    cur = checkPoint;
                }
            }
            return cur;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            checkPoints.Add(child.GetComponent<CheckPoint>());
        }
    }
    
    public void respawn()
    {
        if (currentCheckPoint != null)
        {
            player.transform.position = currentCheckPoint.PositionToRespawn.transform.position;
        }
    }
    
    private void resetCheckPoints()
    {
        foreach (var checkPoint in checkPoints)
        {
            checkPoint.IsActivated = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            respawn();
            resetCheckPoints();
        }
    }
}
