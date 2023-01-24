using UnityEditor;
using UnityEngine;

public class Energy
{
    public const int ENERGY_MAX = 100;

    private float energyAmount;
    private float energyRegenAmount;

    public Energy()
    {
        energyAmount = 0;
        energyRegenAmount = 10f;
    }

    public void Update()
    {
        if (energyAmount < ENERGY_MAX)
        {
            energyAmount += energyRegenAmount * Time.deltaTime;
            energyAmount = Mathf.Clamp(energyAmount, 0f, ENERGY_MAX);
        }
    }

    public void TryChangeTemporality()
    {
        if(energyAmount == ENERGY_MAX)
        {
            energyAmount -= ENERGY_MAX;
        }
    }

    public float GetEnergyNormalized()
    {
        return energyAmount / ENERGY_MAX;
    }
}