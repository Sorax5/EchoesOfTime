using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    private Energy energy;
    private Image barImage;

    private void Awake()
    {
        barImage = transform.Find("bar").GetComponent<Image>();

        energy = new Energy();
    }

    public void RefillBar()
    {
        energy.RegainEnergy();

        barImage.fillAmount = energy.GetEnergyNormalized();
    }

    public void DumpBar()
    {
        energy.ConsumeEnergy();

        barImage.fillAmount = energy.GetEnergyNormalized();
    }

    public Energy GetEnergy()
    {
        return energy;
    }
}
