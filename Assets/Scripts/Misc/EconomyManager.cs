using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EconomyManager : Singleton<EconomyManager>
{
    [Header("UI References")]
    [SerializeField] private TMP_Text goldText;

    private int currentGold = 0;

    public void UpdateCurrentGold()
    {
        currentGold += 1;

        if (goldText != null)
        {
            goldText.text = currentGold.ToString("D3");
        }
        else
        {
            Debug.LogError("Gold Text UI component is not assigned in the Inspector!");
        }
    }
}
