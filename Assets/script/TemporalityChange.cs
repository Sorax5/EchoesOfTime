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
        futureTemporality.SetActive(isPast);
        pastTemporality.SetActive(isFuture);

        isFuture = futureTemporality.activeSelf;
        isPast = pastTemporality.activeSelf;
    }
}