using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    private Energy energy;
    private Image barImage;

    public Energy Energy
    {
        get => energy;
    }

    private void Awake()
    {
        barImage = transform.Find("bar").GetComponent<Image>();

        energy = new Energy();
    }

    private void Update()
    {
        energy.Update();

        barImage.fillAmount = energy.GetEnergyNormalized();
    }
}
