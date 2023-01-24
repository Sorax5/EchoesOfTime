using System;
using System.Collections;
using UnityEngine;

public class TemporalityChange : MonoBehaviour
{
    [SerializeField]
    private GameObject pastTemporality;
    private bool isPast = false;

    [SerializeField]
    private GameObject futureTemporality;
    private bool isFuture = true;

    [SerializeField]
    private EnergyBar energybar;
    
    [SerializeField]
    private Animator rewindAnimator;

    // Update is called once per frame
    void Update()
    {
        if (isPast)
        {
            energybar.DumpBar();
            if (Input.GetKeyDown(KeyCode.RightShift) || energybar.GetEnergy().IsEmpty())
            {
                rewindAnimator.SetTrigger("end");
                SwitchTemporality();
            }
        }
        if (isFuture)
        {
            energybar.RefillBar();
            if (Input.GetKeyDown(KeyCode.RightShift) && energybar.GetEnergy().TryChangeTemporality())
            {
                rewindAnimator.SetTrigger("start");
                SwitchTemporality();
            }
        }
    }

    private void SwitchTemporality()
    {
        futureTemporality.SetActive(isPast);
        pastTemporality.SetActive(isFuture);

        isFuture = futureTemporality.activeSelf;
        isPast = pastTemporality.activeSelf;
    }
}