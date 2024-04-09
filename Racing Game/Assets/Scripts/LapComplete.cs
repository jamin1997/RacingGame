using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LapComplete : MonoBehaviour
{

    public GameObject LapCompleteTrig;
    public GameObject HalfLapTrig;

    public TextMeshProUGUI MinuteDisplay;
    public TextMeshProUGUI SecondDisplay;
    public TextMeshProUGUI MilliDisplay;

    public GameObject LapTimeBox;

    public TextMeshProUGUI LapCounter;
    public int Laps;

    public float RawTime;

    public GameObject RaceFinish;

    private void Start()
    {
        Laps = 1;
    }

    private void Update()
    {
        if (Laps == 3)
        {
            RaceFinish.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CarPos")
        {
            Laps += 1;
            RawTime = PlayerPrefs.GetFloat("RawTime");
            if (LapTimeManager.RawTime <= RawTime)
            {
                if (LapTimeManager.SecondCount <= 9)
                {
                    SecondDisplay.GetComponent<TextMeshProUGUI>().text = "0" + LapTimeManager.SecondCount + ".";
                }
                else
                {
                    SecondDisplay.GetComponent<TextMeshProUGUI>().text = "" + LapTimeManager.SecondCount + ".";
                }

                if (LapTimeManager.MinuteCount <= 9)
                {
                    MinuteDisplay.GetComponent<TextMeshProUGUI>().text = "0" + LapTimeManager.MinuteCount + ".";
                }
                else
                {
                    MinuteDisplay.GetComponent<TextMeshProUGUI>().text = "" + LapTimeManager.MinuteCount + ".";
                }

                MilliDisplay.GetComponent<TextMeshProUGUI>().text = "" + Math.Round(LapTimeManager.MilliCount, 1);
            }
            PlayerPrefs.SetInt("MinSave", LapTimeManager.MinuteCount);
            PlayerPrefs.SetInt("SecSave", LapTimeManager.SecondCount);
            PlayerPrefs.SetFloat("MiliSave", LapTimeManager.MilliCount);
            PlayerPrefs.SetFloat("RawTime", LapTimeManager.RawTime);

            LapTimeManager.MinuteCount = 0;
            LapTimeManager.SecondCount = 0;
            LapTimeManager.MilliCount = 0;
            LapTimeManager.RawTime = 0;
            LapCounter.GetComponent<TextMeshProUGUI>().text = Laps.ToString();
            HalfLapTrig.SetActive(true);
            LapCompleteTrig.SetActive(false);
        }
    }

}
