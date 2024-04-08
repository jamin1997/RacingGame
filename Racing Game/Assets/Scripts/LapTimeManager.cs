using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LapTimeManager : MonoBehaviour
{

    public static int MinuteCount;
    public static int SecondCount;
    public static float MilliCount;
    public static string MilliDisplay;

    public TextMeshProUGUI MinuteBox;
    public TextMeshProUGUI SecondBox;
    public TextMeshProUGUI MilliBox;


    void Update()
    {
        MilliCount += Time.deltaTime * 10;
        MilliDisplay = MilliCount.ToString("F0");
        MilliBox.GetComponent<TextMeshProUGUI>().text = "" + MilliDisplay;

        if (MilliCount > 9)
        {
            MilliCount = 0;
            SecondCount += 1;
        }

        if (SecondCount <= 9)
        {
            SecondBox.GetComponent<TextMeshProUGUI>().text = "0" + SecondCount + ".";
        }
        else
        {
            SecondBox.GetComponent<TextMeshProUGUI>().text = "" + SecondCount + ".";
        }

        if (SecondCount >= 60)
        {
            SecondCount = 0;
            MinuteCount += 1;
        }

        if (MinuteCount <= 9)
        {
            MinuteBox.GetComponent<TextMeshProUGUI>().text = "0" + MinuteCount + ":";
        }
        else
        {
            MinuteBox.GetComponent<TextMeshProUGUI>().text = "" + MinuteCount + ":";
        }

    }
}
