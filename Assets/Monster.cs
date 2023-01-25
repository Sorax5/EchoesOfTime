using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

public class Monster : Chronometer
{

    [SerializeField]
    private bool isChasing = false;
    
    [SerializeField]
    private Tilemap futureTile;
    
    [SerializeField]
    private Tilemap pastTile;
    
    [SerializeField]
    private List<GameObject> inField = new List<GameObject>();
    
    [SerializeField]
    private CheckPointsManager checkPointsManager;

    [SerializeField] private List<GameObject> attention = new List<GameObject>();
    
    private Collider2D coll;
    
    private Animator animator;

    private void Awake()
    {
        coll = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        MaxTime = 150;
        StartChronometer();
    }

    //// Update is called once per frame
    void FixedUpdate()
    {
        eachIteration();
        if (isChasing)
        {
            animator.SetTrigger("active");
            // check if the player toucn a tile in the futureTile
            foreach (var o in inField)
            {
                if (!futureTile.HasTile(futureTile.WorldToCell(o.transform.position)) && futureTile.isActiveAndEnabled)
                {
                    checkPointsManager.respawn();
                }
                
                if (!pastTile.HasTile(pastTile.WorldToCell(o.transform.position)) && pastTile.isActiveAndEnabled)
                {
                    checkPointsManager.respawn();
                }
            }
        }
        
        foreach (var o in attention)
        {
            o.SetActive(isChasing);
        }

        /*// Calculate the distance between the enemy and the player
        float distance = Vector3.Distance(transform.position, player.position);

        // Check if the player is within the maximum distance for the line of sight
        if (distance < maxDistance)
        {
            Debug.DrawLine(transform.position, player.position, Color.red);
        }*/
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("enter");
        if (col.gameObject.CompareTag("Player"))
        {
            inField.Add(col.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("exit");
        if (other.gameObject.CompareTag("Player") && inField.Contains(other.gameObject))
        {
            inField.Remove(other.gameObject);
        }
    }

    public override void End()
    {
        isChasing = !isChasing;
        StartChronometer();
    }

    public override void Begin()
    {
    }
}
