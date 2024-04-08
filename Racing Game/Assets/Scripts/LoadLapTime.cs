using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadLapTime : MonoBehaviour
{
    public int MinCount;
    public int SecCount;
    public float MiliCoount;
    public TextMeshProUGUI MinDisplay;
    public TextMeshProUGUI SecDisplay;
    public TextMeshProUGUI MiliDisplay;

    // Update is called once per frame
    void Update()
    {
        MinCount = PlayerPrefs.GetInt("MinSave");
        SecCount = PlayerPrefs.GetInt("SecSave");
        MiliCoount = PlayerPrefs.GetFloat("MiliSave");

        MinDisplay.GetComponent<TextMeshProUGUI>().text = MinCount.ToString() + ":";
        SecDisplay.GetComponent<TextMeshProUGUI>().text= SecCount.ToString() + ".";
        MiliDisplay.GetComponent<TextMeshProUGUI>().text = Math.Round(MiliCoount,1).ToString();
    }
}
