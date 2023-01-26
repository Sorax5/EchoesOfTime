using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private DeadZonesController deadZonesController;
    
    private void Awake()
    {
        deadZonesController = transform.parent.gameObject.GetComponentInParent<DeadZonesController>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            deadZonesController.triggerEnter();
        }
    }
}
