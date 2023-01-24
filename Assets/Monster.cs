using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // The player GameObject
    public Transform player;
    // The maximum distance for the line of sight
    public float maxDistance;

    //// Update is called once per frame
    void Update()
    {
        // Calculate the distance between the enemy and the player
        float distance = Vector3.Distance(transform.position, player.position);

        // Check if the player is within the maximum distance for the line of sight
        if (distance < maxDistance)
        {
            Debug.DrawLine(transform.position, player.position, Color.red);
        }
    }
}
