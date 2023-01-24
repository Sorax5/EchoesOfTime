using UnityEditor;
using UnityEngine;

public class Energy
{
    public const int ENERGY_MAX = 100;

    private float energyAmount;
    private float energyRegenAmount;
    private float energyDumpAmount;

    public Energy()
    {
        energyAmount = 0;
        energyRegenAmount = 10f;
        energyDumpAmount = 15f;
    }

    public void RegainEnergy()
    {
        if (energyAmount < ENERGY_MAX)
        {
            energyAmount += energyRegenAmount * Time.deltaTime;
            energyAmount = Mathf.Clamp(energyAmount, 0f, ENERGY_MAX);
        }
    }

    public bool TryChangeTemporality()
    {
        return energyAmount == ENERGY_MAX;
    }

    public bool IsEmpty()
    {
        return energyAmount == 0;
    }

    public float GetEnergyNormalized()
    {
        return energyAmount / ENERGY_MAX;
    }

    public void ConsumeEnergy()
    {
        if (energyAmount > 0)
        {
            energyAmount -= energyDumpAmount * Time.deltaTime; ;
            energyAmount = Mathf.Clamp(energyAmount, 0f, ENERGY_MAX);
        }
    }
    
    public bool IsFull()
    {
        return energyAmount == ENERGY_MAX;
    }
}