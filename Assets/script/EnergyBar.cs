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

    private void Update()
    {
        energy.Update();

        barImage.fillAmount = energy.GetEnergyNormalized();
    }
}
