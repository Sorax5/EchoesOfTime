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

    // Update is called once per frame
    void Update()
    {
        if (isPast)
        {
            energybar.DumpBar();
            if (Input.GetKeyDown(KeyCode.RightShift) || energybar.GetEnergy().IsEmpty())
            {
                SwitchTemporality();
            }
        }
        if (isFuture)
        {
            energybar.RefillBar();
            if (Input.GetKeyDown(KeyCode.RightShift) && energybar.GetEnergy().TryChangeTemporality())
            {
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