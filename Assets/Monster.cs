using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    private Transform castPoint;

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(castPoint.position, Vector2.right * new Vector2(0f, 0f));
        if(hit.collider != null)
        {
            Debug.DrawRay(castPoint.position, Vector2.right * hit.distance * new Vector2(0f, 0f), Color.red);
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                Debug.Log("I SEE YOU!");
            }
        }
    }
}
