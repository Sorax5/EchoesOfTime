using Cinemachine;
using System;
using System.Collections;
using UnityEngine;

public class TemporalityChange : MonoBehaviour
{
    private bool isFuture = true;

    [SerializeField]
    private EnergyBar energybar;
    
    [SerializeField]
    private Animator rewindAnimator;

    [SerializeField]
    private CinemachineConfiner2D cinemachineConfiner;
    [SerializeField]
    private Collider2D colliderPast;
    [SerializeField]
    private Collider2D colliderFuture;

    [SerializeField]
    private PlayerController playerController;

    // Update is called once per frame
    void Update()
    {
        if (!isFuture)
        {
            energybar.DumpBar();
            if (Input.GetKeyDown(KeyCode.RightShift) || energybar.GetEnergy().IsEmpty())
            {
                rewindAnimator.SetTrigger("end");
                SwitchTemporality();
            }
        }
        else
        {
            energybar.RefillBar();
            if (Input.GetKeyDown(KeyCode.RightShift) && energybar.GetEnergy().TryChangeTemporality())
            {
                rewindAnimator.SetTrigger("start");
                SwitchTemporality();
            }
        }

        if (Input.GetKeyDown(KeyCode.RightShift) && !energybar.GetEnergy().IsFull())
        {
            energybar.BarImage.color = Color.red;
        }
        
        if (Input.GetKeyUp(KeyCode.RightShift))
        {
            energybar.BarImage.color = new Color(0.2627451F, 0.2235294F,0.4509804F);
        }
    }

    private void SwitchTemporality()
    {
        if (isFuture)
        {
            cinemachineConfiner.m_BoundingShape2D = colliderPast;
        }
        else
        {
            cinemachineConfiner.m_BoundingShape2D = colliderFuture;
        }
        playerController.TeleportPlayer(isFuture);
        isFuture = !isFuture;
    }
}