using System;
using System.Collections;
using UnityEngine;

public class TemporalityChange : MonoBehaviour
{
    [SerializeField]
    private GameObject pastTemporality;

    [SerializeField]
    private GameObject futurTemporality;

    [SerializeField]
    private EnergyBar energybar;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            if (energybar.Energy.TryChangeTemporality())
            {
                SwitchTemporality();
            }
        }
    }

    private void SwitchTemporality()
    {
        if (pastTemporality.activeSelf == true)
        {
            futurTemporality.SetActive(true);
            pastTemporality.SetActive(false);
        }
        else
        {
            pastTemporality.SetActive(true);
            futurTemporality.SetActive(false);
        }
    }
}